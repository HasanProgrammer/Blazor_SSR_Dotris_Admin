using Karami.Domain.Commons.Contracts.Interfaces;

namespace Karami.Domain.Role.Events;

public class RoleDeleted : IDomainEvent
{
    public string Id { get; set; }
}