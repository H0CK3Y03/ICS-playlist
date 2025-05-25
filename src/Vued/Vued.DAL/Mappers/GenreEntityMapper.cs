using Vued.DAL.Entities;

namespace Vued.DAL.Mappers;

public class GenreEntityMapper : IEntityMapper<GenreEntity>
{
    public void MapToExistingEntity(GenreEntity existingEntity, GenreEntity newEntity)
    {
        existingEntity.Name = newEntity.Name;
    }
}
