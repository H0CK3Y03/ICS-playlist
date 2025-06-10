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
                new { MediaFilesId = 1, WatchlistsId = 3 },
                new { MediaFilesId = 2, WatchlistsId = 2 },
                new { MediaFilesId = 3, WatchlistsId = 3 }
            ));
    }
}
