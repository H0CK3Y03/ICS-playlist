using Vued.BL.Models;
using Vued.DAL.Entities;

namespace Vued.BL.Mappers;

public class SeriesModelMapper : ModelMapperBase<Series, SeriesModel>
{
    public override SeriesModel MapToModel(Series? entity) => entity is null
        ? SeriesModel.Empty
        : new SeriesModel
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
            NumberOfEpisodes = entity.NumberOfEpisodes,
            Review = entity.Review,
            GenreNames = entity.Genres.Select(g => g.Name).ToList()
        };

    public override Series MapToEntity(SeriesModel model) => new()
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
        NumberOfEpisodes = model.NumberOfEpisodes,
        Review = model.Review,
        Genres = new List<Genre>()
    };
}
