using System;
using ShoppingList.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingList.Business
{
    public interface IIngredientQuery
    {
        Task<IEnumerable<IngredientModel>> GetAllAsync();
        Task<IngredientModel> GetAsync(Guid id);
    }
}
