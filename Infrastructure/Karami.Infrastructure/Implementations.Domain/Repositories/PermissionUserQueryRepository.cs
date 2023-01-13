using Karami.Domain.Permission.Entities;
using Karami.Domain.PermissionUser.Contracts.Interfaces;
using Karami.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Karami.Infrastructure.Implementations.Domain;

public class PermissionUserQueryRepository : IPermissionUserQueryRepository
{
    private readonly SQLContext _context;
    
    public PermissionUserQueryRepository(SQLContext context) => _context = context;

    public async Task<PermissionUser> FindByIdAsync(object id, CancellationToken cancellationToken)
        => await _context.PermissionUsers.FirstOrDefaultAsync(pu => pu.Id.Equals(id), cancellationToken);

    public async Task<IEnumerable<PermissionUser>> FindAllByUserIdAsync(string userId,
        CancellationToken cancellationToken
    ) => await _context.PermissionUsers.Where(pu => pu.UserId.Equals(userId)).ToListAsync(cancellationToken);
}