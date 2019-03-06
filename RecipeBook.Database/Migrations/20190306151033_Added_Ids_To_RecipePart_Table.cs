using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeBook.Database.Migrations
{
    public partial class Added_Ids_To_RecipePart_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeParts_Ingredients_IngredientId",
                table: "RecipeParts");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeParts_Recipes_RecipeId",
                table: "RecipeParts");

            migrationBuilder.AlterColumn<Guid>(
                name: "RecipeId",
                table: "RecipeParts",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IngredientId",
                table: "RecipeParts",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeParts_Ingredients_IngredientId",
                table: "RecipeParts",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeParts_Recipes_RecipeId",
                table: "RecipeParts",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeParts_Ingredients_IngredientId",
                table: "RecipeParts");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeParts_Recipes_RecipeId",
                table: "RecipeParts");

            migrationBuilder.AlterColumn<Guid>(
                name: "RecipeId",
                table: "RecipeParts",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "IngredientId",
                table: "RecipeParts",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeParts_Ingredients_IngredientId",
                table: "RecipeParts",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeParts_Recipes_RecipeId",
                table: "RecipeParts",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
