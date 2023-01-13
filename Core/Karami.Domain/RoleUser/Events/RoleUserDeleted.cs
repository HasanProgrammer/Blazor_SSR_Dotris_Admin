using Karami.Domain.Commons.Contracts.Interfaces;

namespace Karami.Domain.RoleUser.Events;

public class RoleUserDeleted : IDomainEvent
{
    public string Id { get; set; }
}