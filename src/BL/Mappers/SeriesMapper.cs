using BL.Models;
using DAL.Entities;

namespace BL.Mappers;

public class SeriesMapper : ModelMapperBase<Series, SeriesListModel, SeriesDetailModel>
{
    public override SeriesListModel MapToListModel(Series? entity)
        => entity is null
            ? SeriesListModel.Empty
            : new SeriesListModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Director = entity.Director,
                ReleaseDate = entity.ReleaseDate,
                Status = entity.Status,
                Favourite = entity.Favourite,
                NumberOfEpisodes = entity.NumberOfEpisodes
            };

    public override SeriesDetailModel MapToDetailModel(Series? entity)
        => entity is null
            ? SeriesDetailModel.Empty
            : new SeriesDetailModel
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
                GenreNames = entity.Genres.Select(g => g.Name).ToList()
            };

    public override Series MapToEntity(SeriesDetailModel model)
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
            NumberOfEpisodes = model.NumberOfEpisodes,
            Genres = new List<Genre>()
        };
}
