using System;
using System.Threading.Tasks;
using AutoMapper;
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

        public IngredientService(IShoppingListDbContext shoppingListDbContext, IMapper mapper)
        {
            _shoppingListDbContext = shoppingListDbContext;
            _mapper = mapper;
        }

        public async Task<Guid> AddAsync(IngredientModel model)
        {
            var ingredient = _mapper.Map<Ingredient>(model);

            _shoppingListDbContext.Ingredients.Add(ingredient);
            await _shoppingListDbContext.SaveChangesAsync();

            return ingredient.Id;
        }
    }
}
