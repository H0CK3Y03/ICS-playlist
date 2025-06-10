using Microsoft.EntityFrameworkCore;
using Vued.DAL.Entities;

namespace Vued.DAL.Seeds;

public static class WatchlistMediaSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Watchlist>()
            .HasMany(w => w.MediaFiles)
            .WithMany(m => m.Watchlists)
            .UsingEntity(j => j.HasData(
                // Favourites
                new { MediaFilesId = 1, WatchlistsId = 1 },
                new { MediaFilesId = 4, WatchlistsId = 1 },
                new { MediaFilesId = 5, WatchlistsId = 1 },
                new { MediaFilesId = 6, WatchlistsId = 1 },
                new { MediaFilesId = 8, WatchlistsId = 1 },
                new { MediaFilesId = 9, WatchlistsId = 1 },
                new { MediaFilesId = 10, WatchlistsId = 1 },
                new { MediaFilesId = 12, WatchlistsId = 1 },
                new { MediaFilesId = 14, WatchlistsId = 1 },
                new { MediaFilesId = 16, WatchlistsId = 1 },
                // Watch Later
                new { MediaFilesId = 2, WatchlistsId = 2 },
                new { MediaFilesId = 4, WatchlistsId = 2 },
                new { MediaFilesId = 5, WatchlistsId = 2 },
                new { MediaFilesId = 6, WatchlistsId = 2 },
                // Old Series
                new { MediaFilesId = 1, WatchlistsId = 3 },
                new { MediaFilesId = 3, WatchlistsId = 3 },
                new { MediaFilesId = 9, WatchlistsId = 3 },
                new { MediaFilesId = 11, WatchlistsId = 3 },
                new { MediaFilesId = 6, WatchlistsId = 3 }
            ));
    }
}
