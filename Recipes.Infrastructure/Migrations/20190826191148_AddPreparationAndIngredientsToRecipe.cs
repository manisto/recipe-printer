using Microsoft.EntityFrameworkCore.Migrations;

namespace Recipes.Infrastructure.Migrations
{
    public partial class AddPreparationAndIngredientsToRecipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ingredients",
                table: "Recipes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Preparation",
                table: "Recipes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ingredients",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Preparation",
                table: "Recipes");
        }
    }
}
