using System;
using System.Threading.Tasks;
using Vued.DAL.Entities;
using Vued.DAL.Mappers;
using Vued.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Vued.DAL.UnitOfWork;

public sealed class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    private readonly AppDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public IRepository<TEntity> GetRepository<TEntity, TEntityMapper>()
        where TEntity : class, IEntity
        where TEntityMapper : IEntityMapper<TEntity>, new()
        => new Repository<TEntity>(_dbContext, new TEntityMapper());

    public async Task CommitAsync() =>
        await _dbContext.SaveChangesAsync().ConfigureAwait(false);

    public async ValueTask DisposeAsync() =>
        await _dbContext.DisposeAsync().ConfigureAwait(false);
}
