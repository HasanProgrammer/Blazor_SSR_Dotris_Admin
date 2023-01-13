using Karami.Domain.Commons.Contracts.Interfaces;

namespace Karami.Domain.RoleUser.Events;

public class RoleUserCreated : IDomainEvent
{
    public string Id     { get; set; }
    public string RoleId { get; init; }
    public string UserId { get; init; }
}