using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vued.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitAllClean : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GenreMediaFile",
                keyColumns: new[] { "GenresId", "MediaFilesId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "GenreMediaFile",
                keyColumns: new[] { "GenresId", "MediaFilesId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "GenreMediaFile",
                keyColumns: new[] { "GenresId", "MediaFilesId" },
                keyValues: new object[] { 1, 12 });

            migrationBuilder.DeleteData(
                table: "GenreMediaFile",
                keyColumns: new[] { "GenresId", "MediaFilesId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "GenreMediaFile",
                keyColumns: new[] { "GenresId", "MediaFilesId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "GenreMediaFile",
                keyColumns: new[] { "GenresId", "MediaFilesId" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "GenreMediaFile",
                keyColumns: new[] { "GenresId", "MediaFilesId" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.DeleteData(
                table: "GenreMediaFile",
                keyColumns: new[] { "GenresId", "MediaFilesId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "GenreMediaFile",
                keyColumns: new[] { "GenresId", "MediaFilesId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "GenreMediaFile",
                keyColumns: new[] { "GenresId", "MediaFilesId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "GenreMediaFile",
                keyColumns: new[] { "GenresId", "MediaFilesId" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.DeleteData(
                table: "GenreMediaFile",
                keyColumns: new[] { "GenresId", "MediaFilesId" },
                keyValues: new object[] { 5, 13 });

            migrationBuilder.DeleteData(
                table: "GenreMediaFile",
                keyColumns: new[] { "GenresId", "MediaFilesId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "GenreMediaFile",
                keyColumns: new[] { "GenresId", "MediaFilesId" },
                keyValues: new object[] { 6, 13 });

            migrationBuilder.DeleteData(
                table: "GenreMediaFile",
                keyColumns: new[] { "GenresId", "MediaFilesId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "GenreMediaFile",
                keyColumns: new[] { "GenresId", "MediaFilesId" },
                keyValues: new object[] { 8, 9 });

            migrationBuilder.DeleteData(
                table: "GenreMediaFile",
                keyColumns: new[] { "GenresId", "MediaFilesId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "GenreMediaFile",
                keyColumns: new[] { "GenresId", "MediaFilesId" },
                keyValues: new object[] { 9, 4 });

            migrationBuilder.DeleteData(
                table: "GenreMediaFile",
                keyColumns: new[] { "GenresId", "MediaFilesId" },
                keyValues: new object[] { 9, 11 });

            migrationBuilder.DeleteData(
                table: "GenreMediaFile",
                keyColumns: new[] { "GenresId", "MediaFilesId" },
                keyValues: new object[] { 11, 5 });

            migrationBuilder.DeleteData(
                table: "GenreMediaFile",
                keyColumns: new[] { "GenresId", "MediaFilesId" },
                keyValues: new object[] { 13, 12 });

            migrationBuilder.DeleteData(
                table: "GenreMediaFile",
                keyColumns: new[] { "GenresId", "MediaFilesId" },
                keyValues: new object[] { 14, 14 });

            migrationBuilder.DeleteData(
                table: "GenreMediaFile",
                keyColumns: new[] { "GenresId", "MediaFilesId" },
                keyValues: new object[] { 16, 14 });

            migrationBuilder.DeleteData(
                table: "GenreMediaFile",
                keyColumns: new[] { "GenresId", "MediaFilesId" },
                keyValues: new object[] { 18, 6 });

            migrationBuilder.DeleteData(
                table: "GenreMediaFile",
                keyColumns: new[] { "GenresId", "MediaFilesId" },
                keyValues: new object[] { 23, 11 });

            migrationBuilder.DeleteData(
                table: "GenreMediaFile",
                keyColumns: new[] { "GenresId", "MediaFilesId" },
                keyValues: new object[] { 25, 10 });

            migrationBuilder.DeleteData(
                table: "GenreMediaFile",
                keyColumns: new[] { "GenresId", "MediaFilesId" },
                keyValues: new object[] { 26, 7 });

            migrationBuilder.DeleteData(
                table: "GenreMediaFile",
                keyColumns: new[] { "GenresId", "MediaFilesId" },
                keyValues: new object[] { 47, 9 });
        }
    }
}
