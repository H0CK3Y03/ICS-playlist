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
            new Genre { Id = 3, Name = "Drama" },
            new Genre { Id = 4, Name = "Horror" },
            new Genre { Id = 5, Name = "Sci-Fi" },
            new Genre { Id = 6, Name = "Fantasy" },
            new Genre { Id = 7, Name = "Adventure" },
            new Genre { Id = 8, Name = "Romance" },
            new Genre { Id = 9, Name = "Thriller" },
            new Genre { Id = 10, Name = "Mystery" },
            new Genre { Id = 11, Name = "Crime" },
            new Genre { Id = 12, Name = "Western" },
            new Genre { Id = 13, Name = "Historical" },
            new Genre { Id = 14, Name = "War" },
            new Genre { Id = 15, Name = "Documentary" },
            new Genre { Id = 16, Name = "Biography" },
            new Genre { Id = 17, Name = "Musical" },
            new Genre { Id = 18, Name = "Animation" },
            new Genre { Id = 19, Name = "Family" },
            new Genre { Id = 20, Name = "Sport" },
            new Genre { Id = 21, Name = "Superhero" },
            new Genre { Id = 22, Name = "Noir" },
            new Genre { Id = 23, Name = "Satire" },
            new Genre { Id = 24, Name = "Parody" },
            new Genre { Id = 25, Name = "Psychological" },
            new Genre { Id = 26, Name = "Post-Apocalyptic" },
            new Genre { Id = 27, Name = "Dystopian" },
            new Genre { Id = 28, Name = "Coming-of-Age" },
            new Genre { Id = 29, Name = "Epic" },
            new Genre { Id = 30, Name = "Period" },
            new Genre { Id = 31, Name = "Political" },
            new Genre { Id = 32, Name = "Slice of Life" },
            new Genre { Id = 33, Name = "Supernatural" },
            new Genre { Id = 34, Name = "Survival" },
            new Genre { Id = 35, Name = "Espionage" },
            new Genre { Id = 36, Name = "Heist" },
            new Genre { Id = 37, Name = "Disaster" },
            new Genre { Id = 38, Name = "Martial Arts" },
            new Genre { Id = 39, Name = "Road Movie" },
            new Genre { Id = 40, Name = "Anthology" },
            new Genre { Id = 41, Name = "Experimental" },
            new Genre { Id = 42, Name = "Gothic" },
            new Genre { Id = 43, Name = "Steampunk" },
            new Genre { Id = 44, Name = "Cyberpunk" },
            new Genre { Id = 45, Name = "Dark Comedy" },
            new Genre { Id = 46, Name = "Romantic Comedy" },
            new Genre { Id = 47, Name = "Tragedy" },
            new Genre { Id = 48, Name = "Melodrama" },
            new Genre { Id = 49, Name = "Mockumentary" },
            new Genre { Id = 50, Name = "Silent Film" }
        );
    }
}
