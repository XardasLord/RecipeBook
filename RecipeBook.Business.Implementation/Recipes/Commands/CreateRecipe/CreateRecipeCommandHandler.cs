using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using RecipeBook.Database;
using RecipeBook.Entities;

namespace RecipeBook.Business.Implementation.Recipes.Commands.CreateRecipe
{
    public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, Guid>
    {
        private readonly IShoppingListDbContext _shoppingListDbContext;
        private readonly IMapper _mapper;

        public CreateRecipeCommandHandler(IShoppingListDbContext shoppingListDbContext, IMapper mapper)
        {
            _shoppingListDbContext = shoppingListDbContext;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            var recipe = _mapper.Map<Recipe>(request);

            foreach (var recipePart in recipe.RecipeParts)
            {
                _shoppingListDbContext.Ingredients.Attach(recipePart.Ingredient);
            }

            _shoppingListDbContext.Recipes.Add(recipe);
            await _shoppingListDbContext.SaveChangesAsync(cancellationToken);

            return recipe.Id;
        }
    }
}
