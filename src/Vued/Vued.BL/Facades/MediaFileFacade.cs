using Vued.BL.Models;
using Vued.BL.Mappers;
using Vued.DAL.Entities;
using Vued.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis;

namespace Vued.BL.Facades;

public class MediaFileFacade
{
    private readonly AppDbContext _dbContext;
    private readonly IModelMapper<MediaFile, MediaFileModel> _mapper;

    public MediaFileFacade(AppDbContext dbContext, IModelMapper<MediaFile, MediaFileModel> mapper)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<List<MediaFileModel>> GetAllAsync()
    {
        var movieEntities = await _dbContext.Movies.Include(m => m.Genres).ToListAsync();
        var seriesEntities = await _dbContext.Series.Include(s => s.Genres).ToListAsync();

        var entities = new List<MediaFile>();
        entities.AddRange(movieEntities);
        entities.AddRange(seriesEntities);

        return entities.Select(_mapper.MapToModel).ToList();
    }

    public async Task<MediaFileModel?> GetByIdAsync(int id)
    {
        var movie = await _dbContext.Movies
            .Include(m => m.Genres)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (movie is not null)
            return _mapper.MapToModel(movie);

        var series = await _dbContext.Series
            .Include(s => s.Genres)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (series is not null)
            return _mapper.MapToModel(series);

        return null;
    }

    public async Task<MediaFileModel> SaveAsync(MediaFileModel? model)
    {
        if (model == null)
            throw new ArgumentNullException(nameof(model), "Model cannot be null.");
        MediaFile? entity = await _dbContext.Movies
            .Include(m => m.Genres)
            .FirstOrDefaultAsync(m => m.Id == model.Id);

        if (entity == null)
        {
            entity = await _dbContext.Series
                .Include(s => s.Genres)
                .FirstOrDefaultAsync(s => s.Id == model.Id);
        }

        if (entity == null)
        {
            var newEntity = _mapper.MapToEntity(model);

            if (newEntity is Movie movie)
            {
                _dbContext.Movies.Add(movie);
            }
            else if (newEntity is Series series)
            {
                _dbContext.Series.Add(series);
            }
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
        }

        await _dbContext.SaveChangesAsync();

        return model;
    }

    public async Task DeleteAsync(int id)
    {
        var movie = await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == id);
        if (movie != null)
        {
            _dbContext.Movies.Remove(movie);
        }
        else
        {
            var series = await _dbContext.Series.FirstOrDefaultAsync(s => s.Id == id);
            if (series != null)
            {
                _dbContext.Series.Remove(series);
            }
            else
            {
                return;
            }
        }

        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<MediaFileModel>> FilterAsync(MovieFilterModel filter)
    {
        var movieQuery = _dbContext.Movies.Include(m => m.Genres).AsQueryable();
        var seriesQuery = _dbContext.Series.Include(s => s.Genres).AsQueryable();

        if (!string.IsNullOrEmpty(filter.Genre) && filter.Genre != "All")
        {
            movieQuery = movieQuery.Where(m => m.Genres.Any(g => g.Name == filter.Genre));
            seriesQuery = seriesQuery.Where(s => s.Genres.Any(g => g.Name == filter.Genre));
        }

        if (filter.Favourite == true)
        {
            movieQuery = movieQuery.Where(m => m.Favourite);
            seriesQuery = seriesQuery.Where(s => s.Favourite);
        }

        if (filter.ReleaseYear.HasValue)
        {
            movieQuery = movieQuery.Where(m => m.ReleaseDate >= filter.ReleaseYear.Value);
            seriesQuery = seriesQuery.Where(s => s.ReleaseDate >= filter.ReleaseYear.Value);
        }

        if (!string.IsNullOrWhiteSpace(filter.TitleContains) || !string.IsNullOrWhiteSpace(filter.DirectorContains))
        {
            var title = filter.TitleContains?.ToLower() ?? string.Empty;
            var director = filter.DirectorContains?.ToLower() ?? string.Empty;

            movieQuery = movieQuery.Where(m =>
                (!string.IsNullOrEmpty(title) && m.Name.ToLower().Contains(title)) ||
                (!string.IsNullOrEmpty(director) && m.Director.ToLower().Contains(director)));

            seriesQuery = seriesQuery.Where(s =>
                (!string.IsNullOrEmpty(title) && s.Name.ToLower().Contains(title)) ||
                (!string.IsNullOrEmpty(director) && s.Director.ToLower().Contains(director)));
        }

        var movies = await movieQuery.ToListAsync();
        var series = await seriesQuery.ToListAsync();

        var entities = new List<MediaFile>();
        entities.AddRange(movies);
        entities.AddRange(series);

        entities = filter.SortBy switch
        {
            "Alphabetical" => filter.SortOrder == "desc"
                ? entities.OrderByDescending(m => m.Name).ToList()
                : entities.OrderBy(m => m.Name).ToList(),

            "Favourites" => filter.SortOrder == "desc"
                ? entities.OrderByDescending(m => m.Favourite).ToList()
                : entities.OrderBy(m => m.Favourite).ToList(),

            "Ranking" => filter.SortOrder == "desc"
                ? entities.OrderByDescending(m => m.Rating).ToList()
                : entities.OrderBy(m => m.Rating).ToList(),

            _ => entities.OrderBy(m => m.Name).ToList()
        };

        return entities.Select(_mapper.MapToModel).ToList();
    }
}
