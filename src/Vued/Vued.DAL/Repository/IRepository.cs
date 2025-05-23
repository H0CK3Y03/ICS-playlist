using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System;
using Vued.DAL.Entities;

namespace Vued.DAL.Repositories;

public interface IRepository<TEntity>
    where TEntity : class, IEntity
{
    IQueryable<TEntity> Get();
    Task DeleteAsync(int entityId);
    ValueTask<bool> ExistsAsync(TEntity entity);
    TEntity Insert(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
}
