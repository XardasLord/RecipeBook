using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeBook.Database.Migrations
{
    public partial class Added_RecipeParts_Column_And_Relationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "RecipeParts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IngredientId = table.Column<Guid>(nullable: true),
                    RecipeId = table.Column<Guid>(nullable: true),
                    Unit = table.Column<string>(nullable: true),
                    Quantity = table.Column<decimal>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeParts_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeParts_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeParts_IngredientId",
                table: "RecipeParts",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeParts_RecipeId",
                table: "RecipeParts",
                column: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeParts");

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
    }
}
