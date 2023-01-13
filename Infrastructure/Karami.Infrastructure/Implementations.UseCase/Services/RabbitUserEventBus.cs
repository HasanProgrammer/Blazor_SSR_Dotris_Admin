using System.Text;
using Karami.Common.ClassExtensions;
using Karami.Domain.Commons.Contracts.Interfaces;
using Karami.Domain.Event.Entities;
using Karami.Domain.Permission.Entities;
using Karami.Domain.RoleUser.Entities;
using Karami.Domain.User.Entities;
using Karami.Domain.User.Events;
using Karami.UseCase.UserUseCase.Contracts.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Action = Karami.Common.ClassConsts.Action;

namespace Karami.Infrastructure.Implementations.UseCase.Services;

public class RabbitUserEventBus : IUserEventBus
{
    private readonly IConnection _connection;
    private readonly IModel      _channel;
    private readonly string      _userQueue;

    private readonly IHostEnvironment     _hostEnvironment;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    private IUnitOfWork       _unitOfWork;
    private CancellationToken _cancellationToken;

    public RabbitUserEventBus(
        IConfiguration       Configuration   ,
        IHostEnvironment     HostEnvironment ,
        IServiceScopeFactory ServiceScopeFactory
    )
    {
        _userQueue = Configuration.GetValue<string>("RabbitMQ:Queues:User_Queue");
        
        ConnectionFactory factory = new ConnectionFactory {
            HostName = Configuration.GetValue<string>("RabbitMQ:HostName"),
            UserName = Configuration.GetValue<string>("RabbitMQ:Username"),
            Password = Configuration.GetValue<string>("RabbitMQ:Password")
        };

        _connection = factory.CreateConnection();
        _channel    = _connection.CreateModel();

        _hostEnvironment     = HostEnvironment;
        _serviceScopeFactory = ServiceScopeFactory;
    }

    public async Task SubscribeAsync(CancellationToken cancellationToken)
    {
        _cancellationToken = cancellationToken;
        
        try
        {
            EventingBasicConsumer consumer = new(_channel);

            consumer.Received += _eventSubscriber;

            _channel.BasicConsume(queue: _userQueue, consumer: consumer);
        }
        catch (Exception e)
        {
            await e.FileLoggerAsync(_hostEnvironment);
            
            if(_unitOfWork is not null)
                await _unitOfWork.RollbackAsync(cancellationToken);
        }
    }

    public void Dispose()
    {
        _connection.Close();
        _connection.Dispose();
    }
    
    /*---------------------------------------------------------------*/

    private void _eventSubscriber(object sender , BasicDeliverEventArgs args)
    {
        string message = Encoding.UTF8.GetString(args.Body.ToArray());

        message.EventLogger(_hostEnvironment);

        Event @event = JsonConvert.DeserializeObject<Event>(message);
        
        using IServiceScope serviceScope = _serviceScopeFactory.CreateScope();

        _unitOfWork = serviceScope.ServiceProvider.GetService<IUnitOfWork>();
        
        _unitOfWork.Transaction();

        switch (@event.Action)
        {
            case Action.Create : _createUser(@event); break;
            case Action.Update : _updateUser(@event); break;
        }
            
        _unitOfWork.Commit();
        
        _channel.BasicAck(args.DeliveryTag, false); //Consume Message Of Queue & Delete This Message From Queue
    }

    private void _createUser(Event @event)
    {
        var userCreated = @event.Payload.DeSerialize<UserCreated>();
        
        var newUser = new User(
            userCreated.Id        , 
            userCreated.FirstName ,
            userCreated.LastName  ,
            userCreated.Username  ,
            userCreated.Password  ,
            userCreated.IsActive
        );

        _unitOfWork.UserCommandRepository().Add(newUser);
        
        _roleUserBuilder(userCreated.Id, userCreated.Roles);
        _permissionUserBuilder(userCreated.Id, userCreated.Permissions);
    }

    private void _updateUser(Event @event)
    {
        switch (@event.Type)
        {
            case nameof(UserUpdated) :
            {
                var userUpdated = @event.Payload.DeSerialize<UserUpdated>();
                var targetUser  = _unitOfWork.UserQueryRepository().FindByIdAsync(userUpdated.Id, _cancellationToken).Result;

                if (targetUser is not null)
                {
                    targetUser.Change(
                        userUpdated.FirstName ,
                        userUpdated.LastName  ,
                        userUpdated.Username  ,
                        userUpdated.Password  ,
                        userUpdated.IsActive
                    );
                    
                    _unitOfWork.UserCommandRepository().Change(targetUser);
                    
                    _roleUserBuilder(targetUser.Id, userUpdated.Roles);
                    _permissionUserBuilder(targetUser.Id, userUpdated.Permissions);
                }
            }
            break;
            
            case nameof(UserActived) :
            {
                var userActived = @event.Payload.DeSerialize<UserActived>();
                var targetUser  = _unitOfWork.UserQueryRepository().FindByIdAsync(userActived.Id, _cancellationToken).Result;

                if (targetUser is not null)
                {
                    targetUser.Active();
                    
                    _unitOfWork.UserCommandRepository().Change(targetUser);
                }
            }
            break;
            
            case nameof(UserInActived) :
            {
                var userInActived = @event.Payload.DeSerialize<UserInActived>();
                var targetUser    = _unitOfWork.UserQueryRepository().FindByIdAsync(userInActived.Id, _cancellationToken).Result;

                if (targetUser is not null)
                {
                    targetUser.InActive();
                    
                    _unitOfWork.UserCommandRepository().Change(targetUser);
                }
            }
            break;
        }
    }
    
    private void _roleUserBuilder(string userId , IEnumerable<string> roleIds)
    {
        //1 . Remove already user roles
        foreach (var roleUser in _unitOfWork.RoleUserQueryRepository().FindAllByUserIdAsync(userId, _cancellationToken).Result)
            _unitOfWork.RoleUserCommandRepository().Remove(roleUser);
        
        //2 . Assign new roles for user
        foreach (var roleId in roleIds)
        {
            var newRoleUser = new RoleUser(Guid.NewGuid().ToString(), userId, roleId);

            _unitOfWork.RoleUserCommandRepository().Add(newRoleUser);
        }
    }
    
    private void _permissionUserBuilder(string userId , IEnumerable<string> permissionIds)
    {
        //1 . Remove already user permissions
        foreach (var permissionUser in _unitOfWork.PermissionUserQueryRepository().FindAllByUserIdAsync(userId, _cancellationToken).Result)
            _unitOfWork.PermissionUserCommandRepository().Remove(permissionUser);
        
        //2 . Assign new permissions for user
        foreach (var permissionId in permissionIds)
        {
            var newPermissionUser = new PermissionUser(Guid.NewGuid().ToString(), userId, permissionId);

            _unitOfWork.PermissionUserCommandRepository().Add(newPermissionUser);
        }
    }
}