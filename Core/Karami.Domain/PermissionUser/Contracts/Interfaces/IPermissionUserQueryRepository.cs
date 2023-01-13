using Karami.Domain.Commons.Contracts.Interfaces;

namespace Karami.Domain.PermissionUser.Contracts.Interfaces;

public interface IPermissionUserQueryRepository : IQueryRepository<Permission.Entities.PermissionUser, string>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="permissionId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<Permission.Entities.PermissionUser> FindByForeignKeiesAsync(string userId, string permissionId,
        CancellationToken cancellationToken
    ) => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<IEnumerable<Permission.Entities.PermissionUser>> FindAllByUserIdAsync(string userId, 
        CancellationToken cancellationToken
    ) => throw new NotImplementedException();
}