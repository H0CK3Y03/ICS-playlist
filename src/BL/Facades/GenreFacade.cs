using BL.Models;
using Domain.Entities;
using BL.Mappers;

namespace BL.Facades;

public class GenreFacade(
    //IUnitOfWorkFactory unitOfWorkFactory,
    IModelMapper<Genre, GenreListModel, GenreDetailModel> modelMapper)
    : FacadeBase<Genre, GenreListModel, GenreDetailModel, GenreModelMapper>(unitOfWorkFactory, modelMapper),
      IGenreFacade
{
    public async Task SaveAsync(GenreListModel model)
    {
        var detail = await GetAsync(model.Id) ?? new GenreDetailModel { Id = model.Id, Name = model.Name };
        await SaveAsync(detail);
    }

    public async Task SaveAsync(GenreDetailModel model)
    {
        var entity = modelMapper.MapToEntity(model);

        await using var uow = UnitOfWorkFactory.Create();
        var repository = uow.GetRepository<Genre, GenreEntityMapper>();

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
}
