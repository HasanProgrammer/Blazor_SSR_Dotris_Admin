using Karami.UseCase.Commons.Contracts.Interfaces;
using Karami.UseCase.RoleUseCase.Contracts.Interfaces;

namespace Karami.UseCase.RoleUseCase.Jobs;

public class RoleConsumerService : IConsumerService
{
    private readonly IRoleEventBus _RoleEventBus;

    public RoleConsumerService(IRoleEventBus RoleEventBus) => _RoleEventBus = RoleEventBus;

    public async Task StartAsync(CancellationToken cancellationToken) 
        => await _RoleEventBus.SubscribeAsync(cancellationToken);

    public Task StopAsync(CancellationToken cancellationToken) => throw new NotImplementedException();
}