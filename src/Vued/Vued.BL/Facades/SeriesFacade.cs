using Vued.BL.Models;
using Vued.DAL.Entities;
using Vued.BL.Mappers;
using Microsoft.EntityFrameworkCore;
using Vued.DAL;

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

    public async Task<List<SeriesListModel>> GetAllAsync()
    {
        var entities = await _dbContext.Series.ToListAsync();
        return entities
            .Select(entity => _mapper.MapToListModel(entity))
            .ToList();
    }

    public async Task<SeriesDetailModel?> GetByIdAsync(int id)
    {
        var entity = await _dbContext.Series
            .Include(s => s.Genres)
            .FirstOrDefaultAsync(s => s.Id == id);

        return entity is null ? null : _mapper.MapToDetailModel(entity);
    }

    public async Task<SeriesDetailModel> SaveAsync(SeriesDetailModel model)
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
