using System.Security.Claims;
using Karami.Common.ClassExtensions;
using Karami.Common.ClassWrappers;
using Karami.Domain.Commons.Contracts.Interfaces;
using Karami.UseCase.Commons.Contracts.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Karami.UseCase.UserUseCase.Commands.SignInUser;

public class SignInUserCommandHandler : ICommandHandler<SignInUserCommand, string>
{
    private readonly IUnitOfWork    _unitOfWork;
    private readonly IConfiguration _configuration;

    public SignInUserCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuration)
    {
        _unitOfWork    = unitOfWork;
        _configuration = configuration;
    }

    public async Task<string> HandleAsync(SignInUserCommand command, CancellationToken cancellationToken)
    {
        var targetUser = await _unitOfWork.UserQueryRepository().FindByUsernameEagerLoadingAsync(command.Username, cancellationToken);

        if (targetUser == null || await _unitOfWork.UserQueryRepository()
                                                   .FindByPasswordAsync(command.Password.HashAsync().Result, cancellationToken) == null)
            throw new InvalidOperationException();
        
        var jsonWebToken = new JsonWebToken(_configuration.GetValue<string>("JWT:Key"));
        
        return await jsonWebToken.SetClaims(
            new Claim("Username", targetUser.Username.Value)
        )
        .SetClaimsIdentity(identity => {
            
            /*این قسمت ضروری است ، و از این Claim برای شناسایی کاربر لاگین کرده استفاده می شود ( با استفاده از Identity )*/
            identity.AddClaim(new Claim(ClaimTypes.Name, targetUser.Username.Value));
            
            /*این قسمت ضروری است ، از این Claim ها برای سطوح دسترسی ( ACL ) در درخواست های کاربر استفاده می گردد*/
            
            //Roles
            identity.AddClaims(
                targetUser.RoleUsers.Select(role => new Claim(ClaimTypes.Role, role.Role.Name.Value))
            );
            
            //Permissions
            identity.AddClaims(
                targetUser.PermissionUsers.Select(role => new Claim("Permission", role.Permission.Name.Value))
            );
            
            return Task.CompletedTask;
            
        })
        .Result
        .SetTokenDescriptor((descriptor, identity, credentials) => {

            /*در این Lambda ، بدنه توکن بر اساس معماری JWT ساخته میشود*/
                
            descriptor.Issuer             = _configuration.GetValue<string>("JWT:Issuer");
            descriptor.Audience           = _configuration.GetValue<string>("JWT:Audience");
            descriptor.Subject            = identity;
            descriptor.Expires            = DateTime.UtcNow.AddMinutes(_configuration.GetValue<int>("JWT:Expire"));
            descriptor.SigningCredentials = credentials;

            return descriptor;
            
        })
        .ExecuteAsync();
    }
}