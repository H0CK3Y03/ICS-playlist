using Vued.DAL.Entities;

namespace Vued.DAL.Mappers;

public class SeriesEntityMapper : IEntityMapper<SeriesEntity>
{
    public void MapToExistingEntity(SeriesEntity existingEntity, SeriesEntity newEntity)
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
        existingEntity.NumberOfEpisodes = newEntity.NumberOfEpisodes;
    }
}
