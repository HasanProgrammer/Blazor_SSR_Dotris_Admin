using Karami.Common.ClassExtensions;
using Karami.Domain.Commons.Contracts.Interfaces;
using Karami.UseCase.Commons.Contracts.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Karami.UseCase.Commons.Jobs;

public class EventOutBoxJob : IProducerService
{
    private readonly IHostEnvironment     _HostEnvironment;
    private readonly IServiceScopeFactory _ServiceScopeFactory;

    public EventOutBoxJob(IServiceScopeFactory ServiceScopeFactory, IHostEnvironment HostEnvironment)
    {
        _HostEnvironment     = HostEnvironment;
        _ServiceScopeFactory = ServiceScopeFactory;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        using IServiceScope ServiceScope = _ServiceScopeFactory.CreateScope(); //شبیه سازی ارسال درخواست کاربر
        
        IUnitOfWork UnitOfWork = ServiceScope.ServiceProvider.GetService<IUnitOfWork>();

        try
        {
            UnitOfWork.Transaction();
        }
        catch (Exception e)
        {
            e.FileLogger(_HostEnvironment);
            UnitOfWork.Rollback();
        }
        
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken) => throw new NotImplementedException();
}