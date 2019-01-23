using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RecipeBook.CommonUtilities;
using RecipeBook.Entities;

namespace RecipeBook.Database
{
    public partial class ShoppingListDbContext : DbContext, IShoppingListDbContext
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IGuidGenerator _guidGenerator;

        public ShoppingListDbContext(DbContextOptions<ShoppingListDbContext> options, IHttpContextAccessor httpContext)
            : base(options)
        {
            _httpContext = httpContext;
            _guidGenerator = new GuidGenerator();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            foreach (var entity in ChangeTracker.Entries().Where(e => e.State == EntityState.Added).Select(e => e.Entity as BaseEntity))
            {
                //TODO: CreatedBy
                entity.Id = entity.Id != Guid.Empty ? entity.Id : _guidGenerator.Generate();
                entity.CreatedAt = DateTime.Now;
                entity.CreatedBy = _httpContext.HttpContext.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            }

            foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Modified).Select(e => e.Entity as BaseEntity))
            {
                //TODO: ModifiedBy
                entry.ModifiedAt = DateTime.Now;
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
