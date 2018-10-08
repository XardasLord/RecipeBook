namespace ShoppingList.Business
{
    using ShoppingList.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IIngredientsQuery
    {
        Task<IEnumerable<Ingredients>> GetAllAsync();
    }
}
