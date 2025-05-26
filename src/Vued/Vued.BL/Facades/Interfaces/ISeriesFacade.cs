using Vued.BL.Models;

namespace Vued.BL.Facades;

public interface ISeriesFacade
{
    Task SaveAsync(SeriesModel model);
    Task DeleteAsync(Guid id);
}
