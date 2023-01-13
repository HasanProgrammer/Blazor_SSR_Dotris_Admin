using Karami.Domain.Commons.Contracts.Interfaces;

namespace Karami.Domain.Role.Contracts.Interfaces;

public interface IRoleCommandRepository : ICommandRepository<Entities.Role, string>
{
    
}