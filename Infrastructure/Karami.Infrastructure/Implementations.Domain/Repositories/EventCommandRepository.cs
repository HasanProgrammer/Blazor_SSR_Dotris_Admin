using Karami.Domain.Entity.Contracts.Interfaces;
using Karami.Domain.Event.Entities;
using Karami.Persistence.Contexts;

namespace Karami.Infrastructure.Implementations.Domain;

public class EventCommandRepository : IEventCommandRepository
{
    private readonly SQLContext _Context;

    public EventCommandRepository(SQLContext Context) => _Context = Context;

    public async Task AddAsync(Event entity, CancellationToken cancellationToken) 
        => await _Context.Events.AddAsync(entity, cancellationToken);

    public void Change(Event entity) => _Context.Events.Update(entity);
}