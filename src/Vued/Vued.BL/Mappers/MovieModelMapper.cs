using Vued.BL.Models;
using Vued.DAL.Entities;

namespace Vued.BL.Mappers;

public class MovieModelMapper
    : ModelMapperBase<MovieEntity, MovieListModel, MovieDetailModel>
{
    public override MovieListModel MapToListModel(MovieEntity? entity)
        => entity is null
            ? MovieListModel.Empty
            : new MovieListModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Director = entity.Director,
                ReleaseDate = entity.ReleaseDate,
                Status = entity.Status,
                Favourite = entity.Favourite,
                Length = entity.Length
            };

    public override MovieDetailModel MapToDetailModel(MovieEntity entity)
        => new MovieDetailModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Director = entity.Director,
            Duration = entity.Duration,
            Status = entity.Status,
            ReleaseDate = entity.ReleaseDate,
            Rating = entity.Rating,
            URL = entity.URL,
            Favourite = entity.Favourite,
            Length = entity.Length,
            GenreNames = entity.MediaFileGenres?
                .Select(mfg => mfg.Genre.Name)
                .ToList() ?? new()
        };

    public override MovieEntity MapToEntity(MovieDetailModel model)
        => new MovieEntity
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            Director = model.Director,
            Duration = model.Duration,
            Status = model.Status,
            ReleaseDate = model.ReleaseDate,
            Rating = model.Rating,
            URL = model.URL ?? string.Empty,
            Favourite = model.Favourite,
            Length = model.Length,
            MediaFileGenres = []
        };
}
