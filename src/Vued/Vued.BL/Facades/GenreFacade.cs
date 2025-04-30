using Vued.BL.Models;
using Vued.BL.Mappers;
using Vued.DAL;
using Vued.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Vued.DAL;

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

    public async Task<IEnumerable<GenreListModel>> GetAllAsync()
    {
        var entities = await _dbContext.Genres.ToListAsync();
        return entities.Select(_mapper.MapToListModel);
    }

    public async Task<GenreDetailModel?> GetAsync(int id)
    {
        var entity = await _dbContext.Genres.FirstOrDefaultAsync(g => g.Id == id);
        return entity is null ? null : _mapper.MapToDetailModel(entity);
    }

    public async Task<GenreDetailModel> SaveAsync(GenreDetailModel model)
    {
        var entity = _mapper.MapToEntity(model);

        if (model.Id == 0)
            _dbContext.Genres.Add(entity);
        else
            _dbContext.Genres.Update(entity);

        await _dbContext.SaveChangesAsync();

        return _mapper.MapToDetailModel(entity);
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
