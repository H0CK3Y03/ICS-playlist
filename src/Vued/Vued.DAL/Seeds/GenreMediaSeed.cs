using Microsoft.EntityFrameworkCore;
using Vued.DAL.Entities;

namespace Vued.DAL.Seeds;

public static class GenreMediaSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MediaFile>()
            .HasMany(m => m.Genres)
            .WithMany(g => g.MediaFiles)
            .UsingEntity(j => j.HasData(
                new { MediaFilesId = 1, GenresId = 1 },
                new { MediaFilesId = 1, GenresId = 5 },
                new { MediaFilesId = 2, GenresId = 3 },
                new { MediaFilesId = 2, GenresId = 8 },
                new { MediaFilesId = 3, GenresId = 4 },
                new { MediaFilesId = 3, GenresId = 9 },
                new { MediaFilesId = 4, GenresId = 5 },
                new { MediaFilesId = 4, GenresId = 9 },
                new { MediaFilesId = 5, GenresId = 11 },
                new { MediaFilesId = 5, GenresId = 3 },
                new { MediaFilesId = 6, GenresId = 6 },
                new { MediaFilesId = 6, GenresId = 18 },
                new { MediaFilesId = 7, GenresId = 1 },
                new { MediaFilesId = 7, GenresId = 26 },
                new { MediaFilesId = 8, GenresId = 5 },
                new { MediaFilesId = 8, GenresId = 3 },
                new { MediaFilesId = 9, GenresId = 8 },
                new { MediaFilesId = 9, GenresId = 47 },
                new { MediaFilesId = 10, GenresId = 3 },
                new { MediaFilesId = 10, GenresId = 25 },
                new { MediaFilesId = 11, GenresId = 9 },
                new { MediaFilesId = 11, GenresId = 23 },
                new { MediaFilesId = 12, GenresId = 1 },
                new { MediaFilesId = 12, GenresId = 13 },
                new { MediaFilesId = 13, GenresId = 5 },
                new { MediaFilesId = 13, GenresId = 6 },
                new { MediaFilesId = 14, GenresId = 14 },
                new { MediaFilesId = 14, GenresId = 16 }
            ));
    }
}
