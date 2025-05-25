using Vued.BL.Mappers;
using Vued.BL.Models;
using Vued.DAL.Entities;
using Vued.DAL.Mappers;
using Vued.DAL.UnitOfWork;

namespace Vued.BL.Facades;

public class MovieFacade(
    IUnitOfWorkFactory unitOfWorkFactory,
    MovieModelMapper modelMapper)
    : FacadeBase<MovieEntity, MovieListModel, MovieDetailModel, MovieEntityMapper>(
            unitOfWorkFactory, modelMapper),
        IMovieFacade
{
    protected override ICollection<string> IncludesNavigationPathDetail =>
        new[] { nameof(MovieEntity.MediaFileGenres), nameof(MovieEntity.WatchlistMediaFiles) };
}
