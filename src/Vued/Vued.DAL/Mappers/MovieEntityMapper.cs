using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vued.DAL.Entities;

namespace Vued.DAL.Mappers
{
    public class MovieEntityMapper : IEntityMapper<Movie>
    {
        public void MapToExistingEntity(Movie existingEntity, Movie newEntity)
        {
            existingEntity.Id = newEntity.Id;
            existingEntity.Name = newEntity.Name;
            existingEntity.Description = newEntity.Description;
            existingEntity.Status = newEntity.Status;
            existingEntity.Duration = newEntity.Duration;
            existingEntity.Director = newEntity.Director;
            existingEntity.ReleaseDate = newEntity.ReleaseDate;
            existingEntity.Rating = newEntity.Rating;
            existingEntity.URL = newEntity.URL;
            existingEntity.Favourite = newEntity.Favourite;
            existingEntity.Watchlists = newEntity.Watchlists;
            existingEntity.Genres = newEntity.Genres;
        }
    }
}
