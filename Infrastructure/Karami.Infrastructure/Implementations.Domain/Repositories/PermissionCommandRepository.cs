using Karami.Domain.Permission.Contracts.Interfaces;
using Karami.Domain.Permission.Entities;
using Karami.Persistence.Contexts;

namespace Karami.Infrastructure.Implementations.Domain;

public class PermissionCommandRepository : IPermissionCommandRepository
{
    private readonly SQLContext _Context;

    public PermissionCommandRepository(SQLContext Context) => _Context = Context;

    public void Add(Permission entity) => _Context.Permissions.Add(entity);

    public void Change(Permission entity) => _Context.Permissions.Update(entity);

    public void Remove(Permission entity) => _Context.Permissions.Remove(entity);

    public void RemoveRange(IEnumerable<Permission> entities) => _Context.Permissions.RemoveRange(entities);
}