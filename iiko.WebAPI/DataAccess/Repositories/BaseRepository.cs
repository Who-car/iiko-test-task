using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebAPI.Abstractions.Repositories;
using WebAPI.Configurations.Exceptions;
using WebAPI.Entities;

namespace WebAPI.DataAccess.Repositories;

public abstract class BaseRepository<TEntity>(AppDbContext appDbContext) 
    : IRepository<TEntity> where TEntity : BaseEntity
{
    public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var set = appDbContext.Set<TEntity>();
        var result = await set.AddAsync(entity, cancellationToken);
        return result.Entity;
    }

    public async Task AddRangeAsync(List<TEntity> entities, CancellationToken cancellationToken = default)
    {
        var set = appDbContext.Set<TEntity>();
        await set.AddRangeAsync(entities, cancellationToken);
    }

    public virtual TEntity Update(TEntity entity)
    {
        var set = appDbContext.Set<TEntity>();
        var found = set.FirstOrDefault(e => e.Id == entity.Id);
        if (found is null)
            throw new EntityNotFoundException(typeof(TEntity), entity.Id.ToString());
        
        var result = set.Update(entity);
        return result.Entity;
    }

    public virtual TEntity Delete(long entityId)
    {
        var set = appDbContext.Set<TEntity>();
        var entity = set.FirstOrDefault(e => e.Id == entityId);
        if (entity is null)
            throw new EntityNotFoundException(typeof(TEntity), entityId.ToString());

        var result = set.Remove(entity);
        return result.Entity;
    }

    public async Task<bool> CheckIfExistsAsync(long entityId)
    {
        var set = appDbContext.Set<TEntity>();
        var entity = await set.FindAsync(entityId);

        return entity is null;
    }

    public virtual async Task<TEntity> GetByIdAsync(long entityId, CancellationToken cancellationToken = default)
    {
        var set = appDbContext.Set<TEntity>();
        var result = await set.FirstOrDefaultAsync(
            e => e.Id == entityId, 
            cancellationToken: cancellationToken
        );
        
        if (result is null)
            throw new EntityNotFoundException(typeof(TEntity), entityId.ToString());
        
        return result;
    }
    
    public virtual async Task<List<TEntity>> GetAsync(
        int amount = 0,
        List<Expression<Func<TEntity, bool>>>? filters = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        CancellationToken cancellationToken = default
    )
    {
        var query = appDbContext.Set<TEntity>().AsQueryable();

        if (filters is not null)
            foreach (var filter in filters)
                query = query.Where(filter);

        if (orderBy is not null)
            query = orderBy(query);

        if (amount != 0)
            query = query.Take(amount);

        return await query.ToListAsync(cancellationToken);
    }
}