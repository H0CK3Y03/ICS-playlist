using Vued.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Vued.DAL.Seeds;

public static class MovieSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>().HasData(
            new Movie
            {
                Id = 1,
                Name = "The Matrix",
                Length = 136,
                Status = MediaStatus.Completed,
                Description = "A computer hacker learns about the true nature of reality and joins a group of rebels to fight a war against powerful controllers.",
                Director = "Lana Wachowski, Lilly Wachowski",
                ReleaseDate = 1999,
                Rating = "8/10",
                URL = "https://www.imdb.com/title/tt0133093/",
                Favourite = true,
                Watchlists = new List<Watchlist>(),
                Genres = new List<Genre>
                {
                    new Genre { Id = 1 }, // Action
                    new Genre { Id = 5 }, // Science Fiction
                    new Genre { Id = 44 }  // Cyberpunk
                }
            },
            new Movie
            {
                Id = 2,
                Name = "Forrest Gump",
                Length = 142,
                Status = MediaStatus.Completed,
                Description = "The life story of a man with a low IQ who achieves extraordinary feats through his kindness and determination.",
                Director = "Robert Zemeckis",
                ReleaseDate = 1994,
                Rating = "6/10", // Jane is a bitch (pretend you did not see this)
                URL = "https://www.imdb.com/title/tt0109830/",
                Favourite = true,
                Watchlists = new List<Watchlist>(),
                Genres = new List<Genre>
                {
                    new Genre { Id = 3 }, // Drama
                    new Genre { Id = 8 }, // Romance
                    new Genre { Id = 28 }  // Coming-of-Age
                }
            },
            new Movie
            {
                Id = 3,
                Name = "The Shining",
                Length = 144,
                Status = MediaStatus.Completed,
                Description = "A family heads to an isolated hotel for the winter where a sinister presence influences the father into violence.",
                Director = "Stanley Kubrick",
                ReleaseDate = 1980,
                Rating = "7/10",
                URL = "https://www.imdb.com/title/tt0081505/",
                Favourite = false,
                Watchlists = new List<Watchlist>(),
                Genres = new List<Genre>
                {
                    new Genre { Id = 4 }, // Horror
                    new Genre { Id = 25 }, // Psychological
                    new Genre { Id = 42 }  // Gothic
                }
            },
            new Movie
            {
                Id = 4,
                Name = "Inception",
                Length = 148,
                Status = MediaStatus.Completed,
                Description = "A skilled thief with the ability to enter dreams must pull off an impossible heist: planting an idea in someone's mind.",
                Director = "Christopher Nolan",
                ReleaseDate = 2010,
                Rating = "9/10",
                URL = "https://www.imdb.com/title/tt1375666/",
                Favourite = true,
                Watchlists = new List<Watchlist>(),
                Genres = new List<Genre>
                {
                    new Genre { Id = 5 }, // Science Fiction
                    new Genre { Id = 9 }, // Thriller
                    new Genre { Id = 36 }  // Heist
                }
            },
            new Movie
            {
                Id = 5,
                Name = "The Godfather",
                Length = 175,
                Status = MediaStatus.Completed,
                Description = "The aging patriarch of an organized crime dynasty transfers control to his reluctant son.",
                Director = "Francis Ford Coppola",
                ReleaseDate = 1972,
                Rating = "8/10",
                URL = "https://www.imdb.com/title/tt0068646/",
                Favourite = true,
                Watchlists = new List<Watchlist>(),
                Genres = new List<Genre>
                {
                    new Genre { Id = 11 }, // Crime
                    new Genre { Id = 3 },  // Drama
                    new Genre { Id = 29 }  // Epic
                }
            },
            new Movie
            {
                Id = 6,
                Name = "Spirited Away",
                Length = 125,
                Status = MediaStatus.Completed,
                Description = "A young girl becomes trapped in a strange spirit world and must find a way to free herself and her parents.",
                Director = "Hayao Miyazaki",
                ReleaseDate = 2001,
                Rating = "8/10",
                URL = "https://www.imdb.com/title/tt0245429/",
                Favourite = false,
                Watchlists = new List<Watchlist>(),
                Genres = new List<Genre>
                {
                    new Genre { Id = 18 }, // Animation
                    new Genre { Id = 6 },  // Fantasy
                    new Genre { Id = 28 }  // Coming-of-Age
                }
            },
            new Movie
            {
                Id = 7,
                Name = "Mad Max: Fury Road",
                Length = 120,
                Status = MediaStatus.Completed,
                Description = "In a post-apocalyptic wasteland, a drifter and a rebel leader fight to survive against a tyrannical ruler.",
                Director = "George Miller",
                ReleaseDate = 2015,
                Rating = "7/10",
                URL = "https://www.imdb.com/title/tt1392190/",
                Favourite = true,
                Watchlists = new List<Watchlist>(),
                Genres = new List<Genre>
                {
                    new Genre { Id = 1 },  // Action
                    new Genre { Id = 26 }, // Post-Apocalyptic
                    new Genre { Id = 7 }   // Adventure
                }
            }
        );
    }
}
