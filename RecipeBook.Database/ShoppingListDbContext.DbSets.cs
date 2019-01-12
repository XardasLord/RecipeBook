using Microsoft.EntityFrameworkCore;
using RecipeBook.Entities;

namespace RecipeBook.Database
{
    public partial class ShoppingListDbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipePart> RecipeParts { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<User> Users { get; set; }
    }
}