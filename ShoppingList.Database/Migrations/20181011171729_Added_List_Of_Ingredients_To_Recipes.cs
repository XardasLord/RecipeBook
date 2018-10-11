using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingList.Database.Migrations
{
    public partial class Added_List_Of_Ingredients_To_Recipes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RecipesId",
                table: "Ingredients",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipesId",
                table: "Ingredients",
                column: "RecipesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Recipes_RecipesId",
                table: "Ingredients",
                column: "RecipesId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Recipes_RecipesId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_RecipesId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "RecipesId",
                table: "Ingredients");
        }
    }
}
