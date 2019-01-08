using System;
using MediatR;

namespace ShoppingList.Business.Implementation.Recipes.Commands.DeleteRecipe
{
    public class DeleteRecipeCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
