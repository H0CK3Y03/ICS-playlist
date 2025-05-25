using System;
using System.Threading.Tasks;
using Vued.DAL.Entities;
using Vued.DAL.Mappers;
using Vued.DAL.Repositories;

namespace Vued.DAL.UnitOfWork;

public interface IUnitOfWork : IAsyncDisposable
{
    IRepository<TEntity> GetRepository<TEntity, TEntityMapper>()
        where TEntity : class, IEntity
        where TEntityMapper : IEntityMapper<TEntity>, new();

    Task CommitAsync();
}
