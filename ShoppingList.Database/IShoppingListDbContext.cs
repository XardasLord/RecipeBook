using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingList.Entities;

namespace ShoppingList.Database
{
    public interface IShoppingListDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        DbSet<Recipe> Recipes { get; set; }
        DbSet<RecipePart> RecipeParts { get; set; }
        DbSet<Ingredient> Ingredients { get; set; }
    }
}
