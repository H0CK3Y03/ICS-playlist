using System;
using Microsoft.EntityFrameworkCore;
using Vued.DAL.Entities;

namespace Vued.DAL.Seeds;

public static class GenreSeed
{
    public static readonly Guid ActionId = Guid.Parse("00000000-0000-0000-0000-000000000001");
    public static readonly Guid ComedyId = Guid.Parse("00000000-0000-0000-0000-000000000002");
    public static readonly Guid DramaId = Guid.Parse("00000000-0000-0000-0000-000000000003");
    public static readonly Guid HorrorId = Guid.Parse("00000000-0000-0000-0000-000000000004");
    public static readonly Guid SciFiId = Guid.Parse("00000000-0000-0000-0000-000000000005");

    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GenreEntity>().HasData(
            new GenreEntity { Id = ActionId, Name = "Action" },
            new GenreEntity { Id = ComedyId, Name = "Comedy" },
            new GenreEntity { Id = DramaId, Name = "Drama" },
            new GenreEntity { Id = HorrorId, Name = "Horror" },
            new GenreEntity { Id = SciFiId, Name = "Sci-Fi" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000006"), Name = "Fantasy" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000007"), Name = "Adventure" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000008"), Name = "Romance" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000009"), Name = "Thriller" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000010"), Name = "Mystery" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000011"), Name = "Crime" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000012"), Name = "Western" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000013"), Name = "Historical" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000014"), Name = "War" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000015"), Name = "Documentary" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000016"), Name = "Biography" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000017"), Name = "Musical" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000018"), Name = "Animation" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000019"), Name = "Family" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000020"), Name = "Sport" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000021"), Name = "Superhero" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000022"), Name = "Noir" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000023"), Name = "Satire" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000024"), Name = "Parody" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000025"), Name = "Psychological" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000026"), Name = "Post-Apocalyptic" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000027"), Name = "Dystopian" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000028"), Name = "Coming-of-Age" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000029"), Name = "Epic" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000030"), Name = "Period" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000031"), Name = "Political" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000032"), Name = "Slice of Life" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000033"), Name = "Supernatural" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000034"), Name = "Survival" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000035"), Name = "Espionage" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000036"), Name = "Heist" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000037"), Name = "Disaster" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000038"), Name = "Martial Arts" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000039"), Name = "Road Movie" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000040"), Name = "Anthology" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000041"), Name = "Experimental" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000042"), Name = "Gothic" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000043"), Name = "Steampunk" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000044"), Name = "Cyberpunk" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000045"), Name = "Dark Comedy" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000046"), Name = "Romantic Comedy" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000047"), Name = "Tragedy" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000048"), Name = "Melodrama" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000049"), Name = "Mockumentary" },
            new GenreEntity { Id = Guid.Parse("00000000-0000-0000-0000-000000000050"), Name = "Silent Film" }
        );
    }
}
