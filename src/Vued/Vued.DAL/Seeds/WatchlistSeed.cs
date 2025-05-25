using System;
using Microsoft.EntityFrameworkCore;
using Vued.DAL.Entities;

namespace Vued.DAL.Seeds;

public static class WatchlistSeed
{
    public static readonly Guid MyFavoritesId = Guid.Parse("30000000-0000-0000-0000-000000000001");
    public static readonly Guid WatchLaterId = Guid.Parse("30000000-0000-0000-0000-000000000002");

    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WatchlistEntity>().HasData(
            new WatchlistEntity
            {
                Id = MyFavoritesId,
                Name = "My Favorites",
                Description = "Top-rated movies and series"
            },
            new WatchlistEntity
            {
                Id = WatchLaterId,
                Name = "Watch Later",
                Description = "Movies and series to watch later"
            }
        );
    }
}
