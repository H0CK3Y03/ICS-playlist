namespace Vued.BL.Mappers;

public abstract class ModelMapperBase<TEntity, TModel> : IModelMapper<TEntity, TModel>
{
    public abstract TModel MapToModel(TEntity entity);
    public abstract TEntity MapToEntity(TModel model);
}
