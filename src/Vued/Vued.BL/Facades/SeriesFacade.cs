using Vued.BL.Mappers;
using Vued.BL.Models;
using Vued.DAL.Entities;
using Vued.DAL.Mappers;
using Vued.DAL.UnitOfWork;

namespace Vued.BL.Facades;

public class SeriesFacade(
    IUnitOfWorkFactory unitOfWorkFactory,
    SeriesModelMapper modelMapper)
    : FacadeBase<SeriesEntity, SeriesListModel, SeriesDetailModel, SeriesEntityMapper>(
            unitOfWorkFactory, modelMapper),
        ISeriesFacade
{
    protected override ICollection<string> IncludesNavigationPathDetail =>
        new[] { nameof(SeriesEntity.MediaFileGenres), nameof(SeriesEntity.WatchlistMediaFiles) };
}
