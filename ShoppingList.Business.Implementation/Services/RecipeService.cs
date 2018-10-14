using AutoMapper;
using ShoppingList.Business.Models;
using ShoppingList.Business.Services;
using ShoppingList.Database;
using ShoppingList.Entities;
using System.Threading.Tasks;

namespace ShoppingList.Business.Implementation.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly ShoppingListDbContext _shoppingListDbContext;
        private readonly IMapper _mapper;

        public RecipeService(ShoppingListDbContext shoppingListDbContext, IMapper mapper)
        {
            _shoppingListDbContext = shoppingListDbContext;
            _mapper = mapper;
        }

        public async Task AddAsync(RecipeModel model)
        {
            var recipe = _mapper.Map<Recipe>(model);

            _shoppingListDbContext.Recipes.Add(recipe);
            await _shoppingListDbContext.SaveChangesAsync();

            model.Id = recipe.Id;
        }
    }
}
