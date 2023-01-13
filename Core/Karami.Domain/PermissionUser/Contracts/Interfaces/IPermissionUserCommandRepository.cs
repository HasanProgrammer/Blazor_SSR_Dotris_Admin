using Karami.Domain.Commons.Contracts.Interfaces;

namespace Karami.Domain.PermissionUser.Contracts.Interfaces;

public interface IPermissionUserCommandRepository : ICommandRepository<Permission.Entities.PermissionUser, string>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="permissionUser"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void RemoveByForeignKeies(Permission.Entities.PermissionUser permissionUser) 
        => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="permissionUser"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task RemoveByForeignKeiesAsync(Permission.Entities.PermissionUser permissionUser, 
        CancellationToken cancellationToken
    ) => throw new NotImplementedException();
}