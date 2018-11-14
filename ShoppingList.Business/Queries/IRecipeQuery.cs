using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingList.Business.Models;

namespace ShoppingList.Business.Queries
{
    public interface IRecipeQuery
    {
        Task<IEnumerable<RecipeModel>> GetAllAsync();
        Task<RecipeModel> GetAsync(Guid id);
    }
}
