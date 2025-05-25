using Vued.DAL.Entities;

namespace Vued.DAL.Mappers;

public class WatchlistMediaFileEntityMapper : IEntityMapper<WatchlistMediaFileEntity>
{
    public void MapToExistingEntity(WatchlistMediaFileEntity existingEntity, WatchlistMediaFileEntity newEntity)
    {
        existingEntity.WatchlistId = newEntity.WatchlistId;
        existingEntity.MediaFileId = newEntity.MediaFileId;
    }
}
