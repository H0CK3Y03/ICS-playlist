using Vued.BL.Models;
using Vued.DAL.Entities;
using Vued.BL.Mappers;
using Microsoft.EntityFrameworkCore;
using Vued.DAL;
using Vued.BL.Queries;

namespace Vued.BL.Facades;

public class SeriesFacade
{
    private readonly AppDbContext _dbContext;
    private readonly SeriesModelMapper _mapper;

    public SeriesFacade(AppDbContext dbContext, SeriesModelMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<SeriesModel>> GetAllAsync()
    {
        var entities = await _dbContext.Series.ToListAsync();
        return entities
            .Select(entity => _mapper.MapToModel(entity))
            .ToList();
    }

    public async Task<List<SeriesModel>> FilterAsync(MovieFilterQuery filter)
    {
        IQueryable<Series> query = _dbContext.Series;
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

        var series = await query.ToListAsync();
        return series.Select(m => _mapper.MapToModel(m)).ToList();
    }

    public async Task<SeriesModel?> GetByIdAsync(int id)
    {
        var entity = await _dbContext.Series
            .Include(s => s.Genres)
            .FirstOrDefaultAsync(s => s.Id == id);

        return entity is null ? null : _mapper.MapToModel(entity);
    }

    public async Task<SeriesModel> SaveAsync(SeriesModel model)
    {
        var entity = await _dbContext.Series
            .Include(s => s.Genres)
            .FirstOrDefaultAsync(e => e.Id == model.Id);

        if (entity is null)
        {
            var newEntity = _mapper.MapToEntity(model);
            _dbContext.Series.Add(newEntity);
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
            entity.NumberOfEpisodes = model.NumberOfEpisodes;
            entity.Review = model.Review;
        }

        await _dbContext.SaveChangesAsync();
        return model;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _dbContext.Series.FirstOrDefaultAsync(e => e.Id == id);

        if (entity != null)
        {
            _dbContext.Series.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
