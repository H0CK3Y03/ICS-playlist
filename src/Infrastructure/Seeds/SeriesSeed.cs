using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Seeds;
public static class SeriesSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Series>().HasData(
            new Series { Id = 3, Name = "Breaking Bad", NumberOfEpisodes = 62, Status = MediaStatus.Completed, ReleaseDate = 2008, Rating = "TV-MA" },
            new Series { Id = 4, Name = "Stranger Things", NumberOfEpisodes = 34, Status = MediaStatus.Watching, ReleaseDate = 2016, Rating = "TV-14" }
        );
    }
}
