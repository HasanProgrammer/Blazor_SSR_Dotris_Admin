using Karami.Domain.Commons.Contracts.Abstracts;
using Karami.Domain.Commons.Enumerations;

namespace Karami.Domain.Commons.Contracts.Interfaces;

public interface IQueryRepository<TEntity, TIdentity> where TEntity : BaseEntity<TIdentity>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public TEntity FindById(object id) => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<TEntity> FindByIdAsync(object id, CancellationToken cancellationToken) 
        => throw new NotImplementedException();
    
    /*-----------------------------------------------------------*/
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public TEntity FindByIdEagerLoading(object id) => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<TEntity> FindByIdEagerLoadingAsync(object id, CancellationToken cancellationToken) 
        => throw new NotImplementedException();
    
    /*-----------------------------------------------------------*/
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public TEntity FindByIdActive(object id) => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<TEntity> FindByIdActiveAsync(object id, CancellationToken cancellationToken) 
        => throw new NotImplementedException();
    
    /*-----------------------------------------------------------*/
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public TEntity FindByIdActiveEagerLoading(object id) => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<TEntity> FindByIdActiveEagerLoadingAsync(object id, CancellationToken cancellationToken) 
        => throw new NotImplementedException();
    
    /*-----------------------------------------------------------*/
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IEnumerable<TEntity> FindAll() => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<IEnumerable<TEntity>> FindAllAsync(CancellationToken cancellationToken) 
        => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="order"></param>
    /// <param name="accending"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IEnumerable<TEntity> FindAllWithOrdering(Order order, bool accending = true) 
        => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="order"></param>
    /// <param name="accending"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<IEnumerable<TEntity>> FindAllWithOrderingAsync(Order order, bool accending, 
        CancellationToken cancellationToken
    ) => throw new NotImplementedException();
    
    /*-----------------------------------------------------------*/
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IEnumerable<TEntity> FindAllEagerLoading() => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<IEnumerable<TEntity>> FindAllEagerLoadingAsync(CancellationToken cancellationToken) 
        => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="order"></param>
    /// <param name="accending"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IEnumerable<TEntity> FindAllEagerLoadingWithOrdering(Order order, bool accending) 
        => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="order"></param>
    /// <param name="accending"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<IEnumerable<TEntity>> FindAllEagerLoadingWithOrderingAsync(Order order, bool accending, 
        CancellationToken cancellationToken
    ) => throw new NotImplementedException();

    /*-----------------------------------------------------------*/

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IEnumerable<TEntity> FindAllActive() => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<IEnumerable<TEntity>> FindAllActiveAsync(CancellationToken cancellationToken) 
        => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="order"></param>
    /// <param name="accending"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IEnumerable<TEntity> FindAllActiveWithOrdering(Order order, bool accending = true) 
        => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="order"></param>
    /// <param name="accending"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<IEnumerable<TEntity>> FindAllActiveWithOrderingAsync(Order order, bool accending, 
        CancellationToken cancellationToken
    ) => throw new NotImplementedException();

    /*-----------------------------------------------------------*/
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IEnumerable<TEntity> FindAllActiveEagerLoading() => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<IEnumerable<TEntity>> FindAllActiveEagerLoadingAsync(CancellationToken cancellationToken) 
        => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="order"></param>
    /// <param name="accending"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IEnumerable<TEntity> FindAllActiveEagerLoadingWithOrdering(Order order, bool accending = true) 
        => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="order"></param>
    /// <param name="accending"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<IEnumerable<TEntity>> FindAllActiveEagerLoadingWithOrderingAsync(Order order, bool accending,
        CancellationToken cancellationToken
    ) => throw new NotImplementedException();
    
    /*-----------------------------------------------------------*/
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="countPerPage"></param>
    /// <param name="pageNumber"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IEnumerable<TEntity> FindAllWithPaginate(int countPerPage, int pageNumber) 
        => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="countPerPage"></param>
    /// <param name="pageNumber"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<IEnumerable<TEntity>> FindAllWithPaginateAsync(int countPerPage, int pageNumber, 
        CancellationToken cancellationToken
    ) => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="countPerPage"></param>
    /// <param name="pageNumber"></param>
    /// <param name="order"></param>
    /// <param name="accending"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IEnumerable<TEntity> FindAllWithPaginateAndOrdering(int countPerPage, int pageNumber, Order order, 
        bool accending
    ) => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="countPerPage"></param>
    /// <param name="pageNumber"></param>
    /// <param name="order"></param>
    /// <param name="accending"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<IEnumerable<TEntity>> FindAllWithPaginateAndOrderingAsync(int countPerPage, int pageNumber, Order order,
        bool accending, CancellationToken cancellationToken
    ) => throw new NotImplementedException();

    /*-----------------------------------------------------------*/
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="countPerPage"></param>
    /// <param name="pageNumber"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IEnumerable<TEntity> FindAllWithPaginateEagerLoading(int countPerPage, int pageNumber) 
        => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="countPerPage"></param>
    /// <param name="pageNumber"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<IEnumerable<TEntity>> FindAllWithPaginateEagerLoadingAsync(int countPerPage, int pageNumber, 
        CancellationToken cancellationToken
    ) => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="countPerPage"></param>
    /// <param name="pageNumber"></param>
    /// <param name="order"></param>
    /// <param name="accending"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IEnumerable<TEntity> FindAllWithPaginateEagerLoadingAndOrdering(int countPerPage, int pageNumber, Order order,
        bool accending
    ) => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="countPerPage"></param>
    /// <param name="pageNumber"></param>
    /// <param name="order"></param>
    /// <param name="accending"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<IEnumerable<TEntity>> FindAllWithPaginateEagerLoadingAndOrderingAsync(int countPerPage, int pageNumber, 
        Order order, bool accending, CancellationToken cancellationToken
    ) => throw new NotImplementedException();
    
    /*-----------------------------------------------------------*/
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="countPerPage"></param>
    /// <param name="pageNumber"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IEnumerable<TEntity> FindAllActiveWithPaginate(int countPerPage, int pageNumber) 
        => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="countPerPage"></param>
    /// <param name="pageNumber"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<IEnumerable<TEntity>> FindAllActiveWithPaginateAsync(int countPerPage, int pageNumber, 
        CancellationToken cancellationToken
    ) => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="countPerPage"></param>
    /// <param name="pageNumber"></param>
    /// <param name="order"></param>
    /// <param name="accending"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IEnumerable<TEntity> FindAllActiveWithPaginateAndOrdering(int countPerPage, int pageNumber, Order order,
        bool accending
    ) => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="countPerPage"></param>
    /// <param name="pageNumber"></param>
    /// <param name="order"></param>
    /// <param name="accending"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<IEnumerable<TEntity>> FindAllActiveWithPaginateAndOrderingAsync(int countPerPage, int pageNumber,
        Order order, bool accending, CancellationToken cancellationToken
    ) => throw new NotImplementedException();
    
    /*-----------------------------------------------------------*/
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="countPerPage"></param>
    /// <param name="pageNumber"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IEnumerable<TEntity> FindAllActiveWithPaginateEagerLoading(int countPerPage, int pageNumber) 
        => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="countPerPage"></param>
    /// <param name="pageNumber"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<IEnumerable<TEntity>> FindAllActiveWithPaginateEagerLoadingAsync(int countPerPage, int pageNumber, 
        CancellationToken cancellationToken
    ) => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="countPerPage"></param>
    /// <param name="pageNumber"></param>
    /// <param name="order"></param>
    /// <param name="accending"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IEnumerable<TEntity> FindAllActiveWithPaginateEagerLoadingAndOrdering(int countPerPage, int pageNumber, 
        Order order, bool accending
    ) => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="countPerPage"></param>
    /// <param name="pageNumber"></param>
    /// <param name="order"></param>
    /// <param name="accending"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<IEnumerable<TEntity>> FindAllActiveWithPaginateEagerLoadingAndOrderingAsync(int countPerPage, 
        int pageNumber, Order order, bool accending, CancellationToken cancellationToken
    ) => throw new NotImplementedException();
    
    /*-----------------------------------------------------------*/

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public long CountRows() => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public ValueTask<long> CountRowsAsync(CancellationToken cancellationToken) => throw new NotImplementedException();
}