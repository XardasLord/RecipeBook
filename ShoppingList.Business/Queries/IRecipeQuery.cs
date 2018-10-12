using ShoppingList.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingList.Business.Queries
{
    public interface IRecipeQuery
    {
        Task<IEnumerable<RecipeModel>> GetAllAsync();
    }
}
