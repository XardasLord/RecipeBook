using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeBook.Database.Migrations
{
    public partial class Added_ModifiedBy_And_DeletedBy_Columns_To_BaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Recipes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Recipes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "RecipeParts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "RecipeParts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Ingredients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Ingredients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "RecipeParts");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "RecipeParts");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Ingredients");
        }
    }
}
