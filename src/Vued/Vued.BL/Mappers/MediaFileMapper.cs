using Vued.BL.Models;
using Vued.DAL.Entities;

namespace Vued.BL.Mappers;

public class MediaFileModelMapper

{
    public MediaListModel MapToListModel(MediaFile entity)
    {
        return new MediaListModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Director = entity.Director,
            ReleaseDate = entity.ReleaseDate,
            Status = entity.Status,
            Favourite = entity.Favourite
        };
    }

    public MediaFileDetailModel MapToDetailModel(MediaFile entity)
    {
        return new MediaFileDetailModel
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
    }

    public MediaFile MapToEntity(MediaFileDetailModel model)
    {
        return new Movie
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
        };
    }
}
