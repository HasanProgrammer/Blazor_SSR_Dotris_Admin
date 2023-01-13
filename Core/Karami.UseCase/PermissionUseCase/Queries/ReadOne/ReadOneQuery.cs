using Karami.UseCase.Commons.Contracts.Interfaces;

namespace Karami.UseCase.PermissionUseCase.Queries.ReadOne;

public class ReadOneQuery : IQuery<string>
{
    public string RoleId { get; set; }
}