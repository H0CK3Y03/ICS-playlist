using System;
using Microsoft.EntityFrameworkCore;
using Vued.DAL.Entities;

namespace Vued.DAL.Seeds;

public static class MediaFileGenreSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MediaFileGenreEntity>().HasData(
            new MediaFileGenreEntity
            {
                Id = Guid.Parse("50000000-0000-0000-0000-000000000001"),
                MediaFileId = MovieSeed.InceptionId,
                GenreId = GenreSeed.ActionId
            },
            new MediaFileGenreEntity
            {
                Id = Guid.Parse("50000000-0000-0000-0000-000000000002"),
                MediaFileId = SeriesSeed.BreakingBadId,
                GenreId = GenreSeed.DramaId
            }
        );
    }
}
