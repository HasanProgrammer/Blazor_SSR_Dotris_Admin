using Karami.Domain.Commons.Contracts.Interfaces;

namespace Karami.Domain.Entity.Contracts.Interfaces;

public interface IEventCommandRepository : ICommandRepository<Event.Entities.Event, string>
{
    
}