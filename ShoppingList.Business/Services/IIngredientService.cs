using ShoppingList.Business.Models;
using System;
using System.Threading.Tasks;

namespace ShoppingList.Business.Services
{
    public interface IIngredientService
    {
        Task<Guid> AddAsync(IngredientModel model);
    }
}
