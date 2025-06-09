using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vued.DAL.Migrations
{
    /// <inheritdoc />
    public partial class WatchlistMediaSeeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MediaFileWatchlist",
                columns: new[] { "MediaFilesId", "WatchlistsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 8, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MediaFileWatchlist",
                keyColumns: new[] { "MediaFilesId", "WatchlistsId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "MediaFileWatchlist",
                keyColumns: new[] { "MediaFilesId", "WatchlistsId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "MediaFileWatchlist",
                keyColumns: new[] { "MediaFilesId", "WatchlistsId" },
                keyValues: new object[] { 8, 1 });
        }
    }
}
