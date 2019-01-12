using System.Collections.Generic;
using MediatR;
using RecipeBook.Business.Models;

namespace RecipeBook.Business.Implementation.Ingredients.Queries.GetAllIngredients
{
    public class GetAllIngredientsQuery : IRequest<IEnumerable<IngredientModel>>
    {
    }
}
