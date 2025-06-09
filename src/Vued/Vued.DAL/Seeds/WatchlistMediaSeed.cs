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
                // The Matrix 
                new { MediaFilesId = 1, WatchlistsId = 3 },
                //Forrest Gump
                new { MediaFilesId = 2, WatchlistsId = 2 },
                // Breaking Bad
                new { MediaFilesId = 8, WatchlistsId = 3 }
            ));
    }
}
