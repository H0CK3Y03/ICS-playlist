using Vued.BL.Models;
using Vued.BL.Mappers;
using Vued.DAL;
using Microsoft.EntityFrameworkCore;

namespace Vued.BL.Facades;

public class GenreFacade
{
    private readonly AppDbContext _dbContext;
    private readonly GenreModelMapper _mapper;

    public GenreFacade(AppDbContext dbContext, GenreModelMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GenreModel>> GetAllAsync()
    {
        var entities = await _dbContext.Genres.ToListAsync();
        return entities.Select(_mapper.MapToModel);
    }

    public async Task<GenreModel?> GetAsync(int id)
    {
        var entity = await _dbContext.Genres.FirstOrDefaultAsync(g => g.Id == id);
        return entity is null ? null : _mapper.MapToModel(entity);
    }

    public async Task<GenreModel> SaveAsync(GenreModel model)
    {
        var entity = _mapper.MapToEntity(model);

        if (model.Id == 0)
            _dbContext.Genres.Add(entity);
        else
            _dbContext.Genres.Update(entity);

        await _dbContext.SaveChangesAsync();

        return _mapper.MapToModel(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _dbContext.Genres.FindAsync(id);
        if (entity is not null)
        {
            _dbContext.Genres.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
