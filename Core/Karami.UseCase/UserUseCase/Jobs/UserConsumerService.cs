using Karami.UseCase.Commons.Contracts.Interfaces;
using Karami.UseCase.UserUseCase.Contracts.Interfaces;

namespace Karami.UseCase.RoleUseCase.Jobs;

public class UserConsumerService : IConsumerService
{
    private readonly IUserEventBus _userEventBus;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userEventBus"></param>
    public UserConsumerService(IUserEventBus userEventBus) => _userEventBus = userEventBus;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    public async Task StartAsync(CancellationToken cancellationToken) 
        => await _userEventBus.SubscribeAsync(cancellationToken);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task StopAsync(CancellationToken cancellationToken) => throw new NotImplementedException();
}