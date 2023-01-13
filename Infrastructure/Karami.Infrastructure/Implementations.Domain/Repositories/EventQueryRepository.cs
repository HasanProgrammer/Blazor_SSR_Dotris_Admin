using Karami.Domain.Entity.Contracts.Interfaces;
using Karami.Persistence.Contexts;

namespace Karami.Infrastructure.Implementations.Domain;

public class EventQueryRepository : IEventQueryRepository
{
    private readonly SQLContext _Context;
    
    public EventQueryRepository(SQLContext Context)
    {
        _Context = Context;
    }
}