using System.Linq;
using Vued.BL.Models;
using Vued.DAL.Entities;
using Vued.BL.Mappers;
using Microsoft.EntityFrameworkCore;
using Vued.DAL;

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
