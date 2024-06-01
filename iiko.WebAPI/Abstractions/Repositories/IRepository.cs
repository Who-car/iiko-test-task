using System.Linq.Expressions;
using WebAPI.Entities;

namespace WebAPI.Abstractions.Repositories;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    public Task<TEntity> GetByIdAsync(
        long entityId,
        CancellationToken cancellationToken = default
    );

    public Task<List<TEntity>> GetAsync(
        int amount = 0,
        List<Expression<Func<TEntity, bool>>>? filters = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        CancellationToken cancellationToken = default
    );
    
    public Task<TEntity> AddAsync(
        TEntity entity,
        CancellationToken cancellationToken = default
    );
    
    public Task AddRangeAsync(
        List<TEntity> entities,
        CancellationToken cancellationToken = default
    );
    
    public Task<bool> CheckIfExistsAsync(long entityId);
    public TEntity Update(TEntity entity);
    public TEntity Delete(long entityId);
}