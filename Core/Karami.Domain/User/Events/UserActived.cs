using Karami.Domain.Commons.Contracts.Interfaces;

namespace Karami.Domain.User.Events;

public class UserActived : IDomainEvent
{
    public string Id     { get; init; }
    public bool IsActive { get; init; }
}