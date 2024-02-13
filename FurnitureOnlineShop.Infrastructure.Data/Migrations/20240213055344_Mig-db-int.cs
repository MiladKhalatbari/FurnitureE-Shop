using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FurnitureOnlineShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Migdbint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantityInStock = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsFinaly = table.Column<bool>(type: "bit", nullable: false),
                    IdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_IdentityUser_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "CreatedDate", "IdentityUserId", "IsFinaly", "LastModifiedDate" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "8e445865-a24d-4543-a6c6-9443d048cdb9", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "ImagePath", "LastModifiedDate", "Price", "QuantityInStock", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 13, 5, 53, 44, 228, DateTimeKind.Utc).AddTicks(5088), "Nordic Chair, a timeless blend of minimalist design and unparalleled comfort. Crafted with meticulous attention to detail, this chair embodies the essence of Scandinavian elegance, making it a perfect addition to any modern living space.\r\n\r\nDesigned for both style and functionality, the Nordic Chair features clean lines, gentle curves, and a sleek silhouette that effortlessly complements any interior décor. Its minimalist frame is expertly crafted from high-quality wood, ensuring durability and stability for years to come.", "/images/product-1.png", new DateTime(2024, 2, 13, 5, 53, 44, 228, DateTimeKind.Utc).AddTicks(5092), 50m, 9, "Nordic Chair" },
                    { 2, new DateTime(2024, 2, 13, 5, 53, 44, 228, DateTimeKind.Utc).AddTicks(5102), "Kruzo Aero Chair, where innovation meets sophistication in a seamless fusion of style and functionality. Engineered with cutting-edge design and premium materials, this chair redefines modern seating, offering unparalleled comfort and aesthetic appeal.\r\n\r\nCrafted with precision, the Kruzo Aero Chair features a sleek and aerodynamic silhouette that exudes contemporary elegance. Its distinctive design elements, including fluid lines and a curved backrest, create a sense of dynamic movement, making it a striking focal point in any space.", "/images/product-2.png", new DateTime(2024, 2, 13, 5, 53, 44, 228, DateTimeKind.Utc).AddTicks(5103), 78m, 14, "Kruzo Aero Chair" },
                    { 3, new DateTime(2024, 2, 13, 5, 53, 44, 228, DateTimeKind.Utc).AddTicks(5107), "Ergonomic Chair, meticulously designed to prioritize your comfort, health, and productivity. Crafted with precision engineering and ergonomic principles, this chair offers exceptional support and adaptability for extended periods of sitting.\r\n\r\nThe Ergonomic Chair features an innovative design that contours to the natural curvature of your body, providing optimal lumbar support and promoting healthy posture. Its adjustable features, including lumbar support, seat depth, armrests, and height, ensure customizable comfort tailored to your individual needs.", "/images/product-3.png", new DateTime(2024, 2, 13, 5, 53, 44, 228, DateTimeKind.Utc).AddTicks(5109), 43m, 5, "Ergonomic Chair" },
                    { 4, new DateTime(2024, 2, 13, 5, 53, 44, 228, DateTimeKind.Utc).AddTicks(5112), "luxurious Sofa, a masterpiece of comfort and style that transforms any living space into a haven of relaxation and elegance. Crafted with the finest materials and meticulous attention to detail, this sofa offers unparalleled comfort, durability, and timeless beauty.\r\n\r\nDesigned for both aesthetics and functionality, our Sofa boasts a timeless silhouette with clean lines and plush cushions, creating a harmonious balance of modern sophistication and inviting comfort. Its sturdy frame, crafted from high-quality hardwood, ensures stability and longevity, promising years of enjoyment for you and your loved ones.", "/images/sofa.png", new DateTime(2024, 2, 13, 5, 53, 44, 228, DateTimeKind.Utc).AddTicks(5114), 57m, 10, "luxurious Sofa" }
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "CartId", "CreatedDate", "LastModifiedDate", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 3, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 },
                    { 4, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_IdentityUserId",
                table: "Carts",
                column: "IdentityUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
