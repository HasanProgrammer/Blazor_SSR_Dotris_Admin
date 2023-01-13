using Karami.Domain.Commons.Contracts.Interfaces;

namespace Karami.Domain.User.Contracts.Interfaces;

public interface IUserCommandRepository : ICommandRepository<Entities.User, string>
{
    
}