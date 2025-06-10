using Vued.DAL.Entities;


namespace Vued.BL.Services
{
    public record MovieFilter
    {
        public string? TitleContains { get; set; }
        public string? DirectorContains { get; set; }
        public string? Genre { get; set; }
        public int? ReleaseYear { get; set; }
        public bool? Favourite { get; set; }
        public int? LengthMax { get; set; }
        public MediaStatus? Status { get; set; }

        public string? SortBy { get; set; } = "title";
        public string? SortOrder { get; set; } = "asc";
    }

    public class MovieService
    {
        public IQueryable<MediaFile> ApplyFilter(IQueryable<MediaFile> query, MovieFilter filter)
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
                query = query.Where(m => m.Duration <= filter.LengthMax);
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
