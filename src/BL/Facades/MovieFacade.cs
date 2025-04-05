using BL.Models;
using Domain.Entities;
using BL.Mappers;

namespace BL.Facades;

public class MovieFacade(
    //IUnitOfWorkFactory unitOfWorkFactory,
    MovieModelMapper movieModelMapper)
    : IMovieFacade
{
    public async Task SaveAsync(MovieListModel model)
    {
        var detail = await GetAsync(model.Id) ?? new MovieDetailModel { Id = model.Id, Name = model.Name };
        await SaveAsync(detail);
    }

    public async Task SaveAsync(MovieDetailModel model)
    {
        var entity = movieModelMapper.MapToEntity(model);

        await using var uow = unitOfWorkFactory.Create();
        var repository = uow.GetRepository<Movie, MovieEntityMapper>();

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

    public async Task<MovieDetailModel?> GetAsync(Guid id)
    {
        await using var uow = unitOfWorkFactory.Create();
        var entity = await uow.GetRepository<Movie, MovieEntityMapper>()
            .Get()
            .SingleOrDefaultAsync(e => e.Id == id);

        return entity is null ? null : movieModelMapper.MapToDetailModel(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await using var uow = unitOfWorkFactory.Create();
        await uow.GetRepository<Movie, MovieEntityMapper>().DeleteAsync(id);
        await uow.CommitAsync();
    }
}
