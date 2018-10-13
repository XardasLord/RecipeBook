using ShoppingList.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingList.Business.Queries
{
    public interface IRecipeQuery
    {
        Task<IEnumerable<RecipeModel>> GetAllAsync();
        Task<RecipeModel> GetAsync(Guid id);
    }
}
