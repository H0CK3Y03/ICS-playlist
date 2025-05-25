using Vued.BL.Models;
using Vued.DAL.Entities;

namespace Vued.BL.Mappers;

public class WatchlistModelMapper
    : ModelMapperBase<WatchlistEntity, WatchlistListModel, WatchlistDetailModel>
{
    public override WatchlistListModel MapToListModel(WatchlistEntity? entity)
        => entity is null
            ? WatchlistListModel.Empty
            : new WatchlistListModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                MediaCount = entity.WatchlistMediaFiles?.Count ?? 0
            };

    public override WatchlistDetailModel MapToDetailModel(WatchlistEntity entity)
        => new WatchlistDetailModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            MediaFileTitles = entity.WatchlistMediaFiles?
                .Select(wmf => wmf.MediaFile.Name)
                .ToList() ?? new List<string>()
        };

    public override WatchlistEntity MapToEntity(WatchlistDetailModel model)
        => new WatchlistEntity
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            WatchlistMediaFiles = []
        };
}
