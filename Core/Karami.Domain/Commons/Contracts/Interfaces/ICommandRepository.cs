using Karami.Domain.Commons.Contracts.Abstracts;

namespace Karami.Domain.Commons.Contracts.Interfaces;

public interface ICommandRepository<in TEntity, TIdentity> where TEntity : BaseEntity<TIdentity>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Add(TEntity entity) => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task AddAsync(TEntity entity, CancellationToken cancellationToken) => throw new NotImplementedException();
    
    /*-----------------------------------------------------------*/

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Change(TEntity entity) => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task ChangeAsync(TEntity entity, CancellationToken cancellationToken) => throw new NotImplementedException();

    /*-----------------------------------------------------------*/
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Remove(object id) => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task RemoveAsync(object id, CancellationToken cancellationToken) => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Remove(TEntity entity) => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task RemoveAsync(TEntity entity, CancellationToken cancellationToken) => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="ids"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void RemoveRange(IEnumerable<object> ids) => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="ids"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task RemoveRangeAsync(IEnumerable<object> ids, CancellationToken cancellationToken) 
        => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void RemoveRange(IEnumerable<TEntity> entity) => throw new NotImplementedException();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task RemoveRangeAsync(IEnumerable<TEntity> entity, CancellationToken cancellationToken) 
        => throw new NotImplementedException();
}