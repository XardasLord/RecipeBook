using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingList.Database
{
    public partial class ShoppingListDbContext : DbContext, IShoppingListDbContext
    {
        public ShoppingListDbContext(DbContextOptions<ShoppingListDbContext> options)
            : base(options)
        { }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //TODO: Set created at, created by, modified at, deleted by, etc.
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
