using ShoppingList.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingList.Business
{
    public interface IIngredientsQuery
    {
        Task<IEnumerable<IngredientModel>> GetAllAsync();
    }
}
