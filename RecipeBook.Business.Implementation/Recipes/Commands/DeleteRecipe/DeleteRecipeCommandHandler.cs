using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RecipeBook.Database;
using RecipeBook.Entities;

namespace RecipeBook.Business.Implementation.Recipes.Commands.DeleteRecipe
{
    public class DeleteRecipeCommandHandler : IRequestHandler<DeleteRecipeCommand>
    {
        private readonly IShoppingListDbContext _shoppingListDbContext;

        public DeleteRecipeCommandHandler(IShoppingListDbContext shoppingListDbContext)
        {
            _shoppingListDbContext = shoppingListDbContext;
        }

        public async Task<Unit> Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
        {
            var recipe = await _shoppingListDbContext.Recipes
                .FindAsync(request.Id);

            if (recipe == null)
            {
                throw new KeyNotFoundException($"{nameof(Recipe)} to delete with ID: {request.Id} was not found in database");
            }

            recipe.IsDeleted = true;
            recipe.DeletedAt = DateTime.Now; // TODO: Maybe do it somewhere in the override SaveChanges function in ShoppingList.Database project?

            await _shoppingListDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
