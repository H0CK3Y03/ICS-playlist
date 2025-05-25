using System;
using Microsoft.EntityFrameworkCore;
using Vued.DAL.Entities;

namespace Vued.DAL.Seeds;

public static class SeriesSeed
{
    public static readonly Guid BreakingBadId = Guid.Parse("20000000-0000-0000-0000-000000000008");
    public static readonly Guid StrangerThingsId = Guid.Parse("20000000-0000-0000-0000-000000000009");
    public static readonly Guid OfficeUSId = Guid.Parse("20000000-0000-0000-0000-000000000010");
    public static readonly Guid GameOfThronesId = Guid.Parse("20000000-0000-0000-0000-000000000011");
    public static readonly Guid MandalorianId = Guid.Parse("20000000-0000-0000-0000-000000000012");
    public static readonly Guid BlackMirrorId = Guid.Parse("20000000-0000-0000-0000-000000000013");
    public static readonly Guid TheCrownId = Guid.Parse("20000000-0000-0000-0000-000000000014");

    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SeriesEntity>().HasData(
            new SeriesEntity
            {
                Id = BreakingBadId,
                Name = "Breaking Bad",
                NumberOfEpisodes = 62,
                Status = MediaStatus.Completed,
                Description = "A chemistry teacher turned drug-lord teams up with a former student to build a methamphetamine empire.",
                Director = "Vince Gilligan",
                ReleaseDate = 2008,
                Rating = "10/10",
                URL = "https://www.imdb.com/title/tt0903747/",
                Favourite = true,
                Duration = 0
            },
            new SeriesEntity
            {
                Id = StrangerThingsId,
                Name = "Stranger Things",
                NumberOfEpisodes = 34,
                Status = MediaStatus.Watching,
                Description = "A group of friends in the 1980s uncover supernatural mysteries and government conspiracies in their small town.",
                Director = "The Duffer Brothers",
                ReleaseDate = 2016,
                Rating = "8/10",
                URL = "https://www.imdb.com/title/tt4574334/",
                Favourite = true,
                Duration = 0
            },
            new SeriesEntity
            {
                Id = OfficeUSId,
                Name = "The Office (US)",
                NumberOfEpisodes = 201,
                Status = MediaStatus.Completed,
                Description = "A mockumentary about the daily lives of employees at the Dunder Mifflin paper company.",
                Director = "Greg Daniels",
                ReleaseDate = 2005,
                Rating = "9/10",
                URL = "https://www.imdb.com/title/tt0386676/",
                Favourite = true,
                Duration = 0
            },
            new SeriesEntity
            {
                Id = GameOfThronesId,
                Name = "Game of Thrones",
                NumberOfEpisodes = 73,
                Status = MediaStatus.Completed,
                Description = "Noble families fight for control of the Iron Throne in a fantasy world filled with dragons and political intrigue.",
                Director = "David Benioff, D.B. Weiss",
                ReleaseDate = 2011,
                Rating = "9/10",
                URL = "https://www.imdb.com/title/tt0944947/",
                Favourite = true,
                Duration = 0
            },
            new SeriesEntity
            {
                Id = MandalorianId,
                Name = "The Mandalorian",
                NumberOfEpisodes = 24,
                Status = MediaStatus.Watching,
                Description = "A lone bounty hunter navigates the outer reaches of the galaxy, protecting a mysterious baby Yoda.",
                Director = "Jon Favreau",
                ReleaseDate = 2019,
                Rating = "6/10",
                URL = "https://www.imdb.com/title/tt8111088/",
                Favourite = false,
                Duration = 0
            },
            new SeriesEntity
            {
                Id = BlackMirrorId,
                Name = "Black Mirror",
                NumberOfEpisodes = 27,
                Status = MediaStatus.Watching,
                Description = "An anthology series exploring the dark side of technology and human nature in dystopian futures.",
                Director = "Charlie Brooker",
                ReleaseDate = 2011,
                Rating = "8/10",
                URL = "https://www.imdb.com/title/tt2085059/",
                Favourite = false,
                Duration = 0
            },
            new SeriesEntity
            {
                Id = TheCrownId,
                Name = "The Crown",
                NumberOfEpisodes = 60,
                Status = MediaStatus.PlanToWatch,
                Description = "A biographical drama chronicling the reign of Queen Elizabeth II and major historical events.",
                Director = "Peter Morgan",
                ReleaseDate = 2016,
                Rating = "-",
                URL = "https://www.imdb.com/title/tt4786824/",
                Favourite = false,
                Duration = 0
            }
        );
    }
}
