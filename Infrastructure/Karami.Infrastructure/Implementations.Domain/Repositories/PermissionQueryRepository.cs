using Karami.Domain.Permission.Contracts.Interfaces;
using Karami.Domain.Permission.Entities;
using Karami.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Karami.Infrastructure.Implementations.Domain;

public class PermissionQueryRepository : IPermissionQueryRepository
{
    private readonly SQLContext _Context;

    public PermissionQueryRepository(SQLContext Context) => _Context = Context;

    public async Task<Permission> FindByIdAsync(object id, CancellationToken cancellationToken)
        => await _Context.Permissions.FirstOrDefaultAsync(Permission => Permission.Id.Equals(id), cancellationToken);
}