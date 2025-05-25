using Vued.BL.Mappers;
using Vued.BL.Models;
using Vued.DAL.Entities;
using Vued.DAL.Mappers;
using Vued.DAL.UnitOfWork;

namespace Vued.BL.Facades;

public class MediaFileFacade(
    IUnitOfWorkFactory unitOfWorkFactory,
    MediaFileModelMapper modelMapper)
    : FacadeBase<MediaFileEntity, MediaFileListModel, MediaFileDetailModel, MediaFileEntityMapper>(
            unitOfWorkFactory, modelMapper),
        IMediaFileFacade
{
    protected override ICollection<string> IncludesNavigationPathDetail =>
        new[] { nameof(MediaFileEntity.WatchlistMediaFiles), nameof(MediaFileEntity.MediaFileGenres) };
}
