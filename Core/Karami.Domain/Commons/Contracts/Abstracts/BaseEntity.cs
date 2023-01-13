namespace Karami.Domain.Commons.Contracts.Abstracts;

public abstract class BaseEntity<TIdentity>
{
    public TIdentity Id { get; protected set; }
}