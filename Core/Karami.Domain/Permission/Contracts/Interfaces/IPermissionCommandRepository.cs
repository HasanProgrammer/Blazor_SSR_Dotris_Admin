using Karami.Domain.Commons.Contracts.Interfaces;

namespace Karami.Domain.Permission.Contracts.Interfaces;

public interface IPermissionCommandRepository : ICommandRepository<Entities.Permission, string>
{
    
}