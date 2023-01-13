using Karami.Domain.Commons.Contracts.Interfaces;

namespace Karami.Domain.Permission.Events;

public class PermissionCreated : IDomainEvent
{
    public string Id     { get; init; }
    public string RoleId { get; init; }
    public string Name   { get; init; }
}