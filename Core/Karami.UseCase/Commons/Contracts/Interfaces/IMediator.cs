using Karami.Domain.Commons.Contracts.Interfaces;

namespace Karami.UseCase.Commons.Contracts.Interfaces;

public interface IMediator
{
    #region CommandsHandler Dispatcher

    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public TResult Dispatch<TResult>(ICommand<TResult> command) => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<TResult> DispatchAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken)
        => throw new NotImplementedException();

    #endregion

    #region QueriesHandler Dispatcher

    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public TResult Dispatch<TResult>(IQuery<TResult> query) => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<TResult> DispatchAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken)
        => throw new NotImplementedException();

    #endregion

    #region EventsHandler Dispatcher

    /// <summary>
    /// 
    /// </summary>
    /// <param name="domainEvent"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Notify(IDomainEvent domainEvent) => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="domainEvent"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task NotifyAsync(IDomainEvent domainEvent, CancellationToken cancellationToken)
        => throw new NotImplementedException();

    #endregion
}