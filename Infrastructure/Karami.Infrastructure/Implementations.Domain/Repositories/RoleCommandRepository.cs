using Karami.Domain.Role.Contracts.Interfaces;
using Karami.Domain.Role.Entities;
using Karami.Persistence.Contexts;

namespace Karami.Infrastructure.Implementations.Domain;

public class RoleCommandRepository : IRoleCommandRepository
{
    private readonly SQLContext _Context;

    public RoleCommandRepository(SQLContext Context) => _Context = Context;

    public void Add(Role entity) => _Context.Roles.Add(entity);

    public void Change(Role entity) => _Context.Roles.Update(entity);

    public void Remove(Role entity) => _Context.Roles.Remove(entity);
}