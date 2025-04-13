using BL.Models;

namespace BL.Facades;

public interface IWatchlistFacade
{
    Task SaveAsync(WatchlistDetailModel model);
    Task SaveAsync(WatchlistListModel model);
    Task<WatchlistDetailModel?> GetAsync(Guid id);
    Task DeleteAsync(Guid id);
}
