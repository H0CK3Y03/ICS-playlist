using Vued.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Vued.DAL.Seeds;

public static class SeriesSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Series>().HasData(
            new Series
            {
                Id = 9,
                Name = "Breaking Bad",
                Status = MediaStatus.Completed,
                Description = "A chemistry teacher turned drug-lord teams up with a former student to build a methamphetamine empire.",
                Director = "Vince Gilligan",
                ReleaseDate = 2008,
                Rating = "10/10",
                URL = "https://www.imdb.com/title/tt0903747/",
                ImageURL = "https://m.media-amazon.com/images/I/91+GrGr5TWL._AC_UF894,1000_QL80_.jpg",
                Favourite = true,
                Duration = 62,
                Review = "Nice"
            },
            new Series
            {
                Id = 10,
                Name = "Stranger Things",
                Status = MediaStatus.Watching,
                Description = "A group of friends in the 1980s uncover supernatural mysteries and government conspiracies in their small town.",
                Director = "The Duffer Brothers",
                ReleaseDate = 2016,
                Rating = "8/10",
                URL = "https://www.imdb.com/title/tt4574334/",
                ImageURL = "https://static.posters.cz/image/1300/132239.jpg",
                Favourite = true,
                Duration = 34,
                Review = "Nice"
            },
            new Series
            {
                Id = 11,
                Name = "The Office (US)",
                Status = MediaStatus.Completed,
                Description = "A mockumentary about the daily lives of employees at the Dunder Mifflin paper company.",
                Director = "Greg Daniels",
                ReleaseDate = 2005,
                Rating = "9/10",
                URL = "https://www.imdb.com/title/tt0386676/",
                ImageURL = "https://m.media-amazon.com/images/M/MV5BZjQwYzBlYzUtZjhhOS00ZDQ0LWE0NzAtYTk4MjgzZTNkZWEzXkEyXkFqcGc@._V1_.jpg",
                Favourite = true,
                Duration = 201,
                Review = "Nice"
            },
            new Series
            {
                Id = 12,
                Name = "Game of Thrones",
                Status = MediaStatus.Completed,
                Description = "Noble families fight for control of the Iron Throne in a fantasy world filled with dragons and political intrigue.",
                Director = "David Benioff, D.B. Weiss",
                ReleaseDate = 2011,
                Rating = "9/10",
                URL = "https://www.imdb.com/title/tt0944947/",
                ImageURL = "https://static.posters.cz/image/1300/135455.jpg",
                Favourite = true,
                Duration = 73,
                Review = "Nice"
            },
            new Series
            {
                Id = 13,
                Name = "The Mandalorian",
                Status = MediaStatus.Watching,
                Description = "A lone bounty hunter navigates the outer reaches of the galaxy, protecting a mysterious baby Yoda.",
                Director = "Jon Favreau",
                ReleaseDate = 2019,
                Rating = "6/10",
                URL = "https://www.imdb.com/title/tt8111088/",
                ImageURL = "https://static.posters.cz/image/750/103406.jpg",
                Favourite = false,
                Duration = 24,
                Review = "Nice"
            },
            new Series
            {
                Id = 14,
                Name = "Black Mirror",
                Status = MediaStatus.Watching,
                Description = "An anthology series exploring the dark side of technology and human nature in dystopian futures.",
                Director = "Charlie Brooker",
                ReleaseDate = 2011,
                Rating = "8/10",
                URL = "https://www.imdb.com/title/tt2085059/",
                ImageURL = "https://m.media-amazon.com/images/M/MV5BODcxMWI2NDMtYTc3NC00OTZjLWFmNmUtM2NmY2I1ODkxYzczXkEyXkFqcGc@._V1_.jpg",
                Favourite = false,
                Duration = 27,
                Review = "Nice"
            },
            new Series
            {
                Id = 15,
                Name = "The Crown",
                Status = MediaStatus.PlanToWatch,
                Description = "A biographical drama chronicling the reign of Queen Elizabeth II and major historical events.",
                Director = "Peter Morgan",
                ReleaseDate = 2016,
                Rating = "-",
                URL = "https://www.imdb.com/title/tt4786824/",
                ImageURL = "https://image.tmdb.org/t/p/original/1M876KPjulVwppEpldhdc8V4o68.jpg",
                Favourite = false,
                Duration = 60,
                Review = "Nice"
            },
            new Series
            {
                Id = 16,
                Name = "Better Call Saul",
                Status = MediaStatus.Completed,
                Description = "The trials and tribulations of criminal lawyer Jimmy McGill in the years leading up to his fateful run-in with Walter White and Jesse Pinkman.",
                Director = "Peter Gould",
                ReleaseDate = 2015,
                Rating = "9/10",
                URL = "https://www.imdb.com/title/tt3032476/",
                ImageURL = "https://m.media-amazon.com/images/M/MV5BNDdjNTEzMjMtYjM3Mi00NzQ3LWFlNWMtZjdmYWU3ZDkzMjk1XkEyXkFqcGc@._V1_.jpg",
                Favourite = true,
                Duration = 63,
                Review = "Nice"
            },
            new Series
            {
                Id = 17,
                Name = "The House of the Dragon",
                Status = MediaStatus.Completed,
                Description = "An internal succession war within House Targaryen at the height of its power, 172 years before the birth of Daenerys Targaryen.",
                Director = "Ryan J. Condal",
                ReleaseDate = 2021,
                Rating = "9/10",
                URL = "https://www.imdb.com/title/tt11198330/",
                ImageURL = "https://m.media-amazon.com/images/M/MV5BYjBhMTU2N2EtYjVkYS00ODBiLTk3MDUtYWFmZTM2M2JkNzcwXkEyXkFqcGc@._V1_.jpg",
                Favourite = true,
                Duration = 60,
                Review = "Nice"
            }
        );
    }
}
