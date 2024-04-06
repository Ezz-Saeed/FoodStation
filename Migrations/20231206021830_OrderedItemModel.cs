using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodCorner.Migrations
{
    /// <inheritdoc />
    public partial class OrderedItemModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Carts_CartId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_CartId",
                table: "Items");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07b6dac2-dce7-4151-b097-3c6c9bf4ab2e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1a2b66d-d50a-4b9f-a9c3-229337b070e8");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Items");

            migrationBuilder.CreateTable(
                name: "OrderedItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedItems", x => new { x.CartId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_OrderedItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderedItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "414e88cc-b7d4-4ab8-adc1-ce3ce31e5c0d", "faf2f195-fb67-49dc-b86f-4d77ad7acfa3", "Admin", "ADMIN" },
                    { "8f43392e-a2f6-40f3-8b84-c2e6fa5f3c67", "5e68692b-b0f8-4254-aacd-51d359ab5016", "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderedItems_ItemId",
                table: "OrderedItems",
                column: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderedItems");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "414e88cc-b7d4-4ab8-adc1-ce3ce31e5c0d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f43392e-a2f6-40f3-8b84-c2e6fa5f3c67");

            migrationBuilder.AddColumn<string>(
                name: "CartId",
                table: "Items",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07b6dac2-dce7-4151-b097-3c6c9bf4ab2e", "28f81bcc-6da0-40ba-b3d5-561ad9295dcd", "User", "USER" },
                    { "a1a2b66d-d50a-4b9f-a9c3-229337b070e8", "1d7ad60b-b253-4065-8680-55fe346f4f62", "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_CartId",
                table: "Items",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Carts_CartId",
                table: "Items",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");
        }
    }
}
