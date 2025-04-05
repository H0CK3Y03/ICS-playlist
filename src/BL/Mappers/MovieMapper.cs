using BL.Models;
using Domain.Entities;

namespace BL.Mappers;

public class MovieMapper : ModelMapperBase<Movie, MovieListModel, MovieDetailModel>
{
    public override MovieListModel MapToListModel(Movie? entity)
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

    public override MovieDetailModel MapToDetailModel(Movie? entity)
        => entity is null
            ? MovieDetailModel.Empty
            : new MovieDetailModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Status = entity.Status,
                Description = entity.Description,
                Duration = entity.Duration,
                Director = entity.Director,
                ReleaseDate = entity.ReleaseDate,
                Rating = entity.Rating,
                URL = entity.URL,
                Favourite = entity.Favourite,
                Length = entity.Length,
                GenreNames = entity.Genres.Select(g => g.Name).ToList()
            };

    public override Movie MapToEntity(MovieDetailModel model)
        => new()
        {
            Id = model.Id,
            Name = model.Name,
            Status = model.Status,
            Description = model.Description,
            Duration = model.Duration,
            Director = model.Director,
            ReleaseDate = model.ReleaseDate,
            Rating = model.Rating,
            URL = model.URL ?? string.Empty,
            Favourite = model.Favourite,
            Length = model.Length,
            Genres = new List<Genre>()
        };
}
