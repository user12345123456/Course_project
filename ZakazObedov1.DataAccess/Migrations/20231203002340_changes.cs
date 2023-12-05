using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZakazObedov1.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Menus_MenuId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropColumn(
                name: "Menu",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "MealID",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "Orders",
                newName: "RestaurantID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_MenuId",
                table: "Orders",
                newName: "IX_Orders_RestaurantID");

            migrationBuilder.AddColumn<int>(
                name: "MenuID",
                table: "Restaurants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestaurantID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meals_Restaurants_RestaurantID",
                        column: x => x.RestaurantID,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meals_RestaurantID",
                table: "Meals",
                column: "RestaurantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Restaurants_RestaurantID",
                table: "Orders",
                column: "RestaurantID",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Restaurants_RestaurantID",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropColumn(
                name: "MenuID",
                table: "Restaurants");

            migrationBuilder.RenameColumn(
                name: "RestaurantID",
                table: "Orders",
                newName: "MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_RestaurantID",
                table: "Orders",
                newName: "IX_Orders_MenuId");

            migrationBuilder.AddColumn<string>(
                name: "Menu",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MealID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Menus_MenuId",
                table: "Orders",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
