using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Seeds;

public static class MovieSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>().HasData(
            new Movie { Id = 1, Name = "Inception", Length = 148, Status = MediaStatus.Completed, ReleaseDate = 2010, Rating = "PG-13" },
            new Movie { Id = 2, Name = "The Matrix", Length = 136, Status = MediaStatus.Completed, ReleaseDate = 1999, Rating = "R" }
        );
    }
}
