using Microsoft.EntityFrameworkCore;
using ShoppingList.Business.Queries;
using ShoppingList.Database;
using ShoppingList.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Business.Implementation.Queries
{
    public class RecipesQuery : IRecipesQuery
    {
        private readonly ShoppingListDbContext _shoppingListDbContext;

        public RecipesQuery(ShoppingListDbContext shoppingListDbContext)
        {
            _shoppingListDbContext = shoppingListDbContext;
        }

        public async Task<IEnumerable<Recipes>> GetAllAsync()
        {
            return await _shoppingListDbContext.Recipes
                .Where(x => !x.IsDeleted)
                .ToListAsync();
        }
    }
}
