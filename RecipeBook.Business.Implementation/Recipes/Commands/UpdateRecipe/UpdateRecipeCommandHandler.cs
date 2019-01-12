using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RecipeBook.Business.Models;
using RecipeBook.Database;
using RecipeBook.Entities;

namespace RecipeBook.Business.Implementation.Recipes.Commands.UpdateRecipe
{
    public class UpdateRecipeCommandHandler : IRequestHandler<UpdateRecipeCommand, RecipeModel>
    {
        private readonly IShoppingListDbContext _shoppingListDbContext;
        private readonly IMapper _mapper;

        public UpdateRecipeCommandHandler(IShoppingListDbContext shoppingListDbContext, IMapper mapper)
        {
            _shoppingListDbContext = shoppingListDbContext;
            _mapper = mapper;
        }

        public async Task<RecipeModel> Handle(UpdateRecipeCommand request, CancellationToken cancellationToken)
        {
            var recipePartsToRemove = await _shoppingListDbContext.Recipes
                .Where(x => x.Id == request.Id)
                .SelectMany(x => x.RecipeParts)
                .ToListAsync(cancellationToken);

            _shoppingListDbContext.RecipeParts.RemoveRange(recipePartsToRemove);

            var recipe = _mapper.Map<Recipe>(request);

            _shoppingListDbContext.Recipes.Update(recipe);

            await _shoppingListDbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<RecipeModel>(recipe);
        }
    }
}
