using Vued.BL.Models;
using Vued.DAL.Entities;
using Vued.BL.Mappers;
using Microsoft.EntityFrameworkCore;
using Vued.DAL;

namespace Vued.BL.Facades;

public class WatchlistFacade
{
    private readonly AppDbContext _dbContext;
    private readonly WatchlistModelMapper _mapper;

    public WatchlistFacade(AppDbContext dbContext, WatchlistModelMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<WatchlistModel>> GetAllAsync()
    {
        var entities = await _dbContext.Watchlists
            .Include(w => w.MediaFiles)
            .ToListAsync();

        return entities
            .Select(e => _mapper.MapToModel(e))
            .ToList();
    }

    public async Task<WatchlistModel?> GetByIdAsync(int id)
    {
        var entity = await _dbContext.Watchlists
            .Include(w => w.MediaFiles)
            .FirstOrDefaultAsync(w => w.Id == id);

        return entity is null ? null : _mapper.MapToModel(entity);
    }

    public async Task<WatchlistModel> SaveAsync(WatchlistModel model)
    {
        var entity = await _dbContext.Watchlists
            .Include(w => w.MediaFiles)
            .FirstOrDefaultAsync(e => e.Id == model.Id);

        if (entity is null)
        {
            var newEntity = _mapper.MapToEntity(model);
            _dbContext.Watchlists.Add(newEntity);
        }
        else
        {
            entity.Name = model.Name;
            entity.Description = model.Description;
        }

        await _dbContext.SaveChangesAsync();
        return model;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _dbContext.Watchlists.FirstOrDefaultAsync(w => w.Id == id);

        if (entity != null)
        {
            _dbContext.Watchlists.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task AddMediaToWatchlistAsync(int watchlistId, int mediaFileId)
    {
        var watchlist = await _dbContext.Watchlists
            .Include(w => w.MediaFiles)
            .FirstOrDefaultAsync(w => w.Id == watchlistId);

        var media = await _dbContext.Set<MediaFile>().FindAsync(mediaFileId);

        if (watchlist != null && media != null && !watchlist.MediaFiles.Contains(media))
        {
            watchlist.MediaFiles.Add(media);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task RemoveMediaFromWatchlistAsync(int watchlistId, int mediaFileId)
    {
        var watchlist = await _dbContext.Watchlists
            .Include(w => w.MediaFiles)
            .FirstOrDefaultAsync(w => w.Id == watchlistId);

        var media = await _dbContext.Set<MediaFile>().FindAsync(mediaFileId);

        if (watchlist != null && media != null && watchlist.MediaFiles.Contains(media))
        {
            watchlist.MediaFiles.Remove(media);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<List<int>> GetMediaIdsForWatchlistAsync(int watchlistId)
    {
        var mediaIds = await _dbContext.Watchlists
            .Where(w => w.Id == watchlistId)
            .SelectMany(w => w.MediaFiles.Select(m => m.Id))
            .ToListAsync();

        return mediaIds;
    }
}
