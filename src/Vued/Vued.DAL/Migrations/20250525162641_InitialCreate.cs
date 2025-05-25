using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vued.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaFileEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Duration = table.Column<int>(type: "INTEGER", nullable: false),
                    Director = table.Column<string>(type: "TEXT", nullable: true),
                    ReleaseDate = table.Column<int>(type: "INTEGER", nullable: false),
                    Rating = table.Column<string>(type: "TEXT", nullable: true),
                    URL = table.Column<string>(type: "TEXT", nullable: true),
                    Favourite = table.Column<bool>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", maxLength: 21, nullable: false),
                    Length = table.Column<int>(type: "INTEGER", nullable: true),
                    NumberOfEpisodes = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaFileEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Watchlists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Watchlists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaFileGenreEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    MediaFileId = table.Column<Guid>(type: "TEXT", nullable: false),
                    GenreId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaFileGenreEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaFileGenreEntities_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaFileGenreEntities_MediaFileEntity_MediaFileId",
                        column: x => x.MediaFileId,
                        principalTable: "MediaFileEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WatchlistMediaFileEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    WatchlistId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MediaFileId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchlistMediaFileEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WatchlistMediaFileEntities_MediaFileEntity_MediaFileId",
                        column: x => x.MediaFileId,
                        principalTable: "MediaFileEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WatchlistMediaFileEntities_Watchlists_WatchlistId",
                        column: x => x.WatchlistId,
                        principalTable: "Watchlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "Action" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Comedy" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "Drama" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Horror" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "Sci-Fi" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "Fantasy" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "Adventure" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "Romance" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "Thriller" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "Mystery" },
                    { new Guid("00000000-0000-0000-0000-000000000011"), "Crime" },
                    { new Guid("00000000-0000-0000-0000-000000000012"), "Western" },
                    { new Guid("00000000-0000-0000-0000-000000000013"), "Historical" },
                    { new Guid("00000000-0000-0000-0000-000000000014"), "War" },
                    { new Guid("00000000-0000-0000-0000-000000000015"), "Documentary" },
                    { new Guid("00000000-0000-0000-0000-000000000016"), "Biography" },
                    { new Guid("00000000-0000-0000-0000-000000000017"), "Musical" },
                    { new Guid("00000000-0000-0000-0000-000000000018"), "Animation" },
                    { new Guid("00000000-0000-0000-0000-000000000019"), "Family" },
                    { new Guid("00000000-0000-0000-0000-000000000020"), "Sport" },
                    { new Guid("00000000-0000-0000-0000-000000000021"), "Superhero" },
                    { new Guid("00000000-0000-0000-0000-000000000022"), "Noir" },
                    { new Guid("00000000-0000-0000-0000-000000000023"), "Satire" },
                    { new Guid("00000000-0000-0000-0000-000000000024"), "Parody" },
                    { new Guid("00000000-0000-0000-0000-000000000025"), "Psychological" },
                    { new Guid("00000000-0000-0000-0000-000000000026"), "Post-Apocalyptic" },
                    { new Guid("00000000-0000-0000-0000-000000000027"), "Dystopian" },
                    { new Guid("00000000-0000-0000-0000-000000000028"), "Coming-of-Age" },
                    { new Guid("00000000-0000-0000-0000-000000000029"), "Epic" },
                    { new Guid("00000000-0000-0000-0000-000000000030"), "Period" },
                    { new Guid("00000000-0000-0000-0000-000000000031"), "Political" },
                    { new Guid("00000000-0000-0000-0000-000000000032"), "Slice of Life" },
                    { new Guid("00000000-0000-0000-0000-000000000033"), "Supernatural" },
                    { new Guid("00000000-0000-0000-0000-000000000034"), "Survival" },
                    { new Guid("00000000-0000-0000-0000-000000000035"), "Espionage" },
                    { new Guid("00000000-0000-0000-0000-000000000036"), "Heist" },
                    { new Guid("00000000-0000-0000-0000-000000000037"), "Disaster" },
                    { new Guid("00000000-0000-0000-0000-000000000038"), "Martial Arts" },
                    { new Guid("00000000-0000-0000-0000-000000000039"), "Road Movie" },
                    { new Guid("00000000-0000-0000-0000-000000000040"), "Anthology" },
                    { new Guid("00000000-0000-0000-0000-000000000041"), "Experimental" },
                    { new Guid("00000000-0000-0000-0000-000000000042"), "Gothic" },
                    { new Guid("00000000-0000-0000-0000-000000000043"), "Steampunk" },
                    { new Guid("00000000-0000-0000-0000-000000000044"), "Cyberpunk" },
                    { new Guid("00000000-0000-0000-0000-000000000045"), "Dark Comedy" },
                    { new Guid("00000000-0000-0000-0000-000000000046"), "Romantic Comedy" },
                    { new Guid("00000000-0000-0000-0000-000000000047"), "Tragedy" },
                    { new Guid("00000000-0000-0000-0000-000000000048"), "Melodrama" },
                    { new Guid("00000000-0000-0000-0000-000000000049"), "Mockumentary" },
                    { new Guid("00000000-0000-0000-0000-000000000050"), "Silent Film" }
                });

            migrationBuilder.InsertData(
                table: "MediaFileEntity",
                columns: new[] { "Id", "Description", "Director", "Discriminator", "Duration", "Favourite", "Length", "Name", "Rating", "ReleaseDate", "Status", "URL" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), "A computer hacker learns about the true nature of reality and joins a group of rebels to fight a war against powerful controllers.", "Lana Wachowski, Lilly Wachowski", "MovieEntity", 0, true, 136, "The Matrix", "8/10", 1999, 2, "https://www.imdb.com/title/tt0133093/" },
                    { new Guid("10000000-0000-0000-0000-000000000002"), "The life story of a man with a low IQ who achieves extraordinary feats through his kindness and determination.", "Robert Zemeckis", "MovieEntity", 0, true, 142, "Forrest Gump", "6/10", 1994, 2, "https://www.imdb.com/title/tt0109830/" },
                    { new Guid("10000000-0000-0000-0000-000000000003"), "A family heads to an isolated hotel for the winter where a sinister presence influences the father into violence.", "Stanley Kubrick", "MovieEntity", 0, false, 144, "The Shining", "7/10", 1980, 2, "https://www.imdb.com/title/tt0081505/" },
                    { new Guid("10000000-0000-0000-0000-000000000004"), "A skilled thief with the ability to enter dreams must pull off an impossible heist: planting an idea in someone's mind.", "Christopher Nolan", "MovieEntity", 0, true, 148, "Inception", "9/10", 2010, 2, "https://www.imdb.com/title/tt1375666/" },
                    { new Guid("10000000-0000-0000-0000-000000000005"), "The aging patriarch of an organized crime dynasty transfers control to his reluctant son.", "Francis Ford Coppola", "MovieEntity", 0, true, 175, "The Godfather", "8/10", 1972, 2, "https://www.imdb.com/title/tt0068646/" },
                    { new Guid("10000000-0000-0000-0000-000000000006"), "A young girl becomes trapped in a strange spirit world and must find a way to free herself and her parents.", "Hayao Miyazaki", "MovieEntity", 0, false, 125, "Spirited Away", "8/10", 2001, 2, "https://www.imdb.com/title/tt0245429/" },
                    { new Guid("10000000-0000-0000-0000-000000000007"), "In a post-apocalyptic wasteland, a drifter and a rebel leader fight to survive against a tyrannical ruler.", "George Miller", "MovieEntity", 0, true, 120, "Mad Max: Fury Road", "7/10", 2015, 2, "https://www.imdb.com/title/tt1392190/" }
                });

            migrationBuilder.InsertData(
                table: "MediaFileEntity",
                columns: new[] { "Id", "Description", "Director", "Discriminator", "Duration", "Favourite", "Name", "NumberOfEpisodes", "Rating", "ReleaseDate", "Status", "URL" },
                values: new object[,]
                {
                    { new Guid("20000000-0000-0000-0000-000000000008"), "A chemistry teacher turned drug-lord teams up with a former student to build a methamphetamine empire.", "Vince Gilligan", "SeriesEntity", 0, true, "Breaking Bad", 62, "10/10", 2008, 2, "https://www.imdb.com/title/tt0903747/" },
                    { new Guid("20000000-0000-0000-0000-000000000009"), "A group of friends in the 1980s uncover supernatural mysteries and government conspiracies in their small town.", "The Duffer Brothers", "SeriesEntity", 0, true, "Stranger Things", 34, "8/10", 2016, 1, "https://www.imdb.com/title/tt4574334/" },
                    { new Guid("20000000-0000-0000-0000-000000000010"), "A mockumentary about the daily lives of employees at the Dunder Mifflin paper company.", "Greg Daniels", "SeriesEntity", 0, true, "The Office (US)", 201, "9/10", 2005, 2, "https://www.imdb.com/title/tt0386676/" },
                    { new Guid("20000000-0000-0000-0000-000000000011"), "Noble families fight for control of the Iron Throne in a fantasy world filled with dragons and political intrigue.", "David Benioff, D.B. Weiss", "SeriesEntity", 0, true, "Game of Thrones", 73, "9/10", 2011, 2, "https://www.imdb.com/title/tt0944947/" },
                    { new Guid("20000000-0000-0000-0000-000000000012"), "A lone bounty hunter navigates the outer reaches of the galaxy, protecting a mysterious baby Yoda.", "Jon Favreau", "SeriesEntity", 0, false, "The Mandalorian", 24, "6/10", 2019, 1, "https://www.imdb.com/title/tt8111088/" },
                    { new Guid("20000000-0000-0000-0000-000000000013"), "An anthology series exploring the dark side of technology and human nature in dystopian futures.", "Charlie Brooker", "SeriesEntity", 0, false, "Black Mirror", 27, "8/10", 2011, 1, "https://www.imdb.com/title/tt2085059/" },
                    { new Guid("20000000-0000-0000-0000-000000000014"), "A biographical drama chronicling the reign of Queen Elizabeth II and major historical events.", "Peter Morgan", "SeriesEntity", 0, false, "The Crown", 60, "-", 2016, 0, "https://www.imdb.com/title/tt4786824/" }
                });

            migrationBuilder.InsertData(
                table: "Watchlists",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("30000000-0000-0000-0000-000000000001"), "Top-rated movies and series", "My Favorites" },
                    { new Guid("30000000-0000-0000-0000-000000000002"), "Movies and series to watch later", "Watch Later" }
                });

            migrationBuilder.InsertData(
                table: "MediaFileGenreEntities",
                columns: new[] { "Id", "GenreId", "MediaFileId" },
                values: new object[,]
                {
                    { new Guid("50000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("10000000-0000-0000-0000-000000000004") },
                    { new Guid("50000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000003"), new Guid("20000000-0000-0000-0000-000000000008") }
                });

            migrationBuilder.InsertData(
                table: "WatchlistMediaFileEntities",
                columns: new[] { "Id", "MediaFileId", "WatchlistId" },
                values: new object[,]
                {
                    { new Guid("40000000-0000-0000-0000-000000000001"), new Guid("10000000-0000-0000-0000-000000000004"), new Guid("30000000-0000-0000-0000-000000000001") },
                    { new Guid("40000000-0000-0000-0000-000000000002"), new Guid("20000000-0000-0000-0000-000000000008"), new Guid("30000000-0000-0000-0000-000000000002") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MediaFileGenreEntities_GenreId",
                table: "MediaFileGenreEntities",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFileGenreEntities_MediaFileId_GenreId",
                table: "MediaFileGenreEntities",
                columns: new[] { "MediaFileId", "GenreId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WatchlistMediaFileEntities_MediaFileId",
                table: "WatchlistMediaFileEntities",
                column: "MediaFileId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchlistMediaFileEntities_WatchlistId_MediaFileId",
                table: "WatchlistMediaFileEntities",
                columns: new[] { "WatchlistId", "MediaFileId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaFileGenreEntities");

            migrationBuilder.DropTable(
                name: "WatchlistMediaFileEntities");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "MediaFileEntity");

            migrationBuilder.DropTable(
                name: "Watchlists");
        }
    }
}
