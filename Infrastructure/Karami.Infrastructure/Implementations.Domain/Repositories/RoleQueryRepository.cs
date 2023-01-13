using Karami.Domain.Role.Contracts.Interfaces;
using Karami.Domain.Role.Entities;
using Karami.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Karami.Infrastructure.Implementations.Domain;

public class RoleQueryRepository : IRoleQueryRepository
{
    private readonly SQLContext _Context;

    public RoleQueryRepository(SQLContext Context) => _Context = Context;

    public async Task<Role> FindByIdAsync(object id, CancellationToken cancellationToken)
        => await _Context.Roles.AsNoTracking().FirstOrDefaultAsync(Role => Role.Id.Equals(id), cancellationToken);

    public async Task<Role> FindByIdEagerLoadingAsync(object id, CancellationToken cancellationToken)
        => await _Context.Roles.AsNoTracking()
                               .Where(Role => Role.Id.Equals(id))
                               .Include(Role => Role.Permissions)
                               .FirstOrDefaultAsync(cancellationToken);
}