using Vued.BL.Models;
using Vued.BL.Mappers;
using Vued.DAL.Entities;
using Vued.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
        var entities = await _dbContext.MediaFiles
            .Include(m => m.Genres)
            .ToListAsync();

        return entities.Select(_mapper.MapToModel).ToList();
    }

    public async Task<MediaFileModel?> GetByIdAsync(int id)
    {
        var entity = await _dbContext.MediaFiles
            .Include(m => m.Genres)
            .FirstOrDefaultAsync(m => m.Id == id);

        return entity != null ? _mapper.MapToModel(entity) : null;
    }

    public async Task<MediaFileModel> SaveAsync(MediaFileModel? model)
    {
        if (model == null)
            throw new ArgumentNullException(nameof(model), "Model cannot be null.");

        var entity = model.Id == 0
            ? _mapper.MapToEntity(model)
            : await _dbContext.MediaFiles.FirstOrDefaultAsync(m => m.Id == model.Id);

        if (entity == null && model.Id != 0)
            throw new InvalidOperationException($"Media file with ID {model.Id} not found for update.");

        if (entity == null)
        {
            entity = _mapper.MapToEntity(model);
            _dbContext.MediaFiles.Add(entity);
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
            entity.Review = model.Review;
            entity.MediaType = model.MediaType;
        }

        await _dbContext.SaveChangesAsync();

        var savedEntity = await _dbContext.MediaFiles
            .FirstAsync(m => m.Id == entity.Id);

        if (savedEntity.Id == 0)
            throw new InvalidOperationException("Failed to save media file: Entity ID is 0 after save.");

        return _mapper.MapToModel(savedEntity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _dbContext.MediaFiles
            .FirstOrDefaultAsync(m => m.Id == id);

        if (entity != null)
        {
            _dbContext.MediaFiles.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task AddGenreToMediaAsync(int mediaFileId, int genreId)
    {
        var mediaFile = await _dbContext.MediaFiles
            .Include(m => m.Genres)
            .FirstOrDefaultAsync(m => m.Id == mediaFileId);

        if (mediaFile == null)
            throw new InvalidOperationException($"Media file with ID {mediaFileId} not found.");

        var genre = await _dbContext.Genres.FindAsync(genreId);

        if (genre == null)
            throw new InvalidOperationException($"Genre with ID {genreId} not found.");

        if (!mediaFile.Genres.Contains(genre))
        {
            mediaFile.Genres.Add(genre);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task RemoveGenreFromMediaAsync(int mediaFileId, int genreId)
    {
        var mediaFile = await _dbContext.MediaFiles
            .Include(m => m.Genres)
            .FirstOrDefaultAsync(m => m.Id == mediaFileId);

        if (mediaFile == null)
            throw new InvalidOperationException($"Media file with ID {mediaFileId} not found.");

        var genre = mediaFile.Genres.FirstOrDefault(g => g.Id == genreId);
        if (genre != null)
        {
            mediaFile.Genres.Remove(genre);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<List<int>> GetGenreIdsForMediaAsync(int mediaFileId)
    {
        var genreIds = await _dbContext.MediaFiles
            .Where(m => m.Id == mediaFileId)
            .SelectMany(m => m.Genres)
            .Select(g => g.Id)
            .ToListAsync();

        return genreIds;
    }

    public async Task<List<MediaFileModel>> FilterAsync(MovieFilterModel filter)
    {
        var query = _dbContext.MediaFiles
            .Include(m => m.Genres)
            .AsQueryable();

        if (!string.IsNullOrEmpty(filter.Genre) && filter.Genre != "All")
        {
            query = query.Where(m => m.Genres.Any(g => g.Name == filter.Genre));
        }

        if (filter.Favourite == true)
        {
            query = query.Where(m => m.Favourite);
        }

        if (filter.ReleaseYear.HasValue)
        {
            query = query.Where(m => m.ReleaseDate >= filter.ReleaseYear.Value);
        }

        if (!string.IsNullOrWhiteSpace(filter.TitleContains) || !string.IsNullOrWhiteSpace(filter.DirectorContains))
        {
            var title = filter.TitleContains?.ToLower() ?? string.Empty;
            var director = filter.DirectorContains?.ToLower() ?? string.Empty;

            query = query.Where(m =>
                (!string.IsNullOrEmpty(title) && m.Name.ToLower().Contains(title)) ||
                (!string.IsNullOrEmpty(director) && m.Director.ToLower().Contains(director)));
        }

        var entities = await query.ToListAsync();

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