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
            try
            {
                System.Diagnostics.Debug.WriteLine($"Starting filter application with: {filter}");

                if (!string.IsNullOrWhiteSpace(filter.TitleContains))
                {
                    query = query.Where(m => m.Name.Contains(filter.TitleContains));
                    System.Diagnostics.Debug.WriteLine($"Applied title filter: {filter.TitleContains}");
                }

                if (!string.IsNullOrWhiteSpace(filter.DirectorContains))
                {
                    query = query.Where(m => m.Director.Contains(filter.DirectorContains));
                    System.Diagnostics.Debug.WriteLine($"Applied director filter: {filter.DirectorContains}");
                }

                // FIXED: Genre filtering with proper null checking and debugging
                if (!string.IsNullOrWhiteSpace(filter.Genre))
                {
                    System.Diagnostics.Debug.WriteLine($"Applying genre filter: '{filter.Genre}'");
                    
                    // Make sure the genre comparison is case-insensitive and handles potential null genres
                    query = query.Where(m => m.Genres != null && 
                                           m.Genres.Any(g => g != null && 
                                                           g.Name != null && 
                                                           g.Name.ToLower() == filter.Genre.ToLower()));
                    
                    System.Diagnostics.Debug.WriteLine("Genre filter applied successfully");
                }

                // FIXED: Release year filtering - changed from exact match to minimum year
                if (filter.ReleaseYear.HasValue)
                {
                    System.Diagnostics.Debug.WriteLine($"Applying release year filter (minimum): {filter.ReleaseYear}");
                    query = query.Where(m => m.ReleaseDate >= filter.ReleaseYear.Value);
                }

                if (filter.Status.HasValue)
                {
                    query = query.Where(m => m.Status == filter.Status);
                    System.Diagnostics.Debug.WriteLine($"Applied status filter: {filter.Status}");
                }

                if (filter.LengthMax.HasValue)
                {
                    query = query.Where(m => m.Length <= filter.LengthMax);
                    System.Diagnostics.Debug.WriteLine($"Applied length filter: {filter.LengthMax}");
                }

                if (filter.Favourite.HasValue)
                {
                    System.Diagnostics.Debug.WriteLine($"Applying favourite filter: {filter.Favourite}");
                    query = query.Where(m => m.Favourite == filter.Favourite.Value);
                }

                // IMPROVED: Sorting with better error handling
                if (!string.IsNullOrWhiteSpace(filter.SortBy))
                {
                    bool desc = filter.SortOrder?.ToLower() == "desc";
                    System.Diagnostics.Debug.WriteLine($"Applying sort: {filter.SortBy} {(desc ? "DESC" : "ASC")}");

                    query = filter.SortBy.ToLower() switch
                    {
                        "title" => desc ? query.OrderByDescending(m => m.Name) : query.OrderBy(m => m.Name),
                        "rating" => desc ? query.OrderByDescending(m => m.Rating) : query.OrderBy(m => m.Rating),
                        "year" => desc ? query.OrderByDescending(m => m.ReleaseDate) : query.OrderBy(m => m.ReleaseDate),
                        "director" => desc ? query.OrderByDescending(m => m.Director) : query.OrderBy(m => m.Director),
                        "favourite" => desc ? query.OrderByDescending(m => m.Favourite).ThenBy(m => m.Name) : query.OrderBy(m => m.Favourite).ThenBy(m => m.Name),
                        _ => query.OrderBy(m => m.Name) // Default fallback
                    };
                }

                System.Diagnostics.Debug.WriteLine("Filter application completed successfully");
                return query;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in ApplyFilter: {ex.Message}\nStackTrace: {ex.StackTrace}");
                throw; // Re-throw to propagate the error
            }
        }
    }
}
