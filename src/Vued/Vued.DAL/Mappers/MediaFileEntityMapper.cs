using Vued.DAL.Entities;

namespace Vued.DAL.Mappers;

public class MediaFileEntityMapper : IEntityMapper<MediaFile>
{
    public void MapToExistingEntity(MediaFile existingEntity, MediaFile newEntity)
    {
        existingEntity.Id = newEntity.Id;
        existingEntity.Name = newEntity.Name;
        existingEntity.Status = newEntity.Status;
        existingEntity.Description = newEntity.Description;
        existingEntity.Duration = newEntity.Duration;
        existingEntity.Director = newEntity.Director;
        existingEntity.ReleaseDate = newEntity.ReleaseDate;
        existingEntity.Rating = newEntity.Rating;
        existingEntity.URL = newEntity.URL;
        existingEntity.Favourite = newEntity.Favourite;
        existingEntity.Type = newEntity.Type;
        existingEntity.Review = newEntity.Review;
        existingEntity.ImageUrl = newEntity.ImageUrl;
        existingEntity.Watchlists = newEntity.Watchlists;
        existingEntity.Genres = newEntity.Genres;
    }
}