namespace Vued.BL.Mappers;

public abstract class ModelMapperBase<TEntity, TModel> : IModelMapper<TEntity, TModel>
{
    //public abstract TListModel MapToListModel(TEntity? entity);

    //public IEnumerable<TListModel> MapToListModel(IEnumerable<TEntity> entities)
    //    => entities.Select(MapToListModel);

    public abstract TModel MapToModel(TEntity entity);
    public abstract TEntity MapToEntity(TModel model);
}
