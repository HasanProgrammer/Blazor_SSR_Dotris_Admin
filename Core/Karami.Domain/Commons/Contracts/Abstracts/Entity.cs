#pragma warning disable CS0649
#pragma warning disable CS8632
#pragma warning disable CS0659

using System.Collections.ObjectModel;
using Karami.Domain.Commons.Contracts.Interfaces;
using Karami.Domain.Commons.ValueObjects;
using Karami.Domain.Commons.Enumerations;

namespace Karami.Domain.Commons.Contracts.Abstracts;

public abstract partial class Entity<TIdentity> : BaseEntity<TIdentity>
{
    public IsActive IsActive   { get; protected set; }
    public CreatedAt CreatedAt { get; protected set; }
    public UpdatedAt UpdatedAt { get; protected set; }
}

public abstract partial class Entity<TIdentity>
{
    private readonly List<IDomainEvent> _Events;

    protected Entity() => _Events = new();

    protected void AddEvent(IDomainEvent @event) => _Events.Add(@event);

    public ReadOnlyCollection<IDomainEvent> GetEvents => _Events.AsReadOnly();

    public void ClearEvents() => _Events.Clear();
}