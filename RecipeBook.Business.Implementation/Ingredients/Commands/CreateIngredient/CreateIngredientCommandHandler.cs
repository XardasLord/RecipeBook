using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using RecipeBook.Business.Helpers;
using RecipeBook.Business.Models;
using RecipeBook.Database;
using RecipeBook.Entities;

namespace RecipeBook.Business.Implementation.Ingredients.Commands.CreateIngredient
{
    public class CreateIngredientCommandHandler : IRequestHandler<CreateIngredientCommand, IngredientModel>
    {
        private readonly IShoppingListDbContext _shoppingListDbContext;
        private readonly IMapper _mapper;
        private readonly IIngredientHelper _ingredientHelper;

        public CreateIngredientCommandHandler(IShoppingListDbContext shoppingListDbContext, IMapper mapper, IIngredientHelper ingredientHelper)
        {
            _shoppingListDbContext = shoppingListDbContext;
            _mapper = mapper;
            _ingredientHelper = ingredientHelper;
        }

        public async Task<IngredientModel> Handle(CreateIngredientCommand request, CancellationToken cancellationToken)
        {
            if (await _ingredientHelper.CheckIfIngredientExists(request.Name))
            {
                throw new ArgumentException($"Ingredient of name {request.Name} already exists.");
            }

            var ingredient = _mapper.Map<Ingredient>(request);

            _shoppingListDbContext.Ingredients.Add(ingredient);
            await _shoppingListDbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<IngredientModel>(ingredient);
        }
    }
}
