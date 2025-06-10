using System;
using System.Linq;
using Vued.BL.Models;
using Vued.DAL.Entities;

namespace Vued.BL.Mappers;

public class MediaFileModelMapper : ModelMapperBase<MediaFile, MediaFileModel>
{
    public override MediaFileModel MapToModel(MediaFile entity) => entity is null
        ? MediaFileModel.Empty
        : new MediaFileModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Duration = entity.Duration,
            Director = entity.Director,
            ReleaseDate = entity.ReleaseDate,
            Status = entity.Status,
            Rating = entity.Rating,
            URL = entity.URL,
            ImageURL = entity.ImageURL,
            Favourite = entity.Favourite,
            Review = entity.Review,
            MediaType = entity.MediaType,
            GenreNames = entity.Genres?.Select(g => g.Name).ToList() ?? new List<string>()
        };

    public override MediaFile MapToEntity(MediaFileModel model) => new MediaFile
    {
        Id = model.Id,
        Name = model.Name,
        Description = model.Description,
        Duration = model.Duration,
        Director = model.Director,
        ReleaseDate = model.ReleaseDate,
        Status = model.Status,
        Rating = model.Rating,
        URL = model.URL,
        ImageURL = model.ImageURL,
        Favourite = model.Favourite,
        Review = model.Review,
        MediaType = model.MediaType
    };
}
