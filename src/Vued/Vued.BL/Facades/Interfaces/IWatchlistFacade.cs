using Vued.BL.Models;

namespace Vued.BL.Facades;

public interface IWatchlistFacade
{
    Task SaveAsync(WatchlistModel model);
    Task<WatchlistModel?> GetAsync(Guid id);
    Task DeleteAsync(Guid id);
    Task AddMediaToWatchlistAsync(int watchlistId, int mediaFileId);
    Task RemoveMediaFromWatchlistAsync(int watchlistId, int mediaFileId);
    Task<List<int>> GetMediaIdsForWatchlistAsync(int watchlistId);


}
