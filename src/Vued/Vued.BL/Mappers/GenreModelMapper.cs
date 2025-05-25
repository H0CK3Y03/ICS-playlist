using Vued.BL.Models;
using Vued.DAL.Entities;

namespace Vued.BL.Mappers;

public class GenreModelMapper : ModelMapperBase<Genre, GenreModel>
{
    //public override GenreListModel MapToListModel(Genre? entity) => entity is null
    //    ? GenreListModel.Empty
    //    : new GenreListModel
    //    {
    //        Id = entity.Id,
    //        Name = entity.Name
    //    };

    public override GenreModel MapToModel(Genre? entity) => entity is null
        ? GenreModel.Empty
        : new GenreModel
        {
            Id = entity.Id,
            Name = entity.Name
        };

    public override Genre MapToEntity(GenreModel model) => new()
    {
        Id = model.Id,
        Name = model.Name
    };
}
