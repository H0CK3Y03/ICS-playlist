using Vued.BL.Models;
using Vued.DAL.Entities;

namespace Vued.BL.Mappers;

public class GenreModelMapper
{
    public GenreListModel MapToListModel(Genre entity)
    {
        return new GenreListModel
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }

    public GenreDetailModel MapToDetailModel(Genre entity)
    {
        return new GenreDetailModel
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }

    public Genre MapToEntity(GenreDetailModel model)
    {
        return new Genre
        {
            Id = model.Id,
            Name = model.Name
        };
    }
}
