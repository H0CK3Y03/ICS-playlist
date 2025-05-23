using Vued.BL.Models;
using Vued.BL.Mappers;
using Vued.DAL.Entities;
using Vued.DAL;
using Microsoft.EntityFrameworkCore;

namespace Vued.BL.Facades;

public class MediaFileFacade
{
    private readonly AppDbContext _dbContext;
    private readonly MediaFileModelMapper _mapper;

    public MediaFileFacade(AppDbContext dbContext, MediaFileModelMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<MediaListModel>> GetAllAsync()
    {
        var movieEntities = await _dbContext.Movies.Include(m => m.Genres).ToListAsync();
        var seriesEntities = await _dbContext.Series.Include(s => s.Genres).ToListAsync();

        var entities = new List<MediaFile>();
        entities.AddRange(movieEntities);
        entities.AddRange(seriesEntities);

        return entities.Select(_mapper.MapToListModel).ToList();
    }

    public async Task<MediaFileDetailModel?> GetByIdAsync(int id)
    {
        var movie = await _dbContext.Movies
            .Include(m => m.Genres)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (movie is not null)
            return _mapper.MapToDetailModel(movie);

        var series = await _dbContext.Series
            .Include(s => s.Genres)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (series is not null)
            return _mapper.MapToDetailModel(series);

        return null;
    }

    public async Task<MediaFileDetailModel> SaveAsync(MediaFileDetailModel model)
    {
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
}
