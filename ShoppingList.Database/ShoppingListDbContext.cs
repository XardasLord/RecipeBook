using Microsoft.EntityFrameworkCore;

namespace ShoppingList.Database
{
    public class ShoppingListDbContext : DbContext, IShoppingListDbContext
    {
        public ShoppingListDbContext(DbContextOptions<ShoppingListDbContext> options)
            : base(options)
        { }
    }
}
