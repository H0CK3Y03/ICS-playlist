using BL.Models;
using DAL.Entities;
namespace BL.Mappers;
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
