using Karami.Domain.Permission.Entities;
using Karami.Domain.PermissionUser.Contracts.Interfaces;
using Karami.Persistence.Contexts;

namespace Karami.Infrastructure.Implementations.Domain;

public class PermissionUserCommandRepository : IPermissionUserCommandRepository
{
    private readonly SQLContext _context;

    public PermissionUserCommandRepository(SQLContext context) => _context = context;

    public void Add(PermissionUser entity) => _context.PermissionUsers.Add(entity);

    public void Remove(PermissionUser entity) => _context.PermissionUsers.Remove(entity);
}