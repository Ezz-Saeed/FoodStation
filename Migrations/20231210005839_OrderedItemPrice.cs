using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodCorner.Migrations
{
    /// <inheritdoc />
    public partial class OrderedItemPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d4f736a-f72b-4aac-978e-114086f4f674");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d17c5d5f-bf3e-4a68-a9bb-87ed30c527f5");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "OrderedItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3b8750b2-57d8-4b7f-9f44-b205132382d5", "eb557390-4c37-4020-bf5d-f57c711688a5", "User", "USER" },
                    { "84b17ed6-3fc5-4a1b-a993-5f8adcd81a43", "da44d9c7-f132-4c81-9065-39dfea55b2b2", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b8750b2-57d8-4b7f-9f44-b205132382d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84b17ed6-3fc5-4a1b-a993-5f8adcd81a43");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "OrderedItems");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6d4f736a-f72b-4aac-978e-114086f4f674", "f826bace-fb18-42ae-bf0f-7276fe01ff9a", "Admin", "ADMIN" },
                    { "d17c5d5f-bf3e-4a68-a9bb-87ed30c527f5", "0eccea28-7e19-4577-9fe0-012a84e73ac2", "User", "USER" }
                });
        }
    }
}
