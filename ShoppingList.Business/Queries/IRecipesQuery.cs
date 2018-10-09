using ShoppingList.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingList.Business.Queries
{
    public interface IRecipesQuery
    {
        Task<IEnumerable<Recipes>> GetAllAsync();
    }
}
