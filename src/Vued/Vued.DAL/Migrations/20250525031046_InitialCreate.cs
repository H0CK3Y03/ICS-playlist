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
                name: "MediaFile",
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
                    Favourite = table.Column<bool>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", maxLength: 13, nullable: false),
                    Length = table.Column<int>(type: "INTEGER", nullable: true),
                    NumberOfEpisodes = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaFile", x => x.Id);
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
                        name: "FK_GenreMediaFile_MediaFile_MediaFilesId",
                        column: x => x.MediaFilesId,
                        principalTable: "MediaFile",
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
                        name: "FK_MediaFileWatchlist_MediaFile_MediaFilesId",
                        column: x => x.MediaFilesId,
                        principalTable: "MediaFile",
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
                table: "MediaFile",
                columns: new[] { "Id", "Description", "Director", "Discriminator", "Duration", "Favourite", "Length", "Name", "Rating", "ReleaseDate", "Status", "URL" },
                values: new object[,]
                {
                    { 1, "A computer hacker learns about the true nature of reality and joins a group of rebels to fight a war against powerful controllers.", "Lana Wachowski, Lilly Wachowski", "Movie", 0, true, 136, "The Matrix", "8/10", 1999, 2, "https://www.imdb.com/title/tt0133093/" },
                    { 2, "The life story of a man with a low IQ who achieves extraordinary feats through his kindness and determination.", "Robert Zemeckis", "Movie", 0, true, 142, "Forrest Gump", "6/10", 1994, 2, "https://www.imdb.com/title/tt0109830/" },
                    { 3, "A family heads to an isolated hotel for the winter where a sinister presence influences the father into violence.", "Stanley Kubrick", "Movie", 0, false, 144, "The Shining", "7/10", 1980, 2, "https://www.imdb.com/title/tt0081505/" },
                    { 4, "A skilled thief with the ability to enter dreams must pull off an impossible heist: planting an idea in someone's mind.", "Christopher Nolan", "Movie", 0, true, 148, "Inception", "9/10", 2010, 2, "https://www.imdb.com/title/tt1375666/" },
                    { 5, "The aging patriarch of an organized crime dynasty transfers control to his reluctant son.", "Francis Ford Coppola", "Movie", 0, true, 175, "The Godfather", "8/10", 1972, 2, "https://www.imdb.com/title/tt0068646/" },
                    { 6, "A young girl becomes trapped in a strange spirit world and must find a way to free herself and her parents.", "Hayao Miyazaki", "Movie", 0, false, 125, "Spirited Away", "8/10", 2001, 2, "https://www.imdb.com/title/tt0245429/" },
                    { 7, "In a post-apocalyptic wasteland, a drifter and a rebel leader fight to survive against a tyrannical ruler.", "George Miller", "Movie", 0, true, 120, "Mad Max: Fury Road", "7/10", 2015, 2, "https://www.imdb.com/title/tt1392190/" }
                });

            migrationBuilder.InsertData(
                table: "MediaFile",
                columns: new[] { "Id", "Description", "Director", "Discriminator", "Duration", "Favourite", "Name", "NumberOfEpisodes", "Rating", "ReleaseDate", "Status", "URL" },
                values: new object[,]
                {
                    { 8, "A chemistry teacher turned drug-lord teams up with a former student to build a methamphetamine empire.", "Vince Gilligan", "Series", 0, true, "Breaking Bad", 62, "10/10", 2008, 2, "https://www.imdb.com/title/tt0903747/" },
                    { 9, "A group of friends in the 1980s uncover supernatural mysteries and government conspiracies in their small town.", "The Duffer Brothers", "Series", 0, true, "Stranger Things", 34, "8/10", 2016, 1, "https://www.imdb.com/title/tt4574334/" },
                    { 10, "A mockumentary about the daily lives of employees at the Dunder Mifflin paper company.", "Greg Daniels", "Series", 0, true, "The Office (US)", 201, "9/10", 2005, 2, "https://www.imdb.com/title/tt0386676/" },
                    { 11, "Noble families fight for control of the Iron Throne in a fantasy world filled with dragons and political intrigue.", "David Benioff, D.B. Weiss", "Series", 0, true, "Game of Thrones", 73, "9/10", 2011, 2, "https://www.imdb.com/title/tt0944947/" },
                    { 12, "A lone bounty hunter navigates the outer reaches of the galaxy, protecting a mysterious baby Yoda.", "Jon Favreau", "Series", 0, false, "The Mandalorian", 24, "6/10", 2019, 1, "https://www.imdb.com/title/tt8111088/" },
                    { 13, "An anthology series exploring the dark side of technology and human nature in dystopian futures.", "Charlie Brooker", "Series", 0, false, "Black Mirror", 27, "8/10", 2011, 1, "https://www.imdb.com/title/tt2085059/" },
                    { 14, "A biographical drama chronicling the reign of Queen Elizabeth II and major historical events.", "Peter Morgan", "Series", 0, false, "The Crown", 60, "-", 2016, 0, "https://www.imdb.com/title/tt4786824/" }
                });

            migrationBuilder.InsertData(
                table: "Watchlists",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Top-rated movies and series", "My Favorites" },
                    { 2, "Movies and series to watch later", "Watch Later" }
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
                name: "MediaFile");

            migrationBuilder.DropTable(
                name: "Watchlists");
        }
    }
}
