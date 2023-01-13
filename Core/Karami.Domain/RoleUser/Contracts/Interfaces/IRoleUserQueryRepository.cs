using Karami.Domain.Commons.Contracts.Interfaces;

namespace Karami.Domain.RoleUser.Contracts.Interfaces;

public interface IRoleUserQueryRepository : IQueryRepository<Entities.RoleUser, string>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="roleId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<Entities.RoleUser> FindByForeignKeiesAsync(string userId, string roleId,
        CancellationToken cancellationToken
    ) => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<IEnumerable<Entities.RoleUser>> FindAllByUserIdAsync(string userId, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}