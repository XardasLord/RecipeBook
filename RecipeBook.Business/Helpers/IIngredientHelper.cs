using System.Threading.Tasks;

namespace RecipeBook.Business.Helpers
{
    public interface IIngredientHelper
    {
        Task<bool> CheckIfIngredientExists(string ingredientName);
    }
}
