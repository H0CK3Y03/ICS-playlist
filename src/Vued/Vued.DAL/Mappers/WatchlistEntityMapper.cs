using Vued.DAL.Entities;

namespace Vued.DAL.Mappers;

public class WatchlistEntityMapper : IEntityMapper<WatchlistEntity>
{
    public void MapToExistingEntity(WatchlistEntity existingEntity, WatchlistEntity newEntity)
    {
        existingEntity.Name = newEntity.Name;
        existingEntity.Description = newEntity.Description;
    }
}
