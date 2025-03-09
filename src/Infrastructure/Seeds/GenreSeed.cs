using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Seeds;
public static class GenreSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
            new Genre { Id = 1, Name = "Action" },
            new Genre { Id = 2, Name = "Comedy" },
            new Genre { Id = 3, Name = "Drama" }
        );
    }
}
