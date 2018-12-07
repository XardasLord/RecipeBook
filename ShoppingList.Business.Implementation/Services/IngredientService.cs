using System;
using System.Threading.Tasks;
using AutoMapper;
using ShoppingList.Business.Helpers;
using ShoppingList.Business.Models;
using ShoppingList.Business.Services;
using ShoppingList.Database;
using ShoppingList.Entities;

namespace ShoppingList.Business.Implementation.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IShoppingListDbContext _shoppingListDbContext;
        private readonly IMapper _mapper;
        private readonly IIngredientHelper _ingerientHelper;

        public IngredientService(
            IShoppingListDbContext shoppingListDbContext,
            IMapper mapper,
            IIngredientHelper _ingerientHelper)
        {
            _shoppingListDbContext = shoppingListDbContext;
            _mapper = mapper;
            this._ingerientHelper = _ingerientHelper;
        }

        public async Task<Guid> AddAsync(IngredientModel model)
        {
            if (await _ingerientHelper.CheckIfIngredientExists(model.Name))
            {
                throw new ArgumentException($"Ingredient of name {model.Name} already exists.");
            }

            var ingredient = _mapper.Map<Ingredient>(model);

            _shoppingListDbContext.Ingredients.Add(ingredient);
            await _shoppingListDbContext.SaveChangesAsync();

            return ingredient.Id;
        }
    }
}
