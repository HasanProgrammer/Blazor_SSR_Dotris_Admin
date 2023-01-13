using Karami.Domain.Commons.Contracts.Interfaces;
using Karami.UseCase.Commons.Contracts.Interfaces;

namespace Karami.Infrastructure.Implementations.UseCase.Services;

//DI
public partial class Mediator : IMediator
{
    private readonly IServiceProvider _ServiceProvider;

    public Mediator(IServiceProvider ServiceProvider) => _ServiceProvider = ServiceProvider;
}

//Command & Query
public partial class Mediator
{
    public TResult Dispatch<TResult>(ICommand<TResult> command)
    {
        Type Type              = typeof(ICommandHandler<,>);
        Type[] ArgTypes        = { command.GetType() , typeof(TResult) };
        Type HandlerType       = Type.MakeGenericType(ArgTypes);
        dynamic CommandHandler = _ServiceProvider.GetService(HandlerType);

        return CommandHandler.Handle((dynamic) command);
    }

    public async Task<TResult> DispatchAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken)
    {
        Type Type              = typeof(ICommandHandler<,>);
        Type[] ArgTypes        = { command.GetType() , typeof(TResult) };
        Type HandlerType       = Type.MakeGenericType(ArgTypes);
        dynamic CommandHandler = _ServiceProvider.GetService(HandlerType);

        return await CommandHandler.HandleAsync((dynamic) command, (dynamic) cancellationToken);
    }

    public TResult Dispatch<TResult>(IQuery<TResult> query)
    {
        Type Type            = typeof(IQueryHandler<,>);
        Type[] ArgTypes      = { query.GetType() , typeof(TResult) };
        Type HandlerType     = Type.MakeGenericType(ArgTypes);
        dynamic QueryHandler = _ServiceProvider.GetService(HandlerType);

        return QueryHandler.Handle((dynamic) query);
    }

    public async Task<TResult> DispatchAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken)
    {
        Type Type            = typeof(IQueryHandler<,>);
        Type[] ArgTypes      = { query.GetType() , typeof(TResult) };
        Type HandlerType     = Type.MakeGenericType(ArgTypes);
        dynamic QueryHandler = _ServiceProvider.GetService(HandlerType);

        return await QueryHandler.HandleAsync((dynamic) query, (dynamic) cancellationToken);
    }
}

//DomainEvent
public partial class Mediator
{
    public void Notify(IDomainEvent domainEvent)
    {
        Type Type        = typeof(IEventHandler<>);
        Type[] ArgTypes  = { domainEvent.GetType() };
        Type HandlerType = Type.MakeGenericType(ArgTypes);
        dynamic Handler  = _ServiceProvider.GetService(HandlerType);

        Handler.Handle((dynamic) domainEvent);
    }

    public async Task NotifyAsync(IDomainEvent domainEvent, CancellationToken cancellationToken)
    {
        Type Type        = typeof(IEventHandler<>);
        Type[] ArgTypes  = { domainEvent.GetType() };
        Type HandlerType = Type.MakeGenericType(ArgTypes);
        dynamic Handler  = _ServiceProvider.GetService(HandlerType);

        await Handler.HandleAsync((dynamic) domainEvent, (dynamic) cancellationToken);
    }
}