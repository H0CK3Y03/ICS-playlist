using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Vued.DAL.Seeds;

public static class WatchlistMediaSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity("MediaFileWatchlist").HasData(
            // Watchlist 1 (Favorites)
            new Dictionary<string, object> { ["MediaFilesId"] = 1, ["WatchlistsId"] = 1 },
            new Dictionary<string, object> { ["MediaFilesId"] = 2, ["WatchlistsId"] = 1 },
            new Dictionary<string, object> { ["MediaFilesId"] = 4, ["WatchlistsId"] = 1 },
            new Dictionary<string, object> { ["MediaFilesId"] = 5, ["WatchlistsId"] = 1 },

            // Watchlist 2 (Watch Later)
            new Dictionary<string, object> { ["MediaFilesId"] = 6, ["WatchlistsId"] = 2 },
            new Dictionary<string, object> { ["MediaFilesId"] = 8, ["WatchlistsId"] = 2 },
            new Dictionary<string, object> { ["MediaFilesId"] = 14, ["WatchlistsId"] = 2 }
        );
    }
}