using Karami.Domain.RoleUser.Contracts.Interfaces;
using Karami.Domain.RoleUser.Entities;
using Karami.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Karami.Infrastructure.Implementations.Domain;

public class RoleUserQueryRepository : IRoleUserQueryRepository
{
    private readonly SQLContext _context;

    public RoleUserQueryRepository(SQLContext context) => _context = context;

    public async Task<RoleUser> FindByIdAsync(object id, CancellationToken cancellationToken)
        => await _context.RoleUsers.FirstOrDefaultAsync(ru => ru.Id.Equals(id), cancellationToken);

    public async Task<IEnumerable<RoleUser>> FindAllByUserIdAsync(string userId, CancellationToken cancellationToken)
        => await _context.RoleUsers.Where(ru => ru.UserId.Equals(userId)).ToListAsync(cancellationToken);
}