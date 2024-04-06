using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodCorner.Migrations
{
    /// <inheritdoc />
    public partial class OrderedItemCompositePK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderedItems",
                table: "OrderedItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderedItems_ItemId",
                table: "OrderedItems");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b8750b2-57d8-4b7f-9f44-b205132382d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84b17ed6-3fc5-4a1b-a993-5f8adcd81a43");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrderedItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderedItems",
                table: "OrderedItems",
                columns: new[] { "ItemId", "CartId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "19aaedde-22d2-427c-bd71-8ec7a5c0d0c4", "1ed7b42e-e662-45bf-8c29-be6f14226bd2", "Admin", "ADMIN" },
                    { "55848571-3999-4115-84b9-903b2e478308", "ad4aa5f0-fa3f-46be-a806-e6dc7d1ef859", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderedItems",
                table: "OrderedItems");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19aaedde-22d2-427c-bd71-8ec7a5c0d0c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55848571-3999-4115-84b9-903b2e478308");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "OrderedItems",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderedItems",
                table: "OrderedItems",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3b8750b2-57d8-4b7f-9f44-b205132382d5", "eb557390-4c37-4020-bf5d-f57c711688a5", "User", "USER" },
                    { "84b17ed6-3fc5-4a1b-a993-5f8adcd81a43", "da44d9c7-f132-4c81-9065-39dfea55b2b2", "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderedItems_ItemId",
                table: "OrderedItems",
                column: "ItemId");
        }
    }
}
