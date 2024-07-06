using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Task.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StoreItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreItems", x => new { x.ItemId, x.StoreId });
                    table.ForeignKey(
                        name: "FK_StoreItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreItems_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "Images\\Items\\1.jpg", "Incredible Granite Soap" },
                    { 2, "Images\\Items\\2.jpg", "Small Frozen Towels" },
                    { 3, "Images\\Items\\3.jpg", "Incredible Steel Chips" },
                    { 4, "Images\\Items\\4.jpg", "Incredible Cotton Chicken" },
                    { 5, "Images\\Items\\5.jpg", "Small Plastic Car" },
                    { 6, "Images\\Items\\6.jpg", "Awesome Rubber Pizza" },
                    { 7, "Images\\Items\\7.jpg", "Generic Granite Gloves" },
                    { 8, "Images\\Items\\8.jpg", "Gorgeous Soft Cheese" },
                    { 9, "Images\\Items\\9.jpg", "Sleek Cotton Bike" },
                    { 10, "Images\\Items\\10.jpg", "Small Metal Mouse" }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "Images\\Stores\\1.jpg", "Kovacek LLC" },
                    { 2, "Images\\Stores\\2.jpg", "VonRueden LLC" },
                    { 3, "Images\\Stores\\3.jpg", "Bechtelar Group" },
                    { 4, "Images\\Stores\\4.jpg", "Johns LLC" },
                    { 5, "Images\\Stores\\5.jpg", "Heller Inc" },
                    { 6, "Images\\Stores\\6.jpg", "Marquardt - Steuber" },
                    { 7, "Images\\Stores\\7.jpg", "Kub - Gutmann" },
                    { 8, "Images\\Stores\\8.jpg", "Roob Group" },
                    { 9, "Images\\Stores\\9.jpg", "Kerluke - Erdman" },
                    { 10, "Images\\Stores\\10.jpg", "Nitzsche Inc" }
                });

            migrationBuilder.InsertData(
                table: "StoreItems",
                columns: new[] { "ItemId", "StoreId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 54 },
                    { 1, 4, 100 },
                    { 2, 5, 7 },
                    { 3, 5, 76 },
                    { 3, 10, 93 },
                    { 4, 1, 5 },
                    { 5, 4, 60 },
                    { 5, 5, 83 },
                    { 5, 6, 31 },
                    { 6, 6, 86 },
                    { 6, 8, 16 },
                    { 6, 9, 49 },
                    { 7, 1, 20 },
                    { 7, 3, 9 },
                    { 8, 3, 77 },
                    { 9, 6, 99 },
                    { 10, 1, 56 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoreItems_StoreId",
                table: "StoreItems",
                column: "StoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreItems");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
