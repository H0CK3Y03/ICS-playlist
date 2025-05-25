namespace Vued.BL.Mappers;

public interface IModelMapper<TEntity, TModel>
{
    //TListModel MapToListModel(TEntity? entity);

    //IEnumerable<TListModel> MapToListModel(IEnumerable<TEntity> entities)
    //    => entities.Select(MapToListModel);

    TModel MapToModel(TEntity entity);
    TEntity MapToEntity(TModel model);
}
