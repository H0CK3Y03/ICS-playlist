/*
using BL.Models;
using Domain.Entities;

namespace BL.Mappers;

public class GenreModelMapper : ModelMapperBase<Genre, GenreListModel, GenreDetailModel>
{
    // Entity → ListModel
    public override GenreListModel MapToListModel(Genre? entity)
    {
        => entity is null
            ? GenreListModel.Empty
            : new GenreListModel { Id = entity.Id, Name = entity.Name };

    }

    // Entity → DetailModel
    public static GenreLDetailModel MapToDetailModel(Genre? entity)
    {
        => entity is null
            ? GenreDetailModel.Empty
            : new GenreDetailModel
            {
                Id = entity.Id, Name = entity.Name, MediaFileTitles = entity.MediaFiles.Select(m => m.Name).ToList()

            };

    }

    // DetailModel → Entity
    public override Genre MapToEntity(GenreDetailModel model)
    {
        => new() { Id = model.Id, Name = model.Name, MediaFileTitles = model.MediaFiles.Select(m => m.Name).ToList() };
    }
}
*/
using BL.Models;
using Domain.Entities;
namespace BL.Mappers;
public class GenreModelMapper : ModelMapperBase<Genre, GenreListModel, GenreDetailModel>
{
    // Entity → ListModel
    public override GenreListModel MapToListModel(Genre? entity)
        => entity is null
            ? GenreListModel.Empty
            : new GenreListModel
            {
                Id = entity.Id,
                Name = entity.Name
            };

    // Entity → DetailModel
    public override GenreDetailModel MapToDetailModel(Genre? entity)
        => entity is null
            ? GenreDetailModel.Empty
            : new GenreDetailModel
            {
                Id = entity.Id,
                Name = entity.Name,
                MediaFileTitles = entity.MediaFiles.Select(m => m.Name).ToList()
            };

    // DetailModel → Entity
    public override Genre MapToEntity(GenreDetailModel model)
        => new Genre
        {
            Id = model.Id,
            Name = model.Name,
            MediaFiles = new List<MediaFile>() // prázdny zoznam, môžeš neskôr napojiť mapper
        };
}
