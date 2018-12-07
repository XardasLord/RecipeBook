using System.Threading.Tasks;

namespace ShoppingList.Business.Helpers
{
    public interface IIngredientHelper
    {
        Task<bool> CheckIfIngredientExists(string ingredientName);
    }
}
