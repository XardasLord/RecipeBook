using System.Collections.Generic;
using MediatR;
using ShoppingList.Business.Models;

namespace ShoppingList.Business.Implementation.Recipes.Queries.GetAllRecipes
{
    public class GetAllRecipesQuery : IRequest<IEnumerable<RecipeModel>>
    {
    }
}
