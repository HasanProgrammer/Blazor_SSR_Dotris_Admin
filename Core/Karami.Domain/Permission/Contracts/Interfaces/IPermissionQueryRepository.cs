using Karami.Domain.Commons.Contracts.Interfaces;

namespace Karami.Domain.Permission.Contracts.Interfaces;

public interface IPermissionQueryRepository : IQueryRepository<Entities.Permission, string>
{
    public Task<IEnumerable<Entities.Permission>> FindByRoleIdAsync(string roleId) => throw new NotImplementedException();
}