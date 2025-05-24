using System.IO;
using System.Xml.Linq;
using System;
using Vued.BL.Models;
using Vued.DAL.Entities;

namespace Vued.BL.Mappers;

public class MediaFileModelMapper : ModelMapperBase<MediaFile, MediaListModel, MediaFileDetailModel>

{
    public override MediaListModel MapToListModel(MediaFile entity) => entity is null
        ? MediaListModel.Empty
        : new MediaListModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Director = entity.Director,
            ReleaseDate = entity.ReleaseDate,
            Status = entity.Status,
            Favourite = entity.Favourite
        };

    public override MediaFileDetailModel MapToDetailModel(MediaFile entity) => entity is null
        ? MediaFileDetailModel.Empty
        : new MediaFileDetailModel
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
            Favourite = entity.Favourite,
            GenreNames = entity.Genres.Select(g => g.Name).ToList()
        };

    public override MediaFile MapToEntity(MediaFileDetailModel model)
    {
        return model.MediaType switch
        {
            MediaType.Movie => new Movie
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
                Favourite = model.Favourite,
                // Need to change Id = 0 to a proper ID logic (map from database)
                Genres = model.GenreNames.Select(name => new Genre { Id = 0, Name = name }).ToList()
            },
            MediaType.Series => new Series
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
                Favourite = model.Favourite,
                // Need to change Id = 0 to a proper ID logic (map from database 
                Genres = model.GenreNames.Select(name => new Genre { Id = 0, Name = name }).ToList()
            },

            _ => throw new ArgumentException("Unknown MediaFileDetailModel type.")

        };
    }
}
