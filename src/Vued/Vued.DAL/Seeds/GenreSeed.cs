using Vued.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Vued.DAL.Seeds;

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
