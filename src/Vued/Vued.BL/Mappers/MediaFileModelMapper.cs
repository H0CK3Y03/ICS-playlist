using Vued.BL.Models;
using Vued.DAL.Entities;

namespace Vued.BL.Mappers;

public class MediaFileModelMapper
    : ModelMapperBase<MediaFileEntity, MediaFileListModel, MediaFileDetailModel>
{
    public override MediaFileListModel MapToListModel(MediaFileEntity? entity)
        => entity is null
            ? MediaFileListModel.Empty
            : new MediaFileListModel
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
                Favourite = entity.Favourite
            };

    public override MediaFileDetailModel MapToDetailModel(MediaFileEntity entity)
        => new MediaFileDetailModel
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
            MediaType = entity switch
            {
                MovieEntity => MediaType.Movie,
                SeriesEntity => MediaType.Series,
                _ => throw new ArgumentException("Unknown MediaFileEntity type.")
            },
            GenreNames = entity.MediaFileGenres?
                .Select(mfg => mfg.Genre.Name)
                .ToList() ?? new()
        };

    public override MediaFileEntity MapToEntity(MediaFileDetailModel model)
        => model.MediaType switch
        {
            MediaType.Movie => new MovieEntity
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Duration = model.Duration,
                Director = model.Director,
                ReleaseDate = model.ReleaseDate,
                Status = model.Status,
                Rating = model.Rating,
                URL = model.URL ?? string.Empty,
                Favourite = model.Favourite,
                MediaFileGenres = []
            },

            MediaType.Series => new SeriesEntity
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Duration = model.Duration,
                Director = model.Director,
                ReleaseDate = model.ReleaseDate,
                Status = model.Status,
                Rating = model.Rating,
                URL = model.URL ?? string.Empty,
                Favourite = model.Favourite,
                MediaFileGenres = []
            },

            _ => throw new ArgumentException("Unknown MediaType in model.")
        };
}
