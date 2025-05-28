using Vued.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Vued.DAL.Seeds;

public static class MediaFileSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MediaFile>().HasData(
            // Movies
            new MediaFile
            {
                Id = 1,
                Name = "The Matrix",
                Status = MediaStatus.Completed,
                Description = "A computer hacker learns about the true nature of reality and joins a group of rebels to fight a war against powerful controllers.",
                Director = "Lana Wachowski, Lilly Wachowski",
                ReleaseDate = 1999,
                Rating = "8/10",
                URL = "https://www.imdb.com/title/tt0133093/",
                Favourite = true,
                Duration = 136,
                Type = MediaType.Movie,
                Review = "",
                ImageUrl = ""
            },
            new MediaFile
            {
                Id = 2,
                Name = "Forrest Gump",
                Status = MediaStatus.Completed,
                Description = "The life story of a man with a low IQ who achieves extraordinary feats through his kindness and determination.",
                Director = "Robert Zemeckis",
                ReleaseDate = 1994,
                Rating = "6/10",
                URL = "https://www.imdb.com/title/tt0109830/",
                Favourite = true,
                Duration = 142,
                Type = MediaType.Movie,
                Review = "",
                ImageUrl = ""
            },
            new MediaFile
            {
                Id = 3,
                Name = "The Shining",
                Status = MediaStatus.Completed,
                Description = "A family heads to an isolated hotel for the winter where a sinister presence influences the father into violence.",
                Director = "Stanley Kubrick",
                ReleaseDate = 1980,
                Rating = "7/10",
                URL = "https://www.imdb.com/title/tt0081505/",
                Favourite = false,
                Duration = 144,
                Type = MediaType.Movie,
                Review = "",
                ImageUrl = ""
            },
            new MediaFile
            {
                Id = 4,
                Name = "Inception",
                Status = MediaStatus.Completed,
                Description = "A skilled thief with the ability to enter dreams must pull off an impossible heist: planting an idea in someone's mind.",
                Director = "Christopher Nolan",
                ReleaseDate = 2010,
                Rating = "9/10",
                URL = "https://www.imdb.com/title/tt1375666/",
                Favourite = true,
                Duration = 148,
                Type = MediaType.Movie,
                Review = "",
                ImageUrl = ""
            },
            new MediaFile
            {
                Id = 5,
                Name = "The Godfather",
                Status = MediaStatus.Completed,
                Description = "The aging patriarch of an organized crime dynasty transfers control to his reluctant son.",
                Director = "Francis Ford Coppola",
                ReleaseDate = 1972,
                Rating = "8/10",
                URL = "https://www.imdb.com/title/tt0068646/",
                Favourite = true,
                Duration = 175,
                Type = MediaType.Movie,
                Review = "",
                ImageUrl = ""
            },
            new MediaFile
            {
                Id = 6,
                Name = "Spirited Away",
                Status = MediaStatus.Completed,
                Description = "A young girl becomes trapped in a strange spirit world and must find a way to free herself and her parents.",
                Director = "Hayao Miyazaki",
                ReleaseDate = 2001,
                Rating = "8/10",
                URL = "https://www.imdb.com/title/tt0245429/",
                Favourite = false,
                Duration = 125,
                Type = MediaType.Movie,
                Review = "",
                ImageUrl = ""
            },
            new MediaFile
            {
                Id = 7,
                Name = "Mad Max: Fury Road",
                Status = MediaStatus.Completed,
                Description = "In a post-apocalyptic wasteland, a drifter and a rebel leader fight to survive against a tyrannical ruler.",
                Director = "George Miller",
                ReleaseDate = 2015,
                Rating = "7/10",
                URL = "https://www.imdb.com/title/tt1392190/",
                Favourite = true,
                Duration = 120,
                Type = MediaType.Movie,
                Review = "",
                ImageUrl = ""
            },
            // Series
            new MediaFile
            {
                Id = 8,
                Name = "Breaking Bad",
                Status = MediaStatus.Completed,
                Description = "A chemistry teacher turned drug-lord teams up with a former student to build a methamphetamine empire.",
                Director = "Vince Gilligan",
                ReleaseDate = 2008,
                Rating = "10/10",
                URL = "https://www.imdb.com/title/tt0903747/",
                Favourite = true,
                Duration = 62,
                Type = MediaType.Series,
                Review = "",
                ImageUrl = ""
            },
            new MediaFile
            {
                Id = 9,
                Name = "Stranger Things",
                Status = MediaStatus.Watching,
                Description = "A group of friends in the 1980s uncover supernatural mysteries and government conspiracies in their small town.",
                Director = "The Duffer Brothers",
                ReleaseDate = 2016,
                Rating = "8/10",
                URL = "https://www.imdb.com/title/tt4574334/",
                Favourite = true,
                Duration = 34,
                Type = MediaType.Series,
                Review = "",
                ImageUrl = ""
            },
            new MediaFile
            {
                Id = 10,
                Name = "The Office (US)",
                Status = MediaStatus.Completed,
                Description = "A mockumentary about the daily lives of employees at the Dunder Mifflin paper company.",
                Director = "Greg Daniels",
                ReleaseDate = 2005,
                Rating = "9/10",
                URL = "https://www.imdb.com/title/tt0386676/",
                Favourite = true,
                Duration = 201,
                Type = MediaType.Series,
                Review = "",
                ImageUrl = ""
            },
            new MediaFile
            {
                Id = 11,
                Name = "Game of Thrones",
                Status = MediaStatus.Completed,
                Description = "Noble families fight for control of the Iron Throne in a fantasy world filled with dragons and political intrigue.",
                Director = "David Benioff, D.B. Weiss",
                ReleaseDate = 2011,
                Rating = "9/10",
                URL = "https://www.imdb.com/title/tt0944947/",
                Favourite = true,
                Duration = 73,
                Type = MediaType.Series,
                Review = "",
                ImageUrl = ""
            },
            new MediaFile
            {
                Id = 12,
                Name = "The Mandalorian",
                Status = MediaStatus.Watching,
                Description = "A lone bounty hunter navigates the outer reaches of the galaxy, protecting a mysterious baby Yoda.",
                Director = "Jon Favreau",
                ReleaseDate = 2019,
                Rating = "6/10",
                URL = "https://www.imdb.com/title/tt8111088/",
                Favourite = false,
                Duration = 24,
                Type = MediaType.Series,
                Review = "",
                ImageUrl = ""
            },
            new MediaFile
            {
                Id = 13,
                Name = "Black Mirror",
                Status = MediaStatus.Watching,
                Description = "An anthology series exploring the dark side of technology and human nature in dystopian futures.",
                Director = "Charlie Brooker",
                ReleaseDate = 2011,
                Rating = "8/10",
                URL = "https://www.imdb.com/title/tt2085059/",
                Favourite = false,
                Duration = 27,
                Type = MediaType.Series,
                Review = "",
                ImageUrl = ""
            },
            new MediaFile
            {
                Id = 14,
                Name = "The Crown",
                Status = MediaStatus.PlanToWatch,
                Description = "A biographical drama chronicling the reign of Queen Elizabeth II and major historical events.",
                Director = "Peter Morgan",
                ReleaseDate = 2016,
                Rating = "-",
                URL = "https://www.imdb.com/title/tt4786824/",
                Favourite = false,
                Duration = 60,
                Type = MediaType.Series,
                Review = "",
                ImageUrl = ""
            }
        );
    }
}