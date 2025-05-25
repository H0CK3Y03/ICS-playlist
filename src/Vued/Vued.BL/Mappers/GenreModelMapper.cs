using Vued.BL.Models;
using Vued.DAL.Entities;

namespace Vued.BL.Mappers;

public class GenreModelMapper
    : ModelMapperBase<GenreEntity, GenreListModel, GenreDetailModel>
{
    public override GenreListModel MapToListModel(GenreEntity? entity)
        => entity is null
            ? GenreListModel.Empty
            : new GenreListModel
            {
                Id = entity.Id,
                Name = entity.Name
            };

    public override GenreDetailModel MapToDetailModel(GenreEntity entity)
        => new GenreDetailModel
        {
            Id = entity.Id,
            Name = entity.Name,
            MediaFileTitles = entity.MediaFileGenres?
                .Select(mfg => mfg.MediaFile.Name)
                .ToList() ?? new()
        };

    public override GenreEntity MapToEntity(GenreDetailModel model)
        => new GenreEntity
        {
            Id = model.Id,
            Name = model.Name,
            MediaFileGenres = []
        };
}
