using System.Collections.Generic;
using MediatR;
using ShoppingList.Business.Models;

namespace ShoppingList.Business.Implementation.Ingredients.Queries.GetAllIngredients
{
    public class GetAllIngredientsQuery : IRequest<IEnumerable<IngredientModel>>
    {
    }
}
