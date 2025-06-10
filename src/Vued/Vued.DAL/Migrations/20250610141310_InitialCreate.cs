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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Duration = table.Column<int>(type: "INTEGER", nullable: false),
                    Director = table.Column<string>(type: "TEXT", nullable: true),
                    ReleaseDate = table.Column<int>(type: "INTEGER", nullable: false),
                    Rating = table.Column<string>(type: "TEXT", nullable: true),
                    URL = table.Column<string>(type: "TEXT", nullable: true),
                    ImageURL = table.Column<string>(type: "TEXT", nullable: true),
                    Favourite = table.Column<bool>(type: "INTEGER", nullable: false),
                    Review = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Watchlists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Watchlists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenreMediaFile",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "INTEGER", nullable: false),
                    MediaFilesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMediaFile", x => new { x.GenresId, x.MediaFilesId });
                    table.ForeignKey(
                        name: "FK_GenreMediaFile_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMediaFile_MediaFiles_MediaFilesId",
                        column: x => x.MediaFilesId,
                        principalTable: "MediaFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaFileWatchlist",
                columns: table => new
                {
                    MediaFilesId = table.Column<int>(type: "INTEGER", nullable: false),
                    WatchlistsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaFileWatchlist", x => new { x.MediaFilesId, x.WatchlistsId });
                    table.ForeignKey(
                        name: "FK_MediaFileWatchlist_MediaFiles_MediaFilesId",
                        column: x => x.MediaFilesId,
                        principalTable: "MediaFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaFileWatchlist_Watchlists_WatchlistsId",
                        column: x => x.WatchlistsId,
                        principalTable: "Watchlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Comedy" },
                    { 3, "Drama" },
                    { 4, "Horror" },
                    { 5, "Sci-Fi" },
                    { 6, "Fantasy" },
                    { 7, "Adventure" },
                    { 8, "Romance" },
                    { 9, "Thriller" },
                    { 10, "Mystery" },
                    { 11, "Crime" },
                    { 12, "Western" },
                    { 13, "Historical" },
                    { 14, "War" },
                    { 15, "Documentary" },
                    { 16, "Biography" },
                    { 17, "Musical" },
                    { 18, "Animation" },
                    { 19, "Family" },
                    { 20, "Sport" },
                    { 21, "Superhero" },
                    { 22, "Noir" },
                    { 23, "Satire" },
                    { 24, "Parody" },
                    { 25, "Psychological" },
                    { 26, "Post-Apocalyptic" },
                    { 27, "Dystopian" },
                    { 28, "Coming-of-Age" },
                    { 29, "Epic" },
                    { 30, "Period" },
                    { 31, "Political" },
                    { 32, "Slice of Life" },
                    { 33, "Supernatural" },
                    { 34, "Survival" },
                    { 35, "Espionage" },
                    { 36, "Heist" },
                    { 37, "Disaster" },
                    { 38, "Martial Arts" },
                    { 39, "Road Movie" },
                    { 40, "Anthology" },
                    { 41, "Experimental" },
                    { 42, "Gothic" },
                    { 43, "Steampunk" },
                    { 44, "Cyberpunk" },
                    { 45, "Dark Comedy" },
                    { 46, "Romantic Comedy" },
                    { 47, "Tragedy" },
                    { 48, "Melodrama" },
                    { 49, "Mockumentary" },
                    { 50, "Silent Film" }
                });

            migrationBuilder.InsertData(
                table: "MediaFiles",
                columns: new[] { "Id", "Description", "Director", "Duration", "Favourite", "ImageURL", "Name", "Rating", "ReleaseDate", "Review", "Status", "URL" },
                values: new object[,]
                {
                    { 1, "A computer hacker learns about the true nature of reality and joins a group of rebels to fight a war against powerful controllers.", "Lana Wachowski, Lilly Wachowski", 136, true, "https://m.media-amazon.com/images/M/MV5BN2NmN2VhMTQtMDNiOS00NDlhLTliMjgtODE2ZTY0ODQyNDRhXkEyXkFqcGc@._V1_.jpg", "The Matrix", "8/10", 1999, "Nice", 2, "https://www.imdb.com/title/tt0133093/" },
                    { 2, "The life story of a man with a low IQ who achieves extraordinary feats through his kindness and determination.", "Robert Zemeckis", 142, true, "https://storage.googleapis.com/pod_public/1300/266241.jpg", "Forrest Gump", "6/10", 1994, "Cool", 2, "https://www.imdb.com/title/tt0109830/" },
                    { 3, "A family heads to an isolated hotel for the winter where a sinister presence influences the father into violence.", "Stanley Kubrick", 144, false, "https://storage.googleapis.com/pod_public/1300/262806.jpg", "The Shining", "7/10", 1980, "Idk", 2, "https://www.imdb.com/title/tt0081505/" },
                    { 4, "A skilled thief with the ability to enter dreams must pull off an impossible heist: planting an idea in someone's mind.", "Christopher Nolan", 148, true, "https://www.vasefotka.cz/fotky22340/fotos/_vyr_271602026-Inception-Pocatek.jpg", "Inception", "9/10", 2010, "Perfect", 2, "https://www.imdb.com/title/tt1375666/" },
                    { 5, "The aging patriarch of an organized crime dynasty transfers control to his reluctant son.", "Francis Ford Coppola", 175, true, "https://i5.walmartimages.com/seo/The-Godfather-Original-Movie-Poster-poster-Frameless-Gift-12-x-18-inch-30cm-x-46cm_c6df3fd5-1e9c-49ca-8cb6-1af6078df4c2.b21fd8bc877c5645b9340a53580833a2.jpeg", "The Godfather", "8/10", 1972, "Nice", 2, "https://www.imdb.com/title/tt0068646/" },
                    { 6, "A young girl becomes trapped in a strange spirit world and must find a way to free herself and her parents.", "Hayao Miyazaki", 125, false, "https://m.media-amazon.com/images/M/MV5BNTEyNmEwOWUtYzkyOC00ZTQ4LTllZmUtMjk0Y2YwOGUzYjRiXkEyXkFqcGc@._V1_.jpg", "Spirited Away", "8/10", 2001, "Nice", 2, "https://www.imdb.com/title/tt0245429/" },
                    { 7, "In a post-apocalyptic wasteland, a drifter and a rebel leader fight to survive against a tyrannical ruler.", "George Miller", 120, true, "https://m.media-amazon.com/images/M/MV5BZDRkODJhOTgtOTc1OC00NTgzLTk4NjItNDgxZDY4YjlmNDY2XkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg", "Mad Max: Fury Road", "7/10", 2015, "Nice", 2, "https://www.imdb.com/title/tt1392190/" },
                    { 8, "Two teenagers share a profound, magical connection upon discovering they are swapping bodies. Things manage to become even more complicated when the boy and girl decide to meet in person.", "Makoto Shinkai", 116, true, "https://m.media-amazon.com/images/M/MV5BMTIyNzFjNzItZmQ1MC00NzhjLThmMzYtZjRhN2Y3MmM2OGQyXkEyXkFqcGc@._V1_.jpg", "Your Name", "10/10", 2016, "Peak", 2, "https://www.imdb.com/title/tt5311514/" },
                    { 9, "A chemistry teacher turned drug-lord teams up with a former student to build a methamphetamine empire.", "Vince Gilligan", 62, true, "https://m.media-amazon.com/images/I/91+GrGr5TWL._AC_UF894,1000_QL80_.jpg", "Breaking Bad", "10/10", 2008, "Nice", 2, "https://www.imdb.com/title/tt0903747/" },
                    { 10, "A group of friends in the 1980s uncover supernatural mysteries and government conspiracies in their small town.", "The Duffer Brothers", 34, true, "https://static.posters.cz/image/1300/132239.jpg", "Stranger Things", "8/10", 2016, "Nice", 1, "https://www.imdb.com/title/tt4574334/" },
                    { 11, "A mockumentary about the daily lives of employees at the Dunder Mifflin paper company.", "Greg Daniels", 201, true, "https://m.media-amazon.com/images/M/MV5BZjQwYzBlYzUtZjhhOS00ZDQ0LWE0NzAtYTk4MjgzZTNkZWEzXkEyXkFqcGc@._V1_.jpg", "The Office (US)", "9/10", 2005, "Nice", 2, "https://www.imdb.com/title/tt0386676/" },
                    { 12, "Noble families fight for control of the Iron Throne in a fantasy world filled with dragons and political intrigue.", "David Benioff, D.B. Weiss", 73, true, "https://static.posters.cz/image/1300/135455.jpg", "Game of Thrones", "9/10", 2011, "Nice", 2, "https://www.imdb.com/title/tt0944947/" },
                    { 13, "A lone bounty hunter navigates the outer reaches of the galaxy, protecting a mysterious baby Yoda.", "Jon Favreau", 24, false, "https://static.posters.cz/image/750/103406.jpg", "The Mandalorian", "6/10", 2019, "Nice", 1, "https://www.imdb.com/title/tt8111088/" },
                    { 14, "An anthology series exploring the dark side of technology and human nature in dystopian futures.", "Charlie Brooker", 27, false, "https://m.media-amazon.com/images/M/MV5BODcxMWI2NDMtYTc3NC00OTZjLWFmNmUtM2NmY2I1ODkxYzczXkEyXkFqcGc@._V1_.jpg", "Black Mirror", "8/10", 2011, "Nice", 1, "https://www.imdb.com/title/tt2085059/" },
                    { 15, "A biographical drama chronicling the reign of Queen Elizabeth II and major historical events.", "Peter Morgan", 60, false, "https://image.tmdb.org/t/p/original/1M876KPjulVwppEpldhdc8V4o68.jpg", "The Crown", "-", 2016, "Nice", 0, "https://www.imdb.com/title/tt4786824/" },
                    { 16, "The trials and tribulations of criminal lawyer Jimmy McGill in the years leading up to his fateful run-in with Walter White and Jesse Pinkman.", "Peter Gould", 63, true, "https://m.media-amazon.com/images/M/MV5BNDdjNTEzMjMtYjM3Mi00NzQ3LWFlNWMtZjdmYWU3ZDkzMjk1XkEyXkFqcGc@._V1_.jpg", "Better Call Saul", "9/10", 2015, "Nice", 2, "https://www.imdb.com/title/tt3032476/" },
                    { 17, "An internal succession war within House Targaryen at the height of its power, 172 years before the birth of Daenerys Targaryen.", "Ryan J. Condal", 60, true, "https://m.media-amazon.com/images/M/MV5BYjBhMTU2N2EtYjVkYS00ODBiLTk3MDUtYWFmZTM2M2JkNzcwXkEyXkFqcGc@._V1_.jpg", "The House of the Dragon", "9/10", 2021, "Nice", 2, "https://www.imdb.com/title/tt11198330/" }
                });

            migrationBuilder.InsertData(
                table: "Watchlists",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Top-rated movies and series", "My Favorites" },
                    { 2, "Movies and series to watch later", "Watch Later" },
                    { 3, "Series I always want to watch", "Old Series" }
                });

            migrationBuilder.InsertData(
                table: "GenreMediaFile",
                columns: new[] { "GenresId", "MediaFilesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 7 },
                    { 1, 12 },
                    { 3, 2 },
                    { 3, 5 },
                    { 3, 8 },
                    { 3, 10 },
                    { 4, 3 },
                    { 5, 1 },
                    { 5, 4 },
                    { 5, 8 },
                    { 5, 13 },
                    { 6, 6 },
                    { 6, 13 },
                    { 8, 2 },
                    { 8, 9 },
                    { 9, 3 },
                    { 9, 4 },
                    { 9, 11 },
                    { 11, 5 },
                    { 13, 12 },
                    { 14, 14 },
                    { 16, 14 },
                    { 18, 6 },
                    { 23, 11 },
                    { 25, 10 },
                    { 26, 7 },
                    { 47, 9 }
                });

            migrationBuilder.InsertData(
                table: "MediaFileWatchlist",
                columns: new[] { "MediaFilesId", "WatchlistsId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreMediaFile_MediaFilesId",
                table: "GenreMediaFile",
                column: "MediaFilesId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFileWatchlist_WatchlistsId",
                table: "MediaFileWatchlist",
                column: "WatchlistsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreMediaFile");

            migrationBuilder.DropTable(
                name: "MediaFileWatchlist");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "MediaFiles");

            migrationBuilder.DropTable(
                name: "Watchlists");
        }
    }
}
