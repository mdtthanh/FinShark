using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7de906ef-a798-4ab9-8c63-bfc4f9acf901");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e31a3faf-2529-42d3-bd8b-6ab93d786a43");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1ff4f054-5727-4075-a6f1-e4106b3738aa", null, "User", "USER" },
                    { "decd4658-669c-4977-b79d-503176f80b90", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ff4f054-5727-4075-a6f1-e4106b3738aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "decd4658-669c-4977-b79d-503176f80b90");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7de906ef-a798-4ab9-8c63-bfc4f9acf901", null, "Admin", "ADMIN" },
                    { "e31a3faf-2529-42d3-bd8b-6ab93d786a43", null, "User", "USER" }
                });
        }
    }
}
