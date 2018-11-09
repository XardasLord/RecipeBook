using Microsoft.EntityFrameworkCore;
using ShoppingList.Entities;

namespace ShoppingList.Database
{
    public partial class ShoppingListDbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipePart> RecipeParts { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
    }
}