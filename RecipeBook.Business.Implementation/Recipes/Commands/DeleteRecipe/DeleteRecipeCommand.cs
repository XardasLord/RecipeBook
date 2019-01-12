using System;
using MediatR;

namespace RecipeBook.Business.Implementation.Recipes.Commands.DeleteRecipe
{
    public class DeleteRecipeCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
