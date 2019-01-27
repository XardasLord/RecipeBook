using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using RecipeBook.Entities;

namespace RecipeBook.Database
{
    public interface IShoppingListDbContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DatabaseFacade Database { get; }

        DbSet<Recipe> Recipes { get; set; }
        DbSet<RecipePart> RecipeParts { get; set; }
        DbSet<Ingredient> Ingredients { get; set; }
        DbSet<User> Users { get; set; }
    }
}
