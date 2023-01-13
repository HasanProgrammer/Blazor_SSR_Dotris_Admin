using Karami.Domain.RoleUser.Contracts.Interfaces;
using Karami.Domain.RoleUser.Entities;
using Karami.Persistence.Contexts;

namespace Karami.Infrastructure.Implementations.Domain;

public class RoleUserCommandRepository : IRoleUserCommandRepository
{
    private readonly SQLContext _context;

    public RoleUserCommandRepository(SQLContext context) => _context = context;

    public void Add(RoleUser entity) => _context.RoleUsers.Add(entity);

    public void Remove(RoleUser entity) => _context.RoleUsers.Remove(entity);
}