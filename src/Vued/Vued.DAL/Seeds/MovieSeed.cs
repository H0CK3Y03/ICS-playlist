using System;
using Microsoft.EntityFrameworkCore;
using Vued.DAL.Entities;

namespace Vued.DAL.Seeds;

public static class MovieSeed
{
    public static readonly Guid MatrixId = Guid.Parse("10000000-0000-0000-0000-000000000001");
    public static readonly Guid ForrestGumpId = Guid.Parse("10000000-0000-0000-0000-000000000002");
    public static readonly Guid ShiningId = Guid.Parse("10000000-0000-0000-0000-000000000003");
    public static readonly Guid InceptionId = Guid.Parse("10000000-0000-0000-0000-000000000004");
    public static readonly Guid GodfatherId = Guid.Parse("10000000-0000-0000-0000-000000000005");
    public static readonly Guid SpiritedAwayId = Guid.Parse("10000000-0000-0000-0000-000000000006");
    public static readonly Guid MadMaxId = Guid.Parse("10000000-0000-0000-0000-000000000007");

    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MovieEntity>().HasData(
            new MovieEntity
            {
                Id = MatrixId,
                Name = "The Matrix",
                Length = 136,
                Status = MediaStatus.Completed,
                Description = "A computer hacker learns about the true nature of reality and joins a group of rebels to fight a war against powerful controllers.",
                Director = "Lana Wachowski, Lilly Wachowski",
                ReleaseDate = 1999,
                Rating = "8/10",
                URL = "https://www.imdb.com/title/tt0133093/",
                Favourite = true
            },
            new MovieEntity
            {
                Id = ForrestGumpId,
                Name = "Forrest Gump",
                Length = 142,
                Status = MediaStatus.Completed,
                Description = "The life story of a man with a low IQ who achieves extraordinary feats through his kindness and determination.",
                Director = "Robert Zemeckis",
                ReleaseDate = 1994,
                Rating = "6/10",
                URL = "https://www.imdb.com/title/tt0109830/",
                Favourite = true
            },
            new MovieEntity
            {
                Id = ShiningId,
                Name = "The Shining",
                Length = 144,
                Status = MediaStatus.Completed,
                Description = "A family heads to an isolated hotel for the winter where a sinister presence influences the father into violence.",
                Director = "Stanley Kubrick",
                ReleaseDate = 1980,
                Rating = "7/10",
                URL = "https://www.imdb.com/title/tt0081505/",
                Favourite = false
            },
            new MovieEntity
            {
                Id = InceptionId,
                Name = "Inception",
                Length = 148,
                Status = MediaStatus.Completed,
                Description = "A skilled thief with the ability to enter dreams must pull off an impossible heist: planting an idea in someone's mind.",
                Director = "Christopher Nolan",
                ReleaseDate = 2010,
                Rating = "9/10",
                URL = "https://www.imdb.com/title/tt1375666/",
                Favourite = true
            },
            new MovieEntity
            {
                Id = GodfatherId,
                Name = "The Godfather",
                Length = 175,
                Status = MediaStatus.Completed,
                Description = "The aging patriarch of an organized crime dynasty transfers control to his reluctant son.",
                Director = "Francis Ford Coppola",
                ReleaseDate = 1972,
                Rating = "8/10",
                URL = "https://www.imdb.com/title/tt0068646/",
                Favourite = true
            },
            new MovieEntity
            {
                Id = SpiritedAwayId,
                Name = "Spirited Away",
                Length = 125,
                Status = MediaStatus.Completed,
                Description = "A young girl becomes trapped in a strange spirit world and must find a way to free herself and her parents.",
                Director = "Hayao Miyazaki",
                ReleaseDate = 2001,
                Rating = "8/10",
                URL = "https://www.imdb.com/title/tt0245429/",
                Favourite = false
            },
            new MovieEntity
            {
                Id = MadMaxId,
                Name = "Mad Max: Fury Road",
                Length = 120,
                Status = MediaStatus.Completed,
                Description = "In a post-apocalyptic wasteland, a drifter and a rebel leader fight to survive against a tyrannical ruler.",
                Director = "George Miller",
                ReleaseDate = 2015,
                Rating = "7/10",
                URL = "https://www.imdb.com/title/tt1392190/",
                Favourite = true
            }
        );
    }
}
