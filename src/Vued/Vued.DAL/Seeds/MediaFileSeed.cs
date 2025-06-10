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
                ImageURL = "https://m.media-amazon.com/images/M/MV5BN2NmN2VhMTQtMDNiOS00NDlhLTliMjgtODE2ZTY0ODQyNDRhXkEyXkFqcGc@._V1_.jpg",
                Favourite = true,
                Duration = 136,
                Review = "Nice",
                MediaType = MediaType.Movie
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
                ImageURL = "https://storage.googleapis.com/pod_public/1300/266241.jpg",
                Favourite = true,
                Duration = 142,
                Review = "Cool",
                MediaType = MediaType.Movie
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
                ImageURL = "https://storage.googleapis.com/pod_public/1300/262806.jpg",
                Favourite = false,
                Duration = 144,
                Review = "Idk",
                MediaType = MediaType.Movie
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
                ImageURL = "https://www.vasefotka.cz/fotky22340/fotos/_vyr_271602026-Inception-Pocatek.jpg",
                Favourite = true,
                Duration = 148,
                Review = "Perfect",
                MediaType = MediaType.Movie
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
                ImageURL = "https://i5.walmartimages.com/seo/The-Godfather-Original-Movie-Poster-poster-Frameless-Gift-12-x-18-inch-30cm-x-46cm_c6df3fd5-1e9c-49ca-8cb6-1af6078df4c2.b21fd8bc877c5645b9340a53580833a2.jpeg",
                Favourite = true,
                Duration = 175,
                Review = "Nice",
                MediaType = MediaType.Movie
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
                ImageURL = "https://m.media-amazon.com/images/M/MV5BNTEyNmEwOWUtYzkyOC00ZTQ4LTllZmUtMjk0Y2YwOGUzYjRiXkEyXkFqcGc@._V1_.jpg",
                Favourite = false,
                Duration = 125,
                Review = "Nice",
                MediaType = MediaType.Movie
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
                ImageURL = "https://m.media-amazon.com/images/M/MV5BZDRkODJhOTgtOTc1OC00NTgzLTk4NjItNDgxZDY4YjlmNDY2XkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg",
                Favourite = true,
                Duration = 120,
                Review = "Nice",
                MediaType = MediaType.Movie
            },
            new MediaFile
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
                Review = "Peak",
                MediaType = MediaType.Movie
            },
            // Series
            new MediaFile
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
                Review = "Nice",
                MediaType = MediaType.Series
            },
            new MediaFile
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
                Review = "Nice",
                MediaType = MediaType.Series
            },
            new MediaFile
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
                Review = "Nice",
                MediaType = MediaType.Series
            },
            new MediaFile
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
                Review = "Nice",
                MediaType = MediaType.Series
            },
            new MediaFile
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
                Review = "Nice",
                MediaType = MediaType.Series
            },
            new MediaFile
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
                Review = "Nice",
                MediaType = MediaType.Series
            },
            new MediaFile
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
                Review = "Nice",
                MediaType = MediaType.Series
            },
            new MediaFile
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
                Review = "Nice",
                MediaType = MediaType.Series
            },
            new MediaFile
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
                Review = "Nice",
                MediaType = MediaType.Series
            }
        );
    }
}