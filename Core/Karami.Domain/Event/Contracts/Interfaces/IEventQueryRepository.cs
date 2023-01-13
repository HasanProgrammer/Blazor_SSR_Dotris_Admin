using Karami.Domain.Commons.Contracts.Interfaces;

namespace Karami.Domain.Entity.Contracts.Interfaces;

public interface IEventQueryRepository : IQueryRepository<Event.Entities.Event, string>
{
    
}