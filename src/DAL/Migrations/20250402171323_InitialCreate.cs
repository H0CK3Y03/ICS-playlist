using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
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
                    { 3, "Drama" }
                });

            migrationBuilder.InsertData(
                table: "MediaFile",
                columns: new[] { "Id", "Description", "Director", "Discriminator", "Duration", "Favourite", "Length", "Name", "Rating", "ReleaseDate", "Status", "URL" },
                values: new object[,]
                {
                    { 1, "", "", "Movie", 0, false, 148, "Inception", "PG-13", 2010, 2, "" },
                    { 2, "", "", "Movie", 0, false, 136, "The Matrix", "R", 1999, 2, "" }
                });

            migrationBuilder.InsertData(
                table: "MediaFile",
                columns: new[] { "Id", "Description", "Director", "Discriminator", "Duration", "Favourite", "Name", "NumberOfEpisodes", "Rating", "ReleaseDate", "Status", "URL" },
                values: new object[,]
                {
                    { 3, "", "", "Series", 0, false, "Breaking Bad", 62, "TV-MA", 2008, 2, "" },
                    { 4, "", "", "Series", 0, false, "Stranger Things", 34, "TV-14", 2016, 1, "" }
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
