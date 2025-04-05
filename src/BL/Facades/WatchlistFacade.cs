using BL.Models;
using Domain.Entities;
using BL.Mappers;
using Microsoft.EntityFrameworkCore;

namespace BL.Facades;

public class WatchlistFacade(
    //IUnitOfWorkFactory unitOfWorkFactory,
    WatchlistModelMapper watchlistModelMapper)
    : IWatchlistFacade
{
    public async Task SaveAsync(WatchlistListModel model)
    {
        var detail = await GetAsync(model.Id) ?? new WatchlistDetailModel { Id = model.Id, Name = model.Name, Description = model.Description };
        await SaveAsync(detail);
    }

    public async Task SaveAsync(WatchlistDetailModel model)
    {
        var entity = watchlistModelMapper.MapToEntity(model);

        await using var uow = unitOfWorkFactory.Create();
        var repository = uow.GetRepository<Watchlist, WatchlistEntityMapper>();

        if (await repository.ExistsAsync(entity))
        {
            await repository.UpdateAsync(entity);
        }
        else
        {
            repository.Insert(entity);
        }

        await uow.CommitAsync();
    }

    public async Task<WatchlistDetailModel?> GetAsync(Guid id)
    {
        await using var uow = unitOfWorkFactory.Create();
        var entity = await uow.GetRepository<Watchlist, WatchlistEntityMapper>()
            .Get()
            .SingleOrDefaultAsync(e => e.Id == id);

        return entity is null ? null : watchlistModelMapper.MapToDetailModel(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await using var uow = unitOfWorkFactory.Create();
        await uow.GetRepository<Watchlist, WatchlistEntityMapper>().DeleteAsync(id);
        await uow.CommitAsync();
    }
}
