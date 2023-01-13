using Karami.Domain.Commons.Contracts.Interfaces;

namespace Karami.Domain.Role.Events;

public class RoleCreated : IDomainEvent
{
    public string Id   { get; init; }
    public string Name { get; init; }
}