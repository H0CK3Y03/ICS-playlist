﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vued.DAL;

#nullable disable

namespace Vued.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250610225917_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("GenreMediaFile", b =>
                {
                    b.Property<int>("GenresId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MediaFilesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GenresId", "MediaFilesId");

                    b.HasIndex("MediaFilesId");

                    b.ToTable("GenreMediaFile");

                    b.HasData(
                        new
                        {
                            GenresId = 1,
                            MediaFilesId = 1
                        },
                        new
                        {
                            GenresId = 5,
                            MediaFilesId = 1
                        },
                        new
                        {
                            GenresId = 3,
                            MediaFilesId = 2
                        },
                        new
                        {
                            GenresId = 8,
                            MediaFilesId = 2
                        },
                        new
                        {
                            GenresId = 4,
                            MediaFilesId = 3
                        },
                        new
                        {
                            GenresId = 9,
                            MediaFilesId = 3
                        },
                        new
                        {
                            GenresId = 5,
                            MediaFilesId = 4
                        },
                        new
                        {
                            GenresId = 9,
                            MediaFilesId = 4
                        },
                        new
                        {
                            GenresId = 11,
                            MediaFilesId = 5
                        },
                        new
                        {
                            GenresId = 3,
                            MediaFilesId = 5
                        },
                        new
                        {
                            GenresId = 6,
                            MediaFilesId = 6
                        },
                        new
                        {
                            GenresId = 18,
                            MediaFilesId = 6
                        },
                        new
                        {
                            GenresId = 1,
                            MediaFilesId = 7
                        },
                        new
                        {
                            GenresId = 26,
                            MediaFilesId = 7
                        },
                        new
                        {
                            GenresId = 5,
                            MediaFilesId = 8
                        },
                        new
                        {
                            GenresId = 3,
                            MediaFilesId = 8
                        },
                        new
                        {
                            GenresId = 8,
                            MediaFilesId = 9
                        },
                        new
                        {
                            GenresId = 47,
                            MediaFilesId = 9
                        },
                        new
                        {
                            GenresId = 3,
                            MediaFilesId = 10
                        },
                        new
                        {
                            GenresId = 25,
                            MediaFilesId = 10
                        },
                        new
                        {
                            GenresId = 9,
                            MediaFilesId = 11
                        },
                        new
                        {
                            GenresId = 23,
                            MediaFilesId = 11
                        },
                        new
                        {
                            GenresId = 1,
                            MediaFilesId = 12
                        },
                        new
                        {
                            GenresId = 13,
                            MediaFilesId = 12
                        },
                        new
                        {
                            GenresId = 5,
                            MediaFilesId = 13
                        },
                        new
                        {
                            GenresId = 6,
                            MediaFilesId = 13
                        },
                        new
                        {
                            GenresId = 14,
                            MediaFilesId = 14
                        },
                        new
                        {
                            GenresId = 16,
                            MediaFilesId = 14
                        });
                });

            modelBuilder.Entity("MediaFileWatchlist", b =>
                {
                    b.Property<int>("MediaFilesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WatchlistsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MediaFilesId", "WatchlistsId");

                    b.HasIndex("WatchlistsId");

                    b.ToTable("MediaFileWatchlist");

                    b.HasData(
                        new
                        {
                            MediaFilesId = 1,
                            WatchlistsId = 1
                        },
                        new
                        {
                            MediaFilesId = 4,
                            WatchlistsId = 1
                        },
                        new
                        {
                            MediaFilesId = 5,
                            WatchlistsId = 1
                        },
                        new
                        {
                            MediaFilesId = 6,
                            WatchlistsId = 1
                        },
                        new
                        {
                            MediaFilesId = 8,
                            WatchlistsId = 1
                        },
                        new
                        {
                            MediaFilesId = 9,
                            WatchlistsId = 1
                        },
                        new
                        {
                            MediaFilesId = 10,
                            WatchlistsId = 1
                        },
                        new
                        {
                            MediaFilesId = 12,
                            WatchlistsId = 1
                        },
                        new
                        {
                            MediaFilesId = 14,
                            WatchlistsId = 1
                        },
                        new
                        {
                            MediaFilesId = 16,
                            WatchlistsId = 1
                        },
                        new
                        {
                            MediaFilesId = 2,
                            WatchlistsId = 2
                        },
                        new
                        {
                            MediaFilesId = 4,
                            WatchlistsId = 2
                        },
                        new
                        {
                            MediaFilesId = 5,
                            WatchlistsId = 2
                        },
                        new
                        {
                            MediaFilesId = 6,
                            WatchlistsId = 2
                        },
                        new
                        {
                            MediaFilesId = 1,
                            WatchlistsId = 3
                        },
                        new
                        {
                            MediaFilesId = 3,
                            WatchlistsId = 3
                        },
                        new
                        {
                            MediaFilesId = 9,
                            WatchlistsId = 3
                        },
                        new
                        {
                            MediaFilesId = 11,
                            WatchlistsId = 3
                        },
                        new
                        {
                            MediaFilesId = 6,
                            WatchlistsId = 3
                        });
                });

            modelBuilder.Entity("Vued.DAL.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Comedy"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Drama"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Sci-Fi"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Romance"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Thriller"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Mystery"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Crime"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Western"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Historical"
                        },
                        new
                        {
                            Id = 14,
                            Name = "War"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Documentary"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Biography"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Musical"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Animation"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Family"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Sport"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Superhero"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Noir"
                        },
                        new
                        {
                            Id = 23,
                            Name = "Satire"
                        },
                        new
                        {
                            Id = 24,
                            Name = "Parody"
                        },
                        new
                        {
                            Id = 25,
                            Name = "Psychological"
                        },
                        new
                        {
                            Id = 26,
                            Name = "Post-Apocalyptic"
                        },
                        new
                        {
                            Id = 27,
                            Name = "Dystopian"
                        },
                        new
                        {
                            Id = 28,
                            Name = "Coming-of-Age"
                        },
                        new
                        {
                            Id = 29,
                            Name = "Epic"
                        },
                        new
                        {
                            Id = 30,
                            Name = "Period"
                        },
                        new
                        {
                            Id = 31,
                            Name = "Political"
                        },
                        new
                        {
                            Id = 32,
                            Name = "Slice of Life"
                        },
                        new
                        {
                            Id = 33,
                            Name = "Supernatural"
                        },
                        new
                        {
                            Id = 34,
                            Name = "Survival"
                        },
                        new
                        {
                            Id = 35,
                            Name = "Espionage"
                        },
                        new
                        {
                            Id = 36,
                            Name = "Heist"
                        },
                        new
                        {
                            Id = 37,
                            Name = "Disaster"
                        },
                        new
                        {
                            Id = 38,
                            Name = "Martial Arts"
                        },
                        new
                        {
                            Id = 39,
                            Name = "Road Movie"
                        },
                        new
                        {
                            Id = 40,
                            Name = "Anthology"
                        },
                        new
                        {
                            Id = 41,
                            Name = "Experimental"
                        },
                        new
                        {
                            Id = 42,
                            Name = "Gothic"
                        },
                        new
                        {
                            Id = 43,
                            Name = "Steampunk"
                        },
                        new
                        {
                            Id = 44,
                            Name = "Cyberpunk"
                        },
                        new
                        {
                            Id = 45,
                            Name = "Dark Comedy"
                        },
                        new
                        {
                            Id = 46,
                            Name = "Romantic Comedy"
                        },
                        new
                        {
                            Id = 47,
                            Name = "Tragedy"
                        },
                        new
                        {
                            Id = 48,
                            Name = "Melodrama"
                        },
                        new
                        {
                            Id = 49,
                            Name = "Mockumentary"
                        },
                        new
                        {
                            Id = 50,
                            Name = "Silent Film"
                        });
                });

            modelBuilder.Entity("Vued.DAL.Entities.MediaFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Director")
                        .HasColumnType("TEXT");

                    b.Property<int>("Duration")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Favourite")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageURL")
                        .HasColumnType("TEXT");

                    b.Property<int>("MediaType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Rating")
                        .HasColumnType("TEXT");

                    b.Property<int>("ReleaseDate")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Review")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("URL")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MediaFiles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A computer hacker learns about the true nature of reality and joins a group of rebels to fight a war against powerful controllers.",
                            Director = "Lana Wachowski, Lilly Wachowski",
                            Duration = 136,
                            Favourite = true,
                            ImageURL = "https://m.media-amazon.com/images/M/MV5BN2NmN2VhMTQtMDNiOS00NDlhLTliMjgtODE2ZTY0ODQyNDRhXkEyXkFqcGc@._V1_.jpg",
                            MediaType = 0,
                            Name = "The Matrix",
                            Rating = "8/10",
                            ReleaseDate = 1999,
                            Review = "Nice",
                            Status = 2,
                            URL = "https://www.imdb.com/title/tt0133093/"
                        },
                        new
                        {
                            Id = 2,
                            Description = "The life story of a man with a low IQ who achieves extraordinary feats through his kindness and determination.",
                            Director = "Robert Zemeckis",
                            Duration = 142,
                            Favourite = true,
                            ImageURL = "https://storage.googleapis.com/pod_public/1300/266241.jpg",
                            MediaType = 0,
                            Name = "Forrest Gump",
                            Rating = "6/10",
                            ReleaseDate = 1994,
                            Review = "Cool",
                            Status = 2,
                            URL = "https://www.imdb.com/title/tt0109830/"
                        },
                        new
                        {
                            Id = 3,
                            Description = "A family heads to an isolated hotel for the winter where a sinister presence influences the father into violence.",
                            Director = "Stanley Kubrick",
                            Duration = 144,
                            Favourite = false,
                            ImageURL = "https://storage.googleapis.com/pod_public/1300/262806.jpg",
                            MediaType = 0,
                            Name = "The Shining",
                            Rating = "7/10",
                            ReleaseDate = 1980,
                            Review = "Idk",
                            Status = 2,
                            URL = "https://www.imdb.com/title/tt0081505/"
                        },
                        new
                        {
                            Id = 4,
                            Description = "A skilled thief with the ability to enter dreams must pull off an impossible heist: planting an idea in someone's mind.",
                            Director = "Christopher Nolan",
                            Duration = 148,
                            Favourite = true,
                            ImageURL = "https://www.vasefotka.cz/fotky22340/fotos/_vyr_271602026-Inception-Pocatek.jpg",
                            MediaType = 0,
                            Name = "Inception",
                            Rating = "9/10",
                            ReleaseDate = 2010,
                            Review = "Perfect",
                            Status = 2,
                            URL = "https://www.imdb.com/title/tt1375666/"
                        },
                        new
                        {
                            Id = 5,
                            Description = "The aging patriarch of an organized crime dynasty transfers control to his reluctant son.",
                            Director = "Francis Ford Coppola",
                            Duration = 175,
                            Favourite = true,
                            ImageURL = "https://i5.walmartimages.com/seo/The-Godfather-Original-Movie-Poster-poster-Frameless-Gift-12-x-18-inch-30cm-x-46cm_c6df3fd5-1e9c-49ca-8cb6-1af6078df4c2.b21fd8bc877c5645b9340a53580833a2.jpeg",
                            MediaType = 0,
                            Name = "The Godfather",
                            Rating = "8/10",
                            ReleaseDate = 1972,
                            Review = "Nice",
                            Status = 2,
                            URL = "https://www.imdb.com/title/tt0068646/"
                        },
                        new
                        {
                            Id = 6,
                            Description = "A young girl becomes trapped in a strange spirit world and must find a way to free herself and her parents.",
                            Director = "Hayao Miyazaki",
                            Duration = 125,
                            Favourite = false,
                            ImageURL = "https://m.media-amazon.com/images/M/MV5BNTEyNmEwOWUtYzkyOC00ZTQ4LTllZmUtMjk0Y2YwOGUzYjRiXkEyXkFqcGc@._V1_.jpg",
                            MediaType = 0,
                            Name = "Spirited Away",
                            Rating = "8/10",
                            ReleaseDate = 2001,
                            Review = "Nice",
                            Status = 2,
                            URL = "https://www.imdb.com/title/tt0245429/"
                        },
                        new
                        {
                            Id = 7,
                            Description = "In a post-apocalyptic wasteland, a drifter and a rebel leader fight to survive against a tyrannical ruler.",
                            Director = "George Miller",
                            Duration = 120,
                            Favourite = true,
                            ImageURL = "https://m.media-amazon.com/images/M/MV5BZDRkODJhOTgtOTc1OC00NTgzLTk4NjItNDgxZDY4YjlmNDY2XkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg",
                            MediaType = 0,
                            Name = "Mad Max: Fury Road",
                            Rating = "7/10",
                            ReleaseDate = 2015,
                            Review = "Nice",
                            Status = 2,
                            URL = "https://www.imdb.com/title/tt1392190/"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Two teenagers share a profound, magical connection upon discovering they are swapping bodies. Things manage to become even more complicated when the boy and girl decide to meet in person.",
                            Director = "Makoto Shinkai",
                            Duration = 116,
                            Favourite = true,
                            ImageURL = "https://m.media-amazon.com/images/M/MV5BMTIyNzFjNzItZmQ1MC00NzhjLThmMzYtZjRhN2Y3MmM2OGQyXkEyXkFqcGc@._V1_.jpg",
                            MediaType = 0,
                            Name = "Your Name",
                            Rating = "10/10",
                            ReleaseDate = 2016,
                            Review = "Peak",
                            Status = 2,
                            URL = "https://www.imdb.com/title/tt5311514/"
                        },
                        new
                        {
                            Id = 9,
                            Description = "A chemistry teacher turned drug-lord teams up with a former student to build a methamphetamine empire.",
                            Director = "Vince Gilligan",
                            Duration = 62,
                            Favourite = true,
                            ImageURL = "https://m.media-amazon.com/images/I/91+GrGr5TWL._AC_UF894,1000_QL80_.jpg",
                            MediaType = 1,
                            Name = "Breaking Bad",
                            Rating = "10/10",
                            ReleaseDate = 2008,
                            Review = "Nice",
                            Status = 2,
                            URL = "https://www.imdb.com/title/tt0903747/"
                        },
                        new
                        {
                            Id = 10,
                            Description = "A group of friends in the 1980s uncover supernatural mysteries and government conspiracies in their small town.",
                            Director = "The Duffer Brothers",
                            Duration = 34,
                            Favourite = true,
                            ImageURL = "https://static.posters.cz/image/1300/132239.jpg",
                            MediaType = 1,
                            Name = "Stranger Things",
                            Rating = "8/10",
                            ReleaseDate = 2016,
                            Review = "Nice",
                            Status = 1,
                            URL = "https://www.imdb.com/title/tt4574334/"
                        },
                        new
                        {
                            Id = 11,
                            Description = "A mockumentary about the daily lives of employees at the Dunder Mifflin paper company.",
                            Director = "Greg Daniels",
                            Duration = 201,
                            Favourite = true,
                            ImageURL = "https://m.media-amazon.com/images/M/MV5BZjQwYzBlYzUtZjhhOS00ZDQ0LWE0NzAtYTk4MjgzZTNkZWEzXkEyXkFqcGc@._V1_.jpg",
                            MediaType = 1,
                            Name = "The Office (US)",
                            Rating = "9/10",
                            ReleaseDate = 2005,
                            Review = "Nice",
                            Status = 2,
                            URL = "https://www.imdb.com/title/tt0386676/"
                        },
                        new
                        {
                            Id = 12,
                            Description = "Noble families fight for control of the Iron Throne in a fantasy world filled with dragons and political intrigue.",
                            Director = "David Benioff, D.B. Weiss",
                            Duration = 73,
                            Favourite = true,
                            ImageURL = "https://static.posters.cz/image/1300/135455.jpg",
                            MediaType = 1,
                            Name = "Game of Thrones",
                            Rating = "9/10",
                            ReleaseDate = 2011,
                            Review = "Nice",
                            Status = 2,
                            URL = "https://www.imdb.com/title/tt0944947/"
                        },
                        new
                        {
                            Id = 13,
                            Description = "A lone bounty hunter navigates the outer reaches of the galaxy, protecting a mysterious baby Yoda.",
                            Director = "Jon Favreau",
                            Duration = 24,
                            Favourite = false,
                            ImageURL = "https://static.posters.cz/image/750/103406.jpg",
                            MediaType = 1,
                            Name = "The Mandalorian",
                            Rating = "6/10",
                            ReleaseDate = 2019,
                            Review = "Nice",
                            Status = 1,
                            URL = "https://www.imdb.com/title/tt8111088/"
                        },
                        new
                        {
                            Id = 14,
                            Description = "An anthology series exploring the dark side of technology and human nature in dystopian futures.",
                            Director = "Charlie Brooker",
                            Duration = 27,
                            Favourite = false,
                            ImageURL = "https://m.media-amazon.com/images/M/MV5BODcxMWI2NDMtYTc3NC00OTZjLWFmNmUtM2NmY2I1ODkxYzczXkEyXkFqcGc@._V1_.jpg",
                            MediaType = 1,
                            Name = "Black Mirror",
                            Rating = "8/10",
                            ReleaseDate = 2011,
                            Review = "Nice",
                            Status = 1,
                            URL = "https://www.imdb.com/title/tt2085059/"
                        },
                        new
                        {
                            Id = 15,
                            Description = "A biographical drama chronicling the reign of Queen Elizabeth II and major historical events.",
                            Director = "Peter Morgan",
                            Duration = 60,
                            Favourite = false,
                            ImageURL = "https://image.tmdb.org/t/p/original/1M876KPjulVwppEpldhdc8V4o68.jpg",
                            MediaType = 1,
                            Name = "The Crown",
                            Rating = "-",
                            ReleaseDate = 2016,
                            Review = "Nice",
                            Status = 0,
                            URL = "https://www.imdb.com/title/tt4786824/"
                        },
                        new
                        {
                            Id = 16,
                            Description = "The trials and tribulations of criminal lawyer Jimmy McGill in the years leading up to his fateful run-in with Walter White and Jesse Pinkman.",
                            Director = "Peter Gould",
                            Duration = 63,
                            Favourite = true,
                            ImageURL = "https://m.media-amazon.com/images/M/MV5BNDdjNTEzMjMtYjM3Mi00NzQ3LWFlNWMtZjdmYWU3ZDkzMjk1XkEyXkFqcGc@._V1_.jpg",
                            MediaType = 1,
                            Name = "Better Call Saul",
                            Rating = "9/10",
                            ReleaseDate = 2015,
                            Review = "Nice",
                            Status = 2,
                            URL = "https://www.imdb.com/title/tt3032476/"
                        },
                        new
                        {
                            Id = 17,
                            Description = "An internal succession war within House Targaryen at the height of its power, 172 years before the birth of Daenerys Targaryen.",
                            Director = "Ryan J. Condal",
                            Duration = 60,
                            Favourite = true,
                            ImageURL = "https://m.media-amazon.com/images/M/MV5BYjBhMTU2N2EtYjVkYS00ODBiLTk3MDUtYWFmZTM2M2JkNzcwXkEyXkFqcGc@._V1_.jpg",
                            MediaType = 1,
                            Name = "The House of the Dragon",
                            Rating = "9/10",
                            ReleaseDate = 2021,
                            Review = "Nice",
                            Status = 2,
                            URL = "https://www.imdb.com/title/tt11198330/"
                        });
                });

            modelBuilder.Entity("Vued.DAL.Entities.Watchlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Watchlists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Top-rated movies and series",
                            Name = "My Favorites"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Movies and series to watch later",
                            Name = "Watch Later"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Series I always want to watch",
                            Name = "Old Series"
                        });
                });

            modelBuilder.Entity("GenreMediaFile", b =>
                {
                    b.HasOne("Vued.DAL.Entities.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vued.DAL.Entities.MediaFile", null)
                        .WithMany()
                        .HasForeignKey("MediaFilesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MediaFileWatchlist", b =>
                {
                    b.HasOne("Vued.DAL.Entities.MediaFile", null)
                        .WithMany()
                        .HasForeignKey("MediaFilesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vued.DAL.Entities.Watchlist", null)
                        .WithMany()
                        .HasForeignKey("WatchlistsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
