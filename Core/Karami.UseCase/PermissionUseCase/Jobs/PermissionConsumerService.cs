using Karami.UseCase.Commons.Contracts.Interfaces;
using Karami.UseCase.PermissionUseCase.Contracts.Interfaces;

namespace Karami.UseCase.RoleUseCase.Jobs;

public class PermissionConsumerService : IConsumerService
{
    private readonly IPermissionEventBus _PermissionEventBus;

    public PermissionConsumerService(IPermissionEventBus PermissionEventBus) => _PermissionEventBus = PermissionEventBus;

    public async Task StartAsync(CancellationToken cancellationToken) 
        => await _PermissionEventBus.SubscribeAsync(cancellationToken);

    public Task StopAsync(CancellationToken cancellationToken) => throw new NotImplementedException();
}