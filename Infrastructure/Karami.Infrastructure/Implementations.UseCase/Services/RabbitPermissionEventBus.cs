using System.Text;
using Karami.Common.ClassExtensions;
using Karami.Domain.Commons.Contracts.Interfaces;
using Karami.Domain.Event.Entities;
using Karami.Domain.Permission.Entities;
using Karami.Domain.Permission.Events;
using Karami.UseCase.PermissionUseCase.Contracts.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Action = Karami.Common.ClassConsts.Action;

namespace Karami.Infrastructure.Implementations.UseCase.Services;

//Singleton
public class RabbitPermissionEventBus : IPermissionEventBus
{
    #region Fields

    private readonly IConnection          _Connection;
    private readonly IModel               _Channel;
    private readonly string               _PermissionQueue;
    private readonly IHostEnvironment     _HostEnvironment;
    private readonly IServiceScopeFactory _ServiceScopeFactory;
    
    private IUnitOfWork       _UnitOfWork;
    private CancellationToken _CancellationToken;

    #endregion

    public RabbitPermissionEventBus(
        IConfiguration       Configuration   ,
        IHostEnvironment     HostEnvironment ,
        IServiceScopeFactory ServiceScopeFactory
    )
    {
        _PermissionQueue = Configuration.GetValue<string>("RabbitMQ:Queues:Permission_Queue");
        
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

            _Channel.BasicConsume(queue: _PermissionQueue, consumer: Consumer);
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
            case Action.Create : _createPermission(@event); break;
            case Action.Update : _updatePermission(@event); break;
            case Action.Delete : _deletePermission(@event); break;
        }
            
        _UnitOfWork.Commit();
        
        _Channel.BasicAck(args.DeliveryTag, false); //Consume Message Of Queue & Delete This Message From Queue
    }

    private void _createPermission(Event @event)
    {
        var permissionCreated = @event.Payload.DeSerialize<PermissionCreated>();
        
        var newPermission = new Permission(
            permissionCreated.Id   , 
            permissionCreated.Name , 
            permissionCreated.RoleId
        );

        _UnitOfWork.PermissionCommandRepository().Add(newPermission);
    }

    private void _updatePermission(Event @event)
    {
        var permissionUpdated = @event.Payload.DeSerialize<PermissionUpdated>();
        var targetPermission  = _UnitOfWork.PermissionQueryRepository()
                                           .FindByIdAsync(permissionUpdated.Id, _CancellationToken).Result;

        if (targetPermission is not null)
        {
            targetPermission.Change(
                permissionUpdated.Name ,
                permissionUpdated.RoleId
            );

            _UnitOfWork.PermissionCommandRepository().Change(targetPermission);
        }
    }

    private void _deletePermission(Event @event)
    {
        var permissionDeleted = @event.Payload.DeSerialize<PermissionDeleted>();
        var targetPermission  = _UnitOfWork.PermissionQueryRepository()
                                           .FindByIdAsync(permissionDeleted.Id, _CancellationToken).Result;
        
        if(targetPermission is not null)
            _UnitOfWork.PermissionCommandRepository().Remove(targetPermission);
    }
}