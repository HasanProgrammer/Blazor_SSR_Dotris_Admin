using Karami.UseCase.Commons.Contracts.Interfaces;

namespace Karami.UseCase.RoleUseCase.Queries.ReadOne;

public class ReadOneQueryHandler : IQueryHandler<ReadOneQuery, string>
{
    public ReadOneQueryHandler()
    {
        
    }

    public Task<string> HandleAsync(ReadOneQuery query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}