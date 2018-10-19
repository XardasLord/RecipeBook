using ShoppingList.Business.Models;
using System;
using System.Threading.Tasks;

namespace ShoppingList.Business.Services
{
    public interface IRecipeService
    {
        Task<Guid> AddAsync(RecipeModel model);
        Task UpdateAsync(RecipeModel model);
        Task DeleteAsync(Guid id);
    }
}
