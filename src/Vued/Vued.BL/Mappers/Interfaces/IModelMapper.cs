namespace Vued.BL.Mappers;

public interface IModelMapper<TEntity, TModel>
{
    TModel MapToModel(TEntity entity);
    TEntity MapToEntity(TModel model);
}
