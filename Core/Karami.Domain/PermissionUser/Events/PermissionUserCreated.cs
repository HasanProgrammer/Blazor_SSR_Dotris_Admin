using Karami.Domain.Commons.Contracts.Interfaces;

namespace Karami.Domain.PermissionUser.Events;

public class PermissionUserCreated : IDomainEvent
{
    public string Id           { get; init; }
    public string UserId       { get; init; }
    public string PermissionId { get; init; }
}