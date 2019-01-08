using System;
using MediatR;
using ShoppingList.Business.Models;

namespace ShoppingList.Business.Implementation.Recipes.Queries.GetRecipe
{
    public class GetRecipeQuery : IRequest<RecipeModel>
    {
        public Guid Id { get; set; }
    }
}
