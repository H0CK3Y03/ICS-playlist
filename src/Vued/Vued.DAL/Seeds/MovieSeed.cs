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
                Status = MediaStatus.Completed,
                Description = "A computer hacker learns about the true nature of reality and joins a group of rebels to fight a war against powerful controllers.",
                Director = "Lana Wachowski, Lilly Wachowski",
                ReleaseDate = 1999,
                Rating = "8/10",
                URL = "https://www.imdb.com/title/tt0133093/",
                ImageURL = "https://m.media-amazon.com/images/M/MV5BN2NmN2VhMTQtMDNiOS00NDlhLTliMjgtODE2ZTY0ODQyNDRhXkEyXkFqcGc@._V1_.jpg",
                Favourite = true,
                Duration = 136,
                Review = "Nice"
            },
            new Movie
            {
                Id = 2,
                Name = "Forrest Gump",
                Status = MediaStatus.Completed,
                Description = "The life story of a man with a low IQ who achieves extraordinary feats through his kindness and determination.",
                Director = "Robert Zemeckis",
                ReleaseDate = 1994,
                Rating = "6/10",
                URL = "https://www.imdb.com/title/tt0109830/",
                ImageURL = "https://storage.googleapis.com/pod_public/1300/266241.jpg",
                Favourite = true,
                Duration = 142,
                Review = "Cool"
            },
            new Movie
            {
                Id = 3,
                Name = "The Shining",
                Status = MediaStatus.Completed,
                Description = "A family heads to an isolated hotel for the winter where a sinister presence influences the father into violence.",
                Director = "Stanley Kubrick",
                ReleaseDate = 1980,
                Rating = "7/10",
                URL = "https://www.imdb.com/title/tt0081505/",
                ImageURL = "https://storage.googleapis.com/pod_public/1300/262806.jpg",
                Favourite = false,
                Duration = 144,
                Review = "Idk"
            },
            new Movie
            {
                Id = 4,
                Name = "Inception",
                Status = MediaStatus.Completed,
                Description = "A skilled thief with the ability to enter dreams must pull off an impossible heist: planting an idea in someone's mind.",
                Director = "Christopher Nolan",
                ReleaseDate = 2010,
                Rating = "9/10",
                URL = "https://www.imdb.com/title/tt1375666/",
                ImageURL = "https://www.vasefotka.cz/fotky22340/fotos/_vyr_271602026-Inception-Pocatek.jpg",
                Favourite = true,
                Duration = 148,
                Review = "Perfect"
            },
            new Movie
            {
                Id = 5,
                Name = "The Godfather",
                Status = MediaStatus.Completed,
                Description = "The aging patriarch of an organized crime dynasty transfers control to his reluctant son.",
                Director = "Francis Ford Coppola",
                ReleaseDate = 1972,
                Rating = "8/10",
                URL = "https://www.imdb.com/title/tt0068646/",
                ImageURL = "https://i5.walmartimages.com/seo/The-Godfather-Original-Movie-Poster-poster-Frameless-Gift-12-x-18-inch-30cm-x-46cm_c6df3fd5-1e9c-49ca-8cb6-1af6078df4c2.b21fd8bc877c5645b9340a53580833a2.jpeg",
                Favourite = true,
                Duration = 175,
                Review = "Nice"
            },
            new Movie
            {
                Id = 6,
                Name = "Spirited Away",
                Status = MediaStatus.Completed,
                Description = "A young girl becomes trapped in a strange spirit world and must find a way to free herself and her parents.",
                Director = "Hayao Miyazaki",
                ReleaseDate = 2001,
                Rating = "8/10",
                URL = "https://www.imdb.com/title/tt0245429/",
                ImageURL = "https://m.media-amazon.com/images/M/MV5BNTEyNmEwOWUtYzkyOC00ZTQ4LTllZmUtMjk0Y2YwOGUzYjRiXkEyXkFqcGc@._V1_.jpg",
                Favourite = false,
                Duration = 125,
                Review = "Nice"
            },
            new Movie
            {
                Id = 7,
                Name = "Mad Max: Fury Road",
                Status = MediaStatus.Completed,
                Description = "In a post-apocalyptic wasteland, a drifter and a rebel leader fight to survive against a tyrannical ruler.",
                Director = "George Miller",
                ReleaseDate = 2015,
                Rating = "7/10",
                URL = "https://www.imdb.com/title/tt1392190/",
                ImageURL = "https://m.media-amazon.com/images/M/MV5BZDRkODJhOTgtOTc1OC00NTgzLTk4NjItNDgxZDY4YjlmNDY2XkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg",
                Favourite = true,
                Duration = 120,
                Review = "Nice"
            },
            new Movie
            {
                Id = 8,
                Name = "Your Name",
                Status = MediaStatus.Completed,
                Description = "Two teenagers share a profound, magical connection upon discovering they are swapping bodies. Things manage to become even more complicated when the boy and girl decide to meet in person.",
                Director = "Makoto Shinkai",
                ReleaseDate = 2016,
                Rating = "10/10",
                URL = "https://www.imdb.com/title/tt5311514/",
                ImageURL = "https://m.media-amazon.com/images/M/MV5BMTIyNzFjNzItZmQ1MC00NzhjLThmMzYtZjRhN2Y3MmM2OGQyXkEyXkFqcGc@._V1_.jpg",
                Favourite = true,
                Duration = 116,
                Review = "Peak"
            }
        );
    }
}
