using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hackbart_EF_Split.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Carlos" },
                    { 2, "João" },
                    { 3, "Maria" },
                    { 4, "Ana" },
                    { 5, "Pedro" },
                    { 6, "Fernanda" },
                    { 7, "Lucas" },
                    { 8, "Laura" },
                    { 9, "Rafael" },
                    { 10, "Bianca" },
                    { 11, "Juliana" },
                    { 12, "Fábio" },
                    { 13, "Roberta" },
                    { 14, "Thiago" },
                    { 15, "Aline" },
                    { 16, "Gustavo" },
                    { 17, "Tatiane" },
                    { 18, "Marcos" },
                    { 19, "Sofia" },
                    { 20, "Eduardo" },
                    { 21, "Paula" },
                    { 22, "Robson" },
                    { 23, "Carla" },
                    { 24, "Felipe" },
                    { 25, "Nadia" },
                    { 26, "Rodrigo" },
                    { 27, "Patrícia" },
                    { 28, "Adriana" },
                    { 29, "Alberto" },
                    { 30, "Vanessa" },
                    { 31, "Cintia" },
                    { 32, "Marcelo" },
                    { 33, "Mariana" },
                    { 34, "Diego" },
                    { 35, "Flávia" },
                    { 36, "Leandro" },
                    { 37, "Cristina" },
                    { 38, "Alexandre" },
                    { 39, "Raquel" },
                    { 40, "Daniel" },
                    { 41, "Camila" },
                    { 42, "Renato" },
                    { 43, "Sandra" },
                    { 44, "Bruno" },
                    { 45, "Fernanda" },
                    { 46, "Helena" },
                    { 47, "Gabriel" },
                    { 48, "Patrícia" },
                    { 49, "Bruna" },
                    { 50, "Ricardo" },
                    { 51, "Maurício" },
                    { 52, "Eduarda" },
                    { 53, "Felipe" },
                    { 54, "Sofia" },
                    { 55, "Gustavo" },
                    { 56, "Paulo" },
                    { 57, "Isabela" },
                    { 58, "Vitor" },
                    { 59, "Roberto" },
                    { 60, "Luciana" },
                    { 61, "Silvia" },
                    { 62, "Bernardo" },
                    { 63, "Clara" },
                    { 64, "Otávio" },
                    { 65, "Bárbara" },
                    { 66, "Henrique" },
                    { 67, "Manuela" },
                    { 68, "Leonardo" },
                    { 69, "Simone" },
                    { 70, "Danilo" },
                    { 71, "Elisa" },
                    { 72, "André" },
                    { 73, "Marta" },
                    { 74, "Caio" },
                    { 75, "Viviane" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Produto 1", 10.00m },
                    { 2, "Produto 2", 15.00m },
                    { 3, "Produto 3", 20.00m },
                    { 4, "Produto 4", 25.00m },
                    { 5, "Produto 5", 30.00m },
                    { 6, "Produto 6", 35.00m },
                    { 7, "Produto 7", 40.00m },
                    { 8, "Produto 8", 45.00m },
                    { 9, "Produto 9", 50.00m },
                    { 10, "Produto 10", 55.00m },
                    { 11, "Produto 11", 60.00m },
                    { 12, "Produto 12", 65.00m },
                    { 13, "Produto 13", 70.00m },
                    { 14, "Produto 14", 75.00m },
                    { 15, "Produto 15", 80.00m },
                    { 16, "Produto 16", 85.00m },
                    { 17, "Produto 17", 90.00m },
                    { 18, "Produto 18", 95.00m },
                    { 19, "Produto 19", 100.00m },
                    { 20, "Produto 20", 105.00m },
                    { 21, "Produto 21", 110.00m },
                    { 22, "Produto 22", 115.00m },
                    { 23, "Produto 23", 120.00m },
                    { 24, "Produto 24", 125.00m },
                    { 25, "Produto 25", 130.00m },
                    { 26, "Produto 26", 135.00m },
                    { 27, "Produto 27", 140.00m },
                    { 28, "Produto 28", 145.00m },
                    { 29, "Produto 29", 150.00m },
                    { 30, "Produto 30", 155.00m },
                    { 31, "Produto 31", 160.00m },
                    { 32, "Produto 32", 165.00m },
                    { 33, "Produto 33", 170.00m },
                    { 34, "Produto 34", 175.00m },
                    { 35, "Produto 35", 180.00m },
                    { 36, "Produto 36", 185.00m },
                    { 37, "Produto 37", 190.00m },
                    { 38, "Produto 38", 195.00m },
                    { 39, "Produto 39", 200.00m },
                    { 40, "Produto 40", 205.00m },
                    { 41, "Produto 41", 210.00m },
                    { 42, "Produto 42", 215.00m },
                    { 43, "Produto 43", 220.00m },
                    { 44, "Produto 44", 225.00m },
                    { 45, "Produto 45", 230.00m },
                    { 46, "Produto 46", 235.00m },
                    { 47, "Produto 47", 240.00m },
                    { 48, "Produto 48", 245.00m },
                    { 49, "Produto 49", 250.00m },
                    { 50, "Produto 50", 255.00m },
                    { 51, "Produto 51", 260.00m },
                    { 52, "Produto 52", 265.00m },
                    { 53, "Produto 53", 270.00m },
                    { 54, "Produto 54", 275.00m },
                    { 55, "Produto 55", 280.00m },
                    { 56, "Produto 56", 285.00m },
                    { 57, "Produto 57", 290.00m },
                    { 58, "Produto 58", 295.00m },
                    { 59, "Produto 59", 300.00m },
                    { 60, "Produto 60", 305.00m },
                    { 61, "Produto 61", 310.00m },
                    { 62, "Produto 62", 315.00m },
                    { 63, "Produto 63", 320.00m },
                    { 64, "Produto 64", 325.00m },
                    { 65, "Produto 65", 330.00m }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "OrderDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 22, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2360) },
                    { 2, 2, new DateTime(2024, 9, 27, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2375) },
                    { 3, 3, new DateTime(2024, 9, 29, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2376) },
                    { 4, 4, new DateTime(2024, 10, 1, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2377) },
                    { 5, 5, new DateTime(2024, 10, 2, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2378) },
                    { 6, 6, new DateTime(2024, 9, 30, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2379) },
                    { 7, 7, new DateTime(2024, 9, 24, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2380) },
                    { 8, 8, new DateTime(2024, 9, 25, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2381) },
                    { 9, 9, new DateTime(2024, 9, 28, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2382) },
                    { 10, 10, new DateTime(2024, 9, 26, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2383) },
                    { 11, 11, new DateTime(2024, 9, 20, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2384) },
                    { 12, 12, new DateTime(2024, 9, 21, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2385) },
                    { 13, 13, new DateTime(2024, 9, 18, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2386) },
                    { 14, 14, new DateTime(2024, 9, 23, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2387) },
                    { 15, 15, new DateTime(2024, 9, 19, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2388) },
                    { 16, 16, new DateTime(2024, 9, 29, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2389) },
                    { 17, 17, new DateTime(2024, 9, 28, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2390) },
                    { 18, 18, new DateTime(2024, 9, 27, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2391) },
                    { 19, 19, new DateTime(2024, 9, 26, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2392) },
                    { 20, 20, new DateTime(2024, 9, 25, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2393) },
                    { 21, 21, new DateTime(2024, 9, 24, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2394) },
                    { 22, 22, new DateTime(2024, 9, 23, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2395) },
                    { 23, 23, new DateTime(2024, 9, 22, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2396) },
                    { 24, 24, new DateTime(2024, 9, 21, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2397) },
                    { 25, 25, new DateTime(2024, 9, 20, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2398) },
                    { 26, 26, new DateTime(2024, 9, 19, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2399) },
                    { 27, 27, new DateTime(2024, 9, 18, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2401) },
                    { 28, 28, new DateTime(2024, 9, 17, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2402) },
                    { 29, 29, new DateTime(2024, 9, 16, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2403) },
                    { 30, 30, new DateTime(2024, 9, 15, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2405) },
                    { 31, 31, new DateTime(2024, 9, 14, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2406) },
                    { 32, 32, new DateTime(2024, 9, 13, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2407) },
                    { 33, 33, new DateTime(2024, 9, 12, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2408) },
                    { 34, 34, new DateTime(2024, 9, 11, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2409) },
                    { 35, 35, new DateTime(2024, 9, 10, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2423) },
                    { 36, 36, new DateTime(2024, 9, 9, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2424) },
                    { 37, 37, new DateTime(2024, 9, 8, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2425) },
                    { 38, 38, new DateTime(2024, 9, 7, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2426) },
                    { 39, 39, new DateTime(2024, 9, 6, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2427) },
                    { 40, 40, new DateTime(2024, 9, 5, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2428) },
                    { 41, 41, new DateTime(2024, 9, 4, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2429) },
                    { 42, 42, new DateTime(2024, 9, 3, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2430) },
                    { 43, 43, new DateTime(2024, 9, 2, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2431) },
                    { 44, 44, new DateTime(2024, 9, 1, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2432) },
                    { 45, 45, new DateTime(2024, 8, 31, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2433) },
                    { 46, 46, new DateTime(2024, 8, 30, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2434) },
                    { 47, 47, new DateTime(2024, 8, 29, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2435) },
                    { 48, 48, new DateTime(2024, 8, 28, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2436) },
                    { 49, 49, new DateTime(2024, 8, 27, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2437) },
                    { 50, 50, new DateTime(2024, 8, 26, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2438) },
                    { 51, 51, new DateTime(2024, 8, 25, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2439) },
                    { 52, 52, new DateTime(2024, 8, 24, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2440) },
                    { 53, 53, new DateTime(2024, 8, 23, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2442) },
                    { 54, 54, new DateTime(2024, 8, 22, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2443) },
                    { 55, 55, new DateTime(2024, 8, 21, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2444) },
                    { 56, 56, new DateTime(2024, 8, 20, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2445) },
                    { 57, 57, new DateTime(2024, 8, 19, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2447) },
                    { 58, 58, new DateTime(2024, 8, 18, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2448) },
                    { 59, 59, new DateTime(2024, 8, 17, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2449) },
                    { 60, 60, new DateTime(2024, 8, 16, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2450) },
                    { 61, 61, new DateTime(2024, 8, 15, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2451) },
                    { 62, 62, new DateTime(2024, 8, 14, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2452) },
                    { 63, 63, new DateTime(2024, 8, 13, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2453) },
                    { 64, 64, new DateTime(2024, 8, 12, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2454) },
                    { 65, 65, new DateTime(2024, 8, 11, 19, 42, 24, 844, DateTimeKind.Local).AddTicks(2455) }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 2 },
                    { 2, 1, 2, 1 },
                    { 3, 2, 3, 3 },
                    { 4, 2, 4, 2 },
                    { 5, 3, 5, 1 },
                    { 6, 3, 6, 1 },
                    { 7, 4, 7, 5 },
                    { 8, 4, 8, 2 },
                    { 9, 5, 2, 1 },
                    { 10, 5, 4, 4 },
                    { 11, 6, 6, 2 },
                    { 12, 6, 8, 1 },
                    { 13, 7, 3, 1 },
                    { 14, 7, 5, 2 },
                    { 15, 8, 4, 3 },
                    { 16, 8, 6, 1 },
                    { 17, 9, 1, 2 },
                    { 18, 9, 8, 1 },
                    { 19, 10, 7, 3 },
                    { 20, 10, 5, 2 },
                    { 21, 11, 2, 1 },
                    { 22, 11, 3, 1 },
                    { 23, 12, 4, 1 },
                    { 24, 12, 5, 2 },
                    { 25, 13, 1, 2 },
                    { 26, 13, 6, 1 },
                    { 27, 14, 2, 1 },
                    { 28, 14, 3, 1 },
                    { 29, 15, 8, 1 },
                    { 30, 15, 4, 1 },
                    { 31, 11, 16, 1 },
                    { 32, 12, 17, 2 },
                    { 33, 13, 18, 1 },
                    { 34, 14, 19, 1 },
                    { 35, 15, 20, 3 },
                    { 36, 16, 21, 1 },
                    { 37, 17, 22, 2 },
                    { 38, 18, 23, 1 },
                    { 39, 19, 24, 2 },
                    { 40, 20, 25, 1 },
                    { 41, 21, 16, 3 },
                    { 42, 22, 17, 2 },
                    { 43, 23, 18, 4 },
                    { 44, 24, 19, 1 },
                    { 45, 25, 20, 2 },
                    { 46, 26, 26, 2 },
                    { 47, 27, 27, 3 },
                    { 48, 28, 28, 1 },
                    { 49, 29, 29, 4 },
                    { 50, 30, 30, 2 },
                    { 51, 31, 31, 1 },
                    { 52, 32, 32, 3 },
                    { 53, 33, 33, 1 },
                    { 54, 34, 34, 2 },
                    { 55, 35, 35, 3 },
                    { 56, 36, 36, 1 },
                    { 57, 37, 37, 4 },
                    { 58, 38, 38, 2 },
                    { 59, 39, 39, 1 },
                    { 60, 40, 40, 5 },
                    { 61, 41, 41, 2 },
                    { 62, 42, 42, 3 },
                    { 63, 43, 43, 1 },
                    { 64, 44, 44, 2 },
                    { 65, 45, 45, 3 },
                    { 66, 46, 46, 2 },
                    { 67, 47, 47, 3 },
                    { 68, 48, 48, 1 },
                    { 69, 49, 49, 4 },
                    { 70, 50, 50, 2 },
                    { 71, 51, 51, 1 },
                    { 72, 52, 52, 3 },
                    { 73, 53, 53, 1 },
                    { 74, 54, 54, 2 },
                    { 75, 55, 55, 3 },
                    { 76, 56, 56, 1 },
                    { 77, 57, 57, 4 },
                    { 78, 58, 58, 2 },
                    { 79, 59, 59, 1 },
                    { 80, 60, 60, 5 },
                    { 81, 61, 61, 2 },
                    { 82, 62, 62, 3 },
                    { 83, 63, 63, 1 },
                    { 84, 64, 64, 2 },
                    { 85, 65, 65, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
