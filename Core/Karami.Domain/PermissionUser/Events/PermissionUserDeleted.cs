using Karami.Domain.Commons.Contracts.Interfaces;

namespace Karami.Domain.PermissionUser.Events;

public class PermissionUserDeleted : IDomainEvent
{
    public string Id { get; init; }
}