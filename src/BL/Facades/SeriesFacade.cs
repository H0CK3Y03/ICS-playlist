using BL.Models;
using Domain.Entities;
using BL.Mappers;

namespace BL.Facades;

public class SeriesFacade(
    //IUnitOfWorkFactory unitOfWorkFactory,
    SeriesModelMapper seriesModelMapper)
    : ISeriesFacade
{
    public async Task SaveAsync(SeriesListModel model)
    {
        var detail = await GetAsync(model.Id) ?? new SeriesDetailModel { Id = model.Id, Name = model.Name };
        await SaveAsync(detail);
    }

    public async Task SaveAsync(SeriesDetailModel model)
    {
        var entity = seriesModelMapper.MapToEntity(model);

        await using var uow = unitOfWorkFactory.Create();
        var repository = uow.GetRepository<Series, SeriesEntityMapper>();

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

    public async Task<SeriesDetailModel?> GetAsync(Guid id)
    {
        await using var uow = unitOfWorkFactory.Create();
        var entity = await uow.GetRepository<Series, SeriesEntityMapper>()
            .Get()
            .SingleOrDefaultAsync(e => e.Id == id);

        return entity is null ? null : seriesModelMapper.MapToDetailModel(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await using var uow = unitOfWorkFactory.Create();
        await uow.GetRepository<Series, SeriesEntityMapper>().DeleteAsync(id);
        await uow.CommitAsync();
    }
}
