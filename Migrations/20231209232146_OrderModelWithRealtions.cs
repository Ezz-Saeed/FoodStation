using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodCorner.Migrations
{
    /// <inheritdoc />
    public partial class OrderModelWithRealtions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a02b991-fa30-442f-b097-138f0f3d2d5e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c09564be-f534-4c75-8d46-4db33acb77e6");

            migrationBuilder.AddColumn<string>(
                name: "Orderid",
                table: "OrderedItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "OrderedItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalQuantity = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6d4f736a-f72b-4aac-978e-114086f4f674", "f826bace-fb18-42ae-bf0f-7276fe01ff9a", "Admin", "ADMIN" },
                    { "d17c5d5f-bf3e-4a68-a9bb-87ed30c527f5", "0eccea28-7e19-4577-9fe0-012a84e73ac2", "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderedItems_Orderid",
                table: "OrderedItems",
                column: "Orderid");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedItems_Orders_Orderid",
                table: "OrderedItems",
                column: "Orderid",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderedItems_Orders_Orderid",
                table: "OrderedItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderedItems_Orderid",
                table: "OrderedItems");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d4f736a-f72b-4aac-978e-114086f4f674");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d17c5d5f-bf3e-4a68-a9bb-87ed30c527f5");

            migrationBuilder.DropColumn(
                name: "Orderid",
                table: "OrderedItems");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderedItems");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9a02b991-fa30-442f-b097-138f0f3d2d5e", "e66b3878-c981-4dd0-95ec-67de4d43fe07", "Admin", "ADMIN" },
                    { "c09564be-f534-4c75-8d46-4db33acb77e6", "17d93f03-c660-4ef8-82d1-62d980bcd4e9", "User", "USER" }
                });
        }
    }
}
