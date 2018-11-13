using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingList.CommonUtilities;
using ShoppingList.Entities;

namespace ShoppingList.Database
{
    public partial class ShoppingListDbContext : DbContext, IShoppingListDbContext
    {
        private readonly IGuidGenerator _guidGenerator;

        public ShoppingListDbContext(DbContextOptions<ShoppingListDbContext> options)
            : base(options)
        {
            _guidGenerator = new GuidGenerator();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            foreach (var entity in ChangeTracker.Entries().Where(e => e.State == EntityState.Added).Select(e => e.Entity as BaseEntity))
            {
                entity.Id = entity.Id != Guid.Empty ? entity.Id : _guidGenerator.Generate();
            }

            //TODO: Set created at, created by, modified at, deleted by, etc.
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
