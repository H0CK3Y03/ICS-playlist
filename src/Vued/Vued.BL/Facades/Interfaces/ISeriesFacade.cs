using Vued.BL.Models;

namespace Vued.BL.Facades;

public interface ISeriesFacade
{
    Task SaveAsync(SeriesModel model);
    Task SaveAsync(SeriesListModel model);
    Task DeleteAsync(Guid id);
}
