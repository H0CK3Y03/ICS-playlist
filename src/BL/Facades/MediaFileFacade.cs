using BL.Models;
using Domain.Entities;
using BL.Mappers;

namespace BL.Facades;

public class MediaFileFacade(
    //IUnitOfWorkFactory unitOfWorkFactory,
    MediaFileModelMapper mediaFileModelMapper)
    : IMediaFileFacade
{
    public async Task SaveAsync(MediaListModel model)
    {
        var detail = await GetAsync(model.Id) ?? new MediaDetailModel { Id = model.Id, Name = model.Name };
        await SaveAsync(detail);
    }

    public async Task SaveAsync(MediaFileDetailModel model)
    {
        var entity = mediaFileModelMapper.MapToEntity(model);

        //await using var uow = unitOfWorkFactory.Create();
        var repository = uow.GetRepository<MediaFile, MediaFileEntityMapper>();

        if (await repository.ExistsAsync(entity))
        {
            await repository.UpdateAsync(entity);
        }
        else
        {
            repository.Insert(entity);
        }

        await uow.CommitAsync();
    }

    public async Task<MediaFileDetailModel?> GetAsync(Guid id)
    {
        await using var uow = unitOfWorkFactory.Create();
        var entity = await uow.GetRepository<MediaFile, MediaFileEntityMapper>()
            .Get()
            .SingleOrDefaultAsync(e => e.Id == id);

        return entity is null ? null : mediaFileModelMapper.MapToDetailModel(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await using var uow = unitOfWorkFactory.Create();
        await uow.GetRepository<MediaFile, MediaFileEntityMapper>().DeleteAsync(id);
        await uow.CommitAsync();
    }
}
