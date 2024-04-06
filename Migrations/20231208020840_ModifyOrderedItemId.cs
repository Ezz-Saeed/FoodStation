using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodCorner.Migrations
{
    /// <inheritdoc />
    public partial class ModifyOrderedItemId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderedItems",
                table: "OrderedItems");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "414e88cc-b7d4-4ab8-adc1-ce3ce31e5c0d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f43392e-a2f6-40f3-8b84-c2e6fa5f3c67");

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
                    { "9a02b991-fa30-442f-b097-138f0f3d2d5e", "e66b3878-c981-4dd0-95ec-67de4d43fe07", "Admin", "ADMIN" },
                    { "c09564be-f534-4c75-8d46-4db33acb77e6", "17d93f03-c660-4ef8-82d1-62d980bcd4e9", "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderedItems_CartId",
                table: "OrderedItems",
                column: "CartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderedItems",
                table: "OrderedItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderedItems_CartId",
                table: "OrderedItems");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a02b991-fa30-442f-b097-138f0f3d2d5e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c09564be-f534-4c75-8d46-4db33acb77e6");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrderedItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderedItems",
                table: "OrderedItems",
                columns: new[] { "CartId", "ItemId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "414e88cc-b7d4-4ab8-adc1-ce3ce31e5c0d", "faf2f195-fb67-49dc-b86f-4d77ad7acfa3", "Admin", "ADMIN" },
                    { "8f43392e-a2f6-40f3-8b84-c2e6fa5f3c67", "5e68692b-b0f8-4254-aacd-51d359ab5016", "User", "USER" }
                });
        }
    }
}
