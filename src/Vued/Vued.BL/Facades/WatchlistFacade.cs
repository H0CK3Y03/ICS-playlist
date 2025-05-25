using Vued.BL.Mappers;
using Vued.BL.Models;
using Vued.DAL.Entities;
using Vued.DAL.Mappers;
using Vued.DAL.UnitOfWork;

namespace Vued.BL.Facades;

public class WatchlistFacade(
    IUnitOfWorkFactory unitOfWorkFactory,
    WatchlistModelMapper modelMapper)
    : FacadeBase<WatchlistEntity, WatchlistListModel, WatchlistDetailModel, WatchlistEntityMapper>(
            unitOfWorkFactory, modelMapper),
        IWatchlistFacade
{
    protected override ICollection<string> IncludesNavigationPathDetail =>
        new[] { nameof(WatchlistEntity.WatchlistMediaFiles) };
}
