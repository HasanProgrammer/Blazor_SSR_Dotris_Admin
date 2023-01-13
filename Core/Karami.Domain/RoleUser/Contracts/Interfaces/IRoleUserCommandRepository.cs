using Karami.Domain.Commons.Contracts.Interfaces;

namespace Karami.Domain.RoleUser.Contracts.Interfaces;

public interface IRoleUserCommandRepository : ICommandRepository<Entities.RoleUser, string>
{
    public void RemoveByForeignKeies(Entities.RoleUser roleUser) => throw new NotImplementedException();
    public Task RemoveByForeignKeiesAsync(Entities.RoleUser roleUser) => throw new NotImplementedException();
}