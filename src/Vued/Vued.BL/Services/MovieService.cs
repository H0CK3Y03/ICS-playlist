using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vued.BL.Queries;
using Vued.DAL.Entities;


namespace Vued.BL.Services
{
    public class MovieService
    {
        public IQueryable<Movie> ApplyFilter(IQueryable<Movie> query, MovieFilterQuery filter)
        {
            if (!string.IsNullOrWhiteSpace(filter.TitleContains))
            {
                query = query.Where(m => m.Name.Contains(filter.TitleContains));
            }

            if (!string.IsNullOrWhiteSpace(filter.DirectorContains))
            {
                query = query.Where(m => m.Director.Contains(filter.DirectorContains));
            }

            if (!string.IsNullOrWhiteSpace(filter.Genre))
            {
                query = query.Where(m => m.Genres.Any(g => g.Name == filter.Genre));
            }

            if (filter.ReleaseYear is not null)
            {
                query = query.Where(m => m.ReleaseDate == filter.ReleaseYear);
            }

            if (filter.Status is not null)
            {
                query = query.Where(m => m.Status == filter.Status);
            }

            if (filter.LengthMax is not null)
            {
                query = query.Where(m => m.Length <= filter.LengthMax);
            }

            if (filter.Favourite is not null)
            {
                query = query.Where(m => m.Favourite == filter.Favourite);
            }

            if (!string.IsNullOrWhiteSpace(filter.SortBy))
            {
                bool desc = filter.SortOrder?.ToLower() == "desc";

                query = filter.SortBy.ToLower() switch
                {
                    "title" => desc ? query.OrderByDescending(m => m.Name) : query.OrderBy(m => m.Name),
                    "rating" => desc ? query.OrderByDescending(m => m.Rating) : query.OrderBy(m => m.Rating),
                    "year" => desc ? query.OrderByDescending(m => m.ReleaseDate) : query.OrderBy(m => m.ReleaseDate),
                    "director" => desc ? query.OrderByDescending(m => m.Director) : query.OrderBy(m => m.Director),
                    _ => query
                };
            }

            return query;
        }
    }
}
