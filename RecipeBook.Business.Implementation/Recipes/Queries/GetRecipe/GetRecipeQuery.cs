using System;
using MediatR;
using RecipeBook.Business.Models;

namespace RecipeBook.Business.Implementation.Recipes.Queries.GetRecipe
{
    public class GetRecipeQuery : IRequest<RecipeModel>
    {
        public Guid Id { get; set; }
    }
}
