using Microsoft.EntityFrameworkCore;
using ShoppingList.Entities;

namespace ShoppingList.Database
{
    public class ShoppingListDbContext : DbContext
    {
        public ShoppingListDbContext(DbContextOptions<ShoppingListDbContext> options)
            : base(options)
        { }

        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<Recipes> Recipes { get; set; }
    }
}
