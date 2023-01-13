using Karami.Domain.User.Contracts.Interfaces;
using Karami.Domain.User.Entities;
using Karami.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Karami.Infrastructure.Implementations.Domain;

public class UserQueryRepository : IUserQueryRepository
{
    private readonly SQLContext _context;

    public UserQueryRepository(SQLContext context) => _context = context;

    public async Task<User> FindByIdAsync(object id, CancellationToken cancellationToken) 
        => await _context.Users.FirstOrDefaultAsync(user => user.Id.Equals(id), cancellationToken);

    public async Task<User> FindByPasswordAsync(string password, CancellationToken cancellationToken)
        => await _context.Users.FirstOrDefaultAsync(user => user.Password.Value.Equals(password), cancellationToken);

    public async Task<User> FindByUsernameEagerLoadingAsync(string username, CancellationToken cancellationToken) 
        => await _context.Users.AsNoTracking()
                               .Where(user => user.Username.Value.Equals(username))
                               .Include(user => user.RoleUsers)
                               .ThenInclude(ru => ru.Role)
                               .Include(user => user.PermissionUsers)
                               .ThenInclude(pu => pu.Permission)
                               .FirstOrDefaultAsync(cancellationToken);
                                
}