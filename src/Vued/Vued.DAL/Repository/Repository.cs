using System.Linq;
using System.Threading.Tasks;
using System;
using Vued.DAL.Entities;
using Vued.DAL.Mappers;
using Microsoft.EntityFrameworkCore;
using Vued.DAL.Repositories;

namespace CookBook.DAL.Repositories;

public class Repository<TEntity>(
    DbContext dbContext,
    IEntityMapper<TEntity> entityMapper)
    : IRepository<TEntity>
    where TEntity : class, IEntity
{
    private readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();

    public IQueryable<TEntity> Get() => _dbSet;

    public async ValueTask<bool> ExistsAsync(TEntity entity)
        => await _dbSet.AnyAsync(e => e.Id == entity.Id).ConfigureAwait(false);

    public TEntity Insert(TEntity entity)
        => _dbSet.Add(entity).Entity;

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        TEntity existingEntity = await _dbSet.SingleAsync(e => e.Id == entity.Id).ConfigureAwait(false);
        entityMapper.MapToExistingEntity(existingEntity, entity);
        return existingEntity;
    }

    public async Task DeleteAsync(int entityId)
        => _dbSet.Remove(await _dbSet.SingleAsync(i => i.Id == entityId).ConfigureAwait(false));
}
