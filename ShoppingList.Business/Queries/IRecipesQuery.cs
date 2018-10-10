using ShoppingList.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingList.Business.Queries
{
    public interface IRecipesQuery
    {
        Task<IEnumerable<RecipeModel>> GetAllAsync();
    }
}
