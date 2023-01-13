using Karami.Domain.Commons.Contracts.Interfaces;
using Karami.Domain.Entity.Contracts.Interfaces;
using Karami.Domain.Permission.Contracts.Interfaces;
using Karami.Domain.PermissionUser.Contracts.Interfaces;
using Karami.Domain.Role.Contracts.Interfaces;
using Karami.Domain.RoleUser.Contracts.Interfaces;
using Karami.Domain.User.Contracts.Interfaces;
using Karami.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;

namespace Karami.Infrastructure.Implementations.Domain;

//Transactions
public partial class UnitOfWork : IUnitOfWork
{
    private readonly SQLContext       _Context;
    private readonly IServiceProvider _ServiceProvider;

    public UnitOfWork(SQLContext Context, IServiceProvider ServiceProvider)
    {
        _Context         = Context; //Resource
        _ServiceProvider = ServiceProvider;
    }

    public void Transaction() => _Context.Database.BeginTransaction(); //Resource

    public async Task TransactionAsync(CancellationToken cancellationToken) 
        => await _Context.Database.BeginTransactionAsync(cancellationToken); //Resource

    public void Commit()
    {
        _Context.SaveChanges();
        _Context.Database.CommitTransaction();
    }

    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        await _Context.SaveChangesAsync(cancellationToken);
        await _Context.Database.CommitTransactionAsync(cancellationToken);
    }

    public void Rollback()
    {
        if (_Context.Database.CurrentTransaction != null)
            _Context.Database.RollbackTransaction();
    }

    public async Task RollbackAsync(CancellationToken cancellationToken)
    {
        if(_Context.Database.CurrentTransaction != null)
            await _Context.Database.RollbackTransactionAsync(cancellationToken);
    }

    public void Dispose() {}
}

//Command Repositories
public partial class UnitOfWork
{
    public IUserCommandRepository UserCommandRepository()
        => _ServiceProvider.GetRequiredService<IUserCommandRepository>();
    
    public IRoleCommandRepository RoleCommandRepository() 
        => _ServiceProvider.GetRequiredService<IRoleCommandRepository>();
    
    public IEventCommandRepository EventCommandRepository() 
        => _ServiceProvider.GetRequiredService<IEventCommandRepository>();
    
    public IRoleUserCommandRepository RoleUserCommandRepository() 
        => _ServiceProvider.GetRequiredService<IRoleUserCommandRepository>();
    
    public IPermissionCommandRepository PermissionCommandRepository() 
        => _ServiceProvider.GetRequiredService<IPermissionCommandRepository>();
    
    public IPermissionUserCommandRepository PermissionUserCommandRepository() 
        => _ServiceProvider.GetRequiredService<IPermissionUserCommandRepository>();
}

//Query Repositories
public partial class UnitOfWork
{
    public IUserQueryRepository UserQueryRepository() 
        => _ServiceProvider.GetRequiredService<IUserQueryRepository>();
    
    public IRoleQueryRepository RoleQueryRepository() 
        => _ServiceProvider.GetRequiredService<IRoleQueryRepository>();
    
    public IRoleUserQueryRepository RoleUserQueryRepository() 
        => _ServiceProvider.GetRequiredService<IRoleUserQueryRepository>();
    
    public IPermissionQueryRepository PermissionQueryRepository() 
        => _ServiceProvider.GetRequiredService<IPermissionQueryRepository>();

    public IPermissionUserQueryRepository PermissionUserQueryRepository() 
        => _ServiceProvider.GetRequiredService<IPermissionUserQueryRepository>();
    
    public IEventQueryRepository EventQueryRepository() 
        => _ServiceProvider.GetRequiredService<IEventQueryRepository>();
}