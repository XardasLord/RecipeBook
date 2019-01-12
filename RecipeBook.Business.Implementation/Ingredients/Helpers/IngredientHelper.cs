using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeBook.Business.Helpers;
using RecipeBook.Database;

namespace RecipeBook.Business.Implementation.Ingredients.Helpers
{
    public class IngredientHelper : IIngredientHelper
    {
        private readonly IShoppingListDbContext _shoppingListDbContext;

        public IngredientHelper(IShoppingListDbContext shoppingListDbContext)
        {
            _shoppingListDbContext = shoppingListDbContext;
        }

        public async Task<bool> CheckIfIngredientExists(string ingredientName)
        {
            return await _shoppingListDbContext.Ingredients.AnyAsync(x => x.Name.ToLower() == ingredientName);
        }
    }
}
