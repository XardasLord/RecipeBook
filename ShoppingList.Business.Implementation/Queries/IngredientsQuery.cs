namespace ShoppingList.Business.Implementation.Queries
{
    using Microsoft.EntityFrameworkCore;
    using ShoppingList.Database;
    using ShoppingList.Entities;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class IngredientsQuery : IIngredientsQuery
    {
        private readonly ShoppingListDbContext _shoppingListDbContext;

        public IngredientsQuery(ShoppingListDbContext shoppingListDbContext)
        {
            _shoppingListDbContext = shoppingListDbContext;
        }

        public async Task<IEnumerable<Ingredients>> GetAllAsync()
        {
            return await _shoppingListDbContext.Ingredients
                .Where(x => !x.IsDeleted)
                .ToListAsync();
        }
    }
}
