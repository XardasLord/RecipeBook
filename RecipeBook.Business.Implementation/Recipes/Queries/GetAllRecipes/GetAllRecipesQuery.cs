using System.Collections.Generic;
using MediatR;
using RecipeBook.Business.Models;

namespace RecipeBook.Business.Implementation.Recipes.Queries.GetAllRecipes
{
    public class GetAllRecipesQuery : IRequest<IEnumerable<RecipeModel>>
    {
    }
}
