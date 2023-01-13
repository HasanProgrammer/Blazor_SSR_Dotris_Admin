using Karami.Domain.Commons.Contracts.Interfaces;

namespace Karami.Domain.User.Events;

public class UserInActived : IDomainEvent
{
    public string Id     { get; init; }
    public bool IsActive { get; init; }
}