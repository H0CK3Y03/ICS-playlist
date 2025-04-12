using BL.Models;
using Domain.Entities;
using BL.Mappers;
using Microsoft.EntityFrameworkCore;
using Infrastructure;

namespace BL.Facades;

public class WatchlistFacade
{
    private readonly AppDbContext _dbContext;
    private readonly WatchlistMapper _mapper;

    public WatchlistFacade(AppDbContext dbContext, WatchlistMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<WatchlistListModel>> GetAllAsync()
    {
        var entities = await _dbContext.Watchlists
            .Include(w => w.MediaFiles)
            .ToListAsync();

        return entities
            .Select(e => _mapper.MapToListModel(e))
            .ToList();
    }

    public async Task<WatchlistDetailModel?> GetByIdAsync(int id)
    {
        var entity = await _dbContext.Watchlists
            .Include(w => w.MediaFiles)
            .FirstOrDefaultAsync(w => w.Id == id);

        return entity is null ? null : _mapper.MapToDetailModel(entity);
    }

    public async Task<WatchlistDetailModel> SaveAsync(WatchlistDetailModel model)
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
}
