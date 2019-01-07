using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ShoppingList.Entities;

namespace ShoppingList.Database
{
    public interface IShoppingListDbContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        DatabaseFacade Database { get; }

        DbSet<Recipe> Recipes { get; set; }
        DbSet<RecipePart> RecipeParts { get; set; }
        DbSet<Ingredient> Ingredients { get; set; }
        DbSet<User> Users { get; set; }
    }
}
