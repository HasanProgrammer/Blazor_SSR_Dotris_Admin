using System.Text;
using Karami.Common.ClassExtensions;
using Karami.Domain.Commons.Contracts.Interfaces;
using Karami.Domain.Event.Entities;
using Karami.Domain.Role.Entities;
using Karami.Domain.Role.Events;
using Karami.UseCase.RoleUseCase.Contracts.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Action = Karami.Common.ClassConsts.Action;

namespace Karami.Infrastructure.Implementations.UseCase.Services;

//Singleton
public class RabbitRoleEventBus : IRoleEventBus
{
    private readonly IConnection _Connection;
    private readonly IModel      _Channel;
    private readonly string      _RoleQueue;

    private readonly IHostEnvironment     _HostEnvironment;
    private readonly IServiceScopeFactory _ServiceScopeFactory;

    private IUnitOfWork       _UnitOfWork;
    private CancellationToken _CancellationToken;

    public RabbitRoleEventBus(
        IConfiguration       Configuration   ,
        IHostEnvironment     HostEnvironment ,
        IServiceScopeFactory ServiceScopeFactory
    )
    {
        _RoleQueue = Configuration.GetValue<string>("RabbitMQ:Queues:Role_Queue");
        
        ConnectionFactory factory = new ConnectionFactory {
            HostName = Configuration.GetValue<string>("RabbitMQ:HostName"),
            UserName = Configuration.GetValue<string>("RabbitMQ:Username"),
            Password = Configuration.GetValue<string>("RabbitMQ:Password")
        };

        _Connection = factory.CreateConnection();
        _Channel    = _Connection.CreateModel();

        _HostEnvironment     = HostEnvironment;
        _ServiceScopeFactory = ServiceScopeFactory;
    }

    public async Task SubscribeAsync(CancellationToken cancellationToken)
    {
        _CancellationToken = cancellationToken;
        
        try
        {
            EventingBasicConsumer Consumer = new(_Channel);

            Consumer.Received += _eventSubscriber;

            _Channel.BasicConsume(queue: _RoleQueue, consumer: Consumer);
        }
        catch (Exception e)
        {
            await e.FileLoggerAsync(_HostEnvironment);
            
            if(_UnitOfWork is not null)
                await _UnitOfWork.RollbackAsync(cancellationToken);
        }
    }

    public void Dispose()
    {
        _Connection.Close();
        _Connection.Dispose();
    }
    
    /*---------------------------------------------------------------*/

    private void _eventSubscriber(object sender , BasicDeliverEventArgs args)
    {
        string message = Encoding.UTF8.GetString(args.Body.ToArray());

        message.EventLogger(_HostEnvironment);

        Event @event = JsonConvert.DeserializeObject<Event>(message);
        
        using IServiceScope ServiceScope = _ServiceScopeFactory.CreateScope();

        _UnitOfWork = ServiceScope.ServiceProvider.GetService<IUnitOfWork>();
        
        _UnitOfWork.Transaction();

        switch (@event.Action)
        {
            case Action.Create : _createRole(@event); break;
            case Action.Update : _updateRole(@event); break;
            case Action.Delete : _deleteRole(@event); break;
        }
            
        _UnitOfWork.Commit();
        
        _Channel.BasicAck(args.DeliveryTag, false); //Consume Message Of Queue & Delete This Message From Queue
    }

    private void _createRole(Event @event)
    {
        var roleCreated = @event.Payload.DeSerialize<RoleCreated>();

        var newRole = new Role(roleCreated.Id, roleCreated.Name);

        _UnitOfWork.RoleCommandRepository().Add(newRole);
    }
    
    private void _updateRole(Event @event)
    {
        var roleUpdated = @event.Payload.DeSerialize<RoleUpdated>();
        var targetRole  = _UnitOfWork.RoleQueryRepository().FindByIdAsync(roleUpdated.Id, _CancellationToken).Result;

        if (targetRole is not null)
        {
            targetRole.Change(roleUpdated.Name);

            _UnitOfWork.RoleCommandRepository().Change(targetRole);
        }
    }
    
    private void _deleteRole(Event @event)
    {
        var roleDeleted = @event.Payload.DeSerialize<RoleDeleted>();
        var targetRole  = _UnitOfWork.RoleQueryRepository().FindByIdEagerLoadingAsync(roleDeleted.Id, _CancellationToken).Result;
        
        if (targetRole is not null)
        {
            _UnitOfWork.PermissionCommandRepository().RemoveRange(targetRole.Permissions);
            _UnitOfWork.RoleCommandRepository().Remove(targetRole);
        }
    }
}