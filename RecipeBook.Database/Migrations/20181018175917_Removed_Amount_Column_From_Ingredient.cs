using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeBook.Database.Migrations
{
    public partial class Removed_Amount_Column_From_Ingredient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Ingredients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Ingredients",
                nullable: false,
                defaultValue: 0);
        }
    }
}
