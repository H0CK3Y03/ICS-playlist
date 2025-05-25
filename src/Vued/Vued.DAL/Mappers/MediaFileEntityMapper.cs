using Vued.DAL.Entities;

namespace Vued.DAL.Mappers;

public class MediaFileEntityMapper : IEntityMapper<MediaFileEntity>
{
    public void MapToExistingEntity(MediaFileEntity existingEntity, MediaFileEntity newEntity)
    {
        existingEntity.Name = newEntity.Name;
        existingEntity.Description = newEntity.Description;
        existingEntity.Duration = newEntity.Duration;
        existingEntity.Director = newEntity.Director;
        existingEntity.ReleaseDate = newEntity.ReleaseDate;
        existingEntity.Rating = newEntity.Rating;
        existingEntity.URL = newEntity.URL;
        existingEntity.Favourite = newEntity.Favourite;
        existingEntity.Status = newEntity.Status;
    }
}
