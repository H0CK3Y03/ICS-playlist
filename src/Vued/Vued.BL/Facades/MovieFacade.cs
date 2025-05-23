using System.Linq;
using Vued.BL.Models;
using Vued.DAL.Entities;
using Vued.BL.Mappers;
using Microsoft.EntityFrameworkCore;
using Vued.DAL;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Vued.BL.Queries;

namespace Vued.BL.Facades;

public class MovieFacade
{
    private readonly AppDbContext _dbContext;
    private readonly MovieModelMapper _mapper;

    public MovieFacade(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _mapper = new MovieModelMapper();
    }

    public async Task<List<MovieListModel>> GetAllAsync()
    {
        var movies = await _dbContext.Movies.ToListAsync();
        return movies.Select(m => _mapper.MapToListModel(m)).ToList();
    }
    public async Task<List<MovieListModel>> FilterAsync(MovieFilterQuery filter)
    {
        IQueryable<Movie> query = _dbContext.Movies;
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

        var movies = await query.ToListAsync();
        return movies.Select(m => _mapper.MapToListModel(m)).ToList();
    }

    public async Task<MovieDetailModel?> GetByIdAsync(int id)
    {
        var entity = await _dbContext.Movies
            .Include(m => m.Genres)
            .FirstOrDefaultAsync(m => m.Id == id);

        return entity is null ? null : _mapper.MapToDetailModel(entity);
    }

    public async Task<MovieDetailModel> SaveAsync(MovieDetailModel model)
    {
        var entity = await _dbContext.Movies
            .Include(m => m.Genres)
            .FirstOrDefaultAsync(e => e.Id == model.Id);

        if (entity is null)
        {
            var newEntity = _mapper.MapToEntity(model);
            _dbContext.Movies.Add(newEntity);
        }
        else
        {
            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.Director = model.Director;
            entity.Duration = model.Duration;
            entity.Status = model.Status;
            entity.ReleaseDate = model.ReleaseDate;
            entity.Rating = model.Rating;
            entity.URL = model.URL;
            entity.Favourite = model.Favourite;
            entity.Length = model.Length;
        }

        await _dbContext.SaveChangesAsync();
        return model;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _dbContext.Movies.FirstOrDefaultAsync(e => e.Id == id);

        if (entity != null)
        {
            _dbContext.Movies.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
