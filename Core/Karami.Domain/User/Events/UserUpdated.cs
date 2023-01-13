using Karami.Domain.Commons.Contracts.Interfaces;

namespace Karami.Domain.User.Events;

public class UserUpdated : IDomainEvent
{
    public string Id                       { get; init; }
    public string FirstName                { get; init; }
    public string LastName                 { get; init; }
    public string Username                 { get; init; }
    public string Password                 { get; init; }
    public bool IsActive                   { get; init; }
    public IEnumerable<string> Roles       { get; init; }
    public IEnumerable<string> Permissions { get; init; }
}