using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vued.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddReviewColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Review",
                table: "MediaFile",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "MediaFile",
                keyColumn: "Id",
                keyValue: 1,
                column: "Review",
                value: "Nice");

            migrationBuilder.UpdateData(
                table: "MediaFile",
                keyColumn: "Id",
                keyValue: 2,
                column: "Review",
                value: "Cool");

            migrationBuilder.UpdateData(
                table: "MediaFile",
                keyColumn: "Id",
                keyValue: 3,
                column: "Review",
                value: "Idk");

            migrationBuilder.UpdateData(
                table: "MediaFile",
                keyColumn: "Id",
                keyValue: 4,
                column: "Review",
                value: "Perfect");

            migrationBuilder.UpdateData(
                table: "MediaFile",
                keyColumn: "Id",
                keyValue: 5,
                column: "Review",
                value: "Nice");

            migrationBuilder.UpdateData(
                table: "MediaFile",
                keyColumn: "Id",
                keyValue: 6,
                column: "Review",
                value: "Nice");

            migrationBuilder.UpdateData(
                table: "MediaFile",
                keyColumn: "Id",
                keyValue: 7,
                column: "Review",
                value: "Nice");

            migrationBuilder.UpdateData(
                table: "MediaFile",
                keyColumn: "Id",
                keyValue: 8,
                column: "Review",
                value: "Nice");

            migrationBuilder.UpdateData(
                table: "MediaFile",
                keyColumn: "Id",
                keyValue: 9,
                column: "Review",
                value: "Nice");

            migrationBuilder.UpdateData(
                table: "MediaFile",
                keyColumn: "Id",
                keyValue: 10,
                column: "Review",
                value: "Nice");

            migrationBuilder.UpdateData(
                table: "MediaFile",
                keyColumn: "Id",
                keyValue: 11,
                column: "Review",
                value: "Nice");

            migrationBuilder.UpdateData(
                table: "MediaFile",
                keyColumn: "Id",
                keyValue: 12,
                column: "Review",
                value: "Nice");

            migrationBuilder.UpdateData(
                table: "MediaFile",
                keyColumn: "Id",
                keyValue: 13,
                column: "Review",
                value: "Nice");

            migrationBuilder.UpdateData(
                table: "MediaFile",
                keyColumn: "Id",
                keyValue: 14,
                column: "Review",
                value: "Nice");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Review",
                table: "MediaFile");
        }
    }
}
