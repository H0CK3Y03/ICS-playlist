using Vued.BL.Models;
using Vued.DAL.Entities;

namespace Vued.BL.Mappers;

public class WatchlistModelMapper : ModelMapperBase<Watchlist, WatchlistModel>
{
    public override WatchlistModel MapToModel(Watchlist? entity) => entity is null
        ? WatchlistModel.Empty
        : new WatchlistModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            MediaFileTitles = entity.MediaFiles.Select(m => m.Name).ToList()
        };

    public override Watchlist MapToEntity(WatchlistModel model) => new()
    {
        Id = model.Id,
        Name = model.Name,
        Description = model.Description,
        MediaFiles = new List<MediaFile>()
    };
}
