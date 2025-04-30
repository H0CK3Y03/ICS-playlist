using Vued.BL.Models;

namespace Vued.BL.Facades;

public interface ISeriesFacade
{
    Task SaveAsync(SeriesDetailModel model);
    Task SaveAsync(SeriesListModel model);
    Task DeleteAsync(Guid id);
}
