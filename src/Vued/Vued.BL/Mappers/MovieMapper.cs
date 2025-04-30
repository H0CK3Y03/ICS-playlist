using Vued.BL.Models;
using Vued.DAL.Entities;

namespace Vued.BL.Mappers;

public class MovieMapper
{
    public static MovieListModel MapToListModel(Movie entity) => new()
    {
        Id = entity.Id,
        Name = entity.Name,
        Director = entity.Director,
        ReleaseDate = entity.ReleaseDate,
        Status = entity.Status,
        Favourite = entity.Favourite,
        Length = entity.Length
    };


    public static MovieDetailModel MapToDetailModel(Movie entity) => new()
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


    public static Movie MapToEntity(MovieDetailModel model) => new()
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
        Genres = model.GenreNames.Select(name => new Genre { Name = name }).ToList()
    };
}
