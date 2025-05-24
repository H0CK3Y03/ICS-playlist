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
                Id = 8,
                Name = "Breaking Bad",
                NumberOfEpisodes = 62,
                Status = MediaStatus.Completed,
                Description = "A chemistry teacher turned drug-lord teams up with a former student to build a methamphetamine empire.",
                Director = "Vince Gilligan",
                ReleaseDate = 2008,
                Rating = "10/10",
                URL = "https://www.imdb.com/title/tt0903747/",
                Favourite = true,
                Duration = 0,
            },
            new Series
            {
                Id = 9,
                Name = "Stranger Things",
                NumberOfEpisodes = 34,
                Status = MediaStatus.Watching,
                Description = "A group of friends in the 1980s uncover supernatural mysteries and government conspiracies in their small town.",
                Director = "The Duffer Brothers",
                ReleaseDate = 2016,
                Rating = "8/10",
                URL = "https://www.imdb.com/title/tt4574334/",
                Favourite = true,
                Duration = 0,
            },
            new Series
            {
                Id = 10,
                Name = "The Office (US)",
                NumberOfEpisodes = 201,
                Status = MediaStatus.Completed,
                Description = "A mockumentary about the daily lives of employees at the Dunder Mifflin paper company.",
                Director = "Greg Daniels",
                ReleaseDate = 2005,
                Rating = "9/10",
                URL = "https://www.imdb.com/title/tt0386676/",
                Favourite = true,
                Duration = 0,
            },
            new Series
            {
                Id = 11,
                Name = "Game of Thrones",
                NumberOfEpisodes = 73,
                Status = MediaStatus.Completed,
                Description = "Noble families fight for control of the Iron Throne in a fantasy world filled with dragons and political intrigue.",
                Director = "David Benioff, D.B. Weiss",
                ReleaseDate = 2011,
                Rating = "9/10",
                URL = "https://www.imdb.com/title/tt0944947/",
                Favourite = true,
                Duration = 0,
            },
            new Series
            {
                Id = 12,
                Name = "The Mandalorian",
                NumberOfEpisodes = 24,
                Status = MediaStatus.Watching,
                Description = "A lone bounty hunter navigates the outer reaches of the galaxy, protecting a mysterious baby Yoda.",
                Director = "Jon Favreau",
                ReleaseDate = 2019,
                Rating = "6/10",
                URL = "https://www.imdb.com/title/tt8111088/",
                Favourite = false,
                Duration = 0,
            },
            new Series
            {
                Id = 13,
                Name = "Black Mirror",
                NumberOfEpisodes = 27,
                Status = MediaStatus.Watching,
                Description = "An anthology series exploring the dark side of technology and human nature in dystopian futures.",
                Director = "Charlie Brooker",
                ReleaseDate = 2011,
                Rating = "8/10",
                URL = "https://www.imdb.com/title/tt2085059/",
                Favourite = false,
                Duration = 0,
            },
            new Series
            {
                Id = 14,
                Name = "The Crown",
                NumberOfEpisodes = 60,
                Status = MediaStatus.PlanToWatch,
                Description = "A biographical drama chronicling the reign of Queen Elizabeth II and major historical events.",
                Director = "Peter Morgan",
                ReleaseDate = 2016,
                Rating = "-",
                URL = "https://www.imdb.com/title/tt4786824/",
                Favourite = false,
                Duration = 0,
            }
        );
    }
}
