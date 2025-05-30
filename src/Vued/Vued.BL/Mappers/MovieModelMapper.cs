using Vued.BL.Models;
using Vued.DAL.Entities;

namespace Vued.BL.Mappers;

public class MovieModelMapper : ModelMapperBase<Movie, MovieModel>
{
    public override MovieModel MapToModel(Movie? entity) => entity is null
        ? MovieModel.Empty
        : new MovieModel
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
            GenreNames = entity.Genres.Select(g => g.Name).ToList()
        };


    public override Movie MapToEntity(MovieModel model) => new()
    {
        Id = model.Id,
        Name = model.Name,
        Description = model.Description,
        Director = model.Director,
        Duration = model.Duration,
        Status = model.Status,
        ReleaseDate = model.ReleaseDate,
        Rating = model.Rating,
        URL = model.URL,
        Favourite = model.Favourite,
        Length = model.Length,
        //Genres = model.GenreNames.Select(name => new Genre { Id = 3, Name = name }).ToList() // TODO: Replace with actual genre IDs
    };
}
