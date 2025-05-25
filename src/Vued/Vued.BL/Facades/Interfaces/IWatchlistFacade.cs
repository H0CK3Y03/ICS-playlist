using Vued.BL.Models;

namespace Vued.BL.Facades;

public interface IWatchlistFacade
{
    Task SaveAsync(WatchlistModel model);
    Task SaveAsync(WatchlistListModel model);
    Task<WatchlistModel?> GetAsync(Guid id);
    Task DeleteAsync(Guid id);
}
