using Vued.DAL.Entities;

namespace Vued.DAL.Mappers;

public class MediaFileGenreEntityMapper : IEntityMapper<MediaFileGenreEntity>
{
    public void MapToExistingEntity(MediaFileGenreEntity existingEntity, MediaFileGenreEntity newEntity)
    {
        existingEntity.MediaFileId = newEntity.MediaFileId;
        existingEntity.GenreId = newEntity.GenreId;
    }
}
