using Vued.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Vued.DAL.Seeds;

public static class WatchlistSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Watchlist>().HasData(
            new Watchlist { Id = 1, Name = "My Favorites", Description = "Top-rated movies and series" },
            new Watchlist { Id = 2, Name = "Watch Later", Description = "Movies and series to watch later" }
        );
    }
}
