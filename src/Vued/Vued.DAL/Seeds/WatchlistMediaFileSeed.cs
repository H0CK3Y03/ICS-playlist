using System;
using Microsoft.EntityFrameworkCore;
using Vued.DAL.Entities;

namespace Vued.DAL.Seeds;

public static class WatchlistMediaFileSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WatchlistMediaFileEntity>().HasData(
            new WatchlistMediaFileEntity
            {
                Id = Guid.Parse("40000000-0000-0000-0000-000000000001"),
                WatchlistId = WatchlistSeed.MyFavoritesId,
                MediaFileId = MovieSeed.InceptionId
            },
            new WatchlistMediaFileEntity
            {
                Id = Guid.Parse("40000000-0000-0000-0000-000000000002"),
                WatchlistId = WatchlistSeed.WatchLaterId,
                MediaFileId = SeriesSeed.BreakingBadId
            }
        );
    }
}
