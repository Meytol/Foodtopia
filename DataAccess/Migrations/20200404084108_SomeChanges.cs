using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class SomeChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "RestaurantFoods",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoods_RestaurantId",
                table: "RestaurantFoods",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantFoods_Restaurants_RestaurantId",
                table: "RestaurantFoods",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantFoods_Restaurants_RestaurantId",
                table: "RestaurantFoods");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantFoods_RestaurantId",
                table: "RestaurantFoods");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "RestaurantFoods");
        }
    }
}
