using System.IO;
using System.Xml.Linq;
using System;
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
            Favourite = entity.Favourite,
            Review = entity.Review,
            MediaType = entity is Movie ? MediaType.Movie : MediaType.Series,
            GenreNames = entity.Genres.Select(g => g.Name).ToList()
        };

    public override MediaFile MapToEntity(MediaFileModel model)
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
                Review = model.Review,
                //Genres = model.GenreNames.Select(name => new Genre { Id = 2, Name = name }).ToList() // TODO: Replace with actual genre IDs
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
                Review = model.Review,
                //Genres = model.GenreNames.Select(name => new Genre { Id = 1, Name = name }).ToList() // TODO: Replace with actual genre IDs
            },

            _ => throw new ArgumentException("Unknown MediaFileModel type.")

        };
    }
}
