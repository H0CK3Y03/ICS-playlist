using Vued.BL.Models;
using Vued.DAL.Entities;

namespace Vued.BL.Mappers;

public class GenreModelMapper : ModelMapperBase<Genre, GenreListModel, GenreDetailModel>
{
    public override GenreListModel MapToListModel(Genre? entity) => entity is null
        ? GenreListModel.Empty
        : new GenreListModel
        {
            Id = entity.Id,
            Name = entity.Name
        };

    public override GenreDetailModel MapToDetailModel(Genre? entity) => entity is null
        ? GenreDetailModel.Empty
        : new GenreDetailModel
        {
            Id = entity.Id,
            Name = entity.Name
        };

    public override Genre MapToEntity(GenreDetailModel model) => new()
    {
        Id = model.Id,
        Name = model.Name
    };
}
