using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HealthyFood",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ingredients = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthyFood", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpensAt = table.Column<int>(type: "int", nullable: false),
                    ClosesAt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HealthyFoodOrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HealthyFoodId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthyFoodOrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthyFoodOrderItem_HealthyFood_HealthyFoodId",
                        column: x => x.HealthyFoodId,
                        principalTable: "HealthyFood",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HealthyFoodOrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HealthyFood",
                columns: new[] { "Id", "ImageUrl", "Ingredients", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "https://images.immediate.co.uk/production/volatile/sites/30/2020/08/recipe-image-legacy-id-1244455_7-e831545.jpg?resize=960,872?quality=90&webp=true&resize=300,272", " salmon steaks,  mushroom , pine nut", "penne", 300m },
                    { 2, "https://images.immediate.co.uk/production/volatile/sites/30/2020/10/Tuna-Caper-Chilli-Spaghetti-0d409ad.jpg?resize=960,872?quality=90&webp=true&resize=300,272", "red chilli, ,tuna , spinach ", "Tuna spaghetti", 500m },
                    { 3, "https://images.immediate.co.uk/production/volatile/sites/30/2020/08/vegan-burger-f4eb0ad.jpg?resize=960,872?quality=90&webp=true&resize=300,272", "chickpeas , pitta bread , Tomato ", "Vegan burger", 460m },
                    { 4, "https://images.immediate.co.uk/production/volatile/sites/30/2020/08/omelette-pancakes-with-tomato-pepper-sauce-557a351.jpg?resize=960,872?quality=90&webp=true&resize=300,272", "Garlic , Egg , Tomato ", "Omelette pancakes", 350m },
                    { 5, "https://images.immediate.co.uk/production/volatile/sites/30/2020/08/spicychickenavocadowraps_5865-4035909.jpg?resize=960,872?quality=90&webp=true&resize=300,272", "chicken breast , Tomato , Avocado ", "avocado wraps", 200m },
                    { 6, "https://images.immediate.co.uk/production/volatile/sites/30/2020/08/chicken-broccoli-beetroot-salad-with-avocado-pesto-5f17f37.jpg?resize=960,872?quality=90&webp=true&resize=300,272", "Broccoli , nigella seeds , Tomato ", " broccoli salad", 480m },
                    { 7, "https://images.immediate.co.uk/production/volatile/sites/30/2022/03/Healthy-pepper-ham-omelette-f80d4d4.jpg?resize=960,872?quality=90&webp=true&resize=300,272", "onion , Egg , Tomato ", "ham omelette", 600m },
                    { 8, "https://images.immediate.co.uk/production/volatile/sites/30/2020/08/burrito-bowl-3629880.jpg?resize=960,872?quality=90&webp=true&resize=300,272", "Avocado , Egg , honey ", "Burrito bowl", 400m }
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "Address", "ClosesAt", "Name", "OpensAt" },
                values: new object[,]
                {
                    { 1, "record", 22, "Fresh Kitchen", 8 },
                    { 2, "Gligor Prlicev", 22, "Fresh Kitchen", 8 },
                    { 3, "Kiril Pejcinovski", 22, "Fresh Kitchen", 8 },
                    { 4, "Ilindenska", 22, "Fresh Kitchen", 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HealthyFoodOrderItem_HealthyFoodId",
                table: "HealthyFoodOrderItem",
                column: "HealthyFoodId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthyFoodOrderItem_OrderId",
                table: "HealthyFoodOrderItem",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealthyFoodOrderItem");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "HealthyFood");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
