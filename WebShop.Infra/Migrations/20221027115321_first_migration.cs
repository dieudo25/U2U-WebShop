using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShop.Infra.Migrations
{
    public partial class first_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Seller = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(8,3)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "CreatedAt", "Discount", "Image", "Name", "Rating", "Seller", "UnitPrice" },
                values: new object[,]
                {
                    { 1, "Vege", new DateTime(2022, 10, 27, 13, 53, 21, 240, DateTimeKind.Local).AddTicks(4351), 0, "imgs/shop/thumbnail-2.jpg", "PS5", 4, "Amazon", 0m },
                    { 2, "Snack", new DateTime(2022, 10, 27, 13, 53, 21, 240, DateTimeKind.Local).AddTicks(4391), 20, "imgs/shop/thumbnail-2.jpg", "Xbox", 4, "Amazon", 0m },
                    { 3, "Meats", new DateTime(2022, 10, 27, 13, 53, 21, 240, DateTimeKind.Local).AddTicks(4395), 0, "imgs/shop/thumbnail-2.jpg", "Switch", 4, "Amazon", 0m },
                    { 4, "Meats", new DateTime(2022, 10, 27, 13, 53, 21, 240, DateTimeKind.Local).AddTicks(4398), 50, "imgs/shop/thumbnail-2.jpg", "Dell XPS 15", 4, "Amazon", 0m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Review_ProductId",
                table: "Review",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
