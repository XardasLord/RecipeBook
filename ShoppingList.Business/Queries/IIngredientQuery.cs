using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingList.Business.Models;

namespace ShoppingList.Business
{
    public interface IIngredientQuery
    {
        Task<IEnumerable<IngredientModel>> GetAllAsync();
        Task<IngredientModel> GetAsync(Guid id);
    }
}
