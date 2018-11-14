using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ShoppingList.Business.Models;
using ShoppingList.Business.Services;
using ShoppingList.Database;
using ShoppingList.Entities;

namespace ShoppingList.Business.Implementation.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IShoppingListDbContext _shoppingListDbContext;
        private readonly IMapper _mapper;

        public RecipeService(IShoppingListDbContext shoppingListDbContext, IMapper mapper)
        {
            _shoppingListDbContext = shoppingListDbContext;
            _mapper = mapper;
        }

        public async Task<Guid> AddAsync(RecipeModel model)
        {
            var recipe = _mapper.Map<Recipe>(model);

            foreach (var recipePart in recipe.RecipeParts)
            {
                _shoppingListDbContext.Ingredients.Attach(recipePart.Ingredient);
            }

            _shoppingListDbContext.Recipes.Add(recipe);
            await _shoppingListDbContext.SaveChangesAsync();

            return recipe.Id;
        }

        public async Task<Guid> UpdateAsync(RecipeModel model)
        {
            var recipePartsToRemove = _shoppingListDbContext.Recipes
                .Where(x => x.Id == model.Id)
                .SelectMany(x => x.RecipeParts)
                .ToList();

            _shoppingListDbContext.RecipeParts.RemoveRange(recipePartsToRemove);

            var recipe = _mapper.Map<Recipe>(model);

            _shoppingListDbContext.Recipes.Update(recipe);
            await _shoppingListDbContext.SaveChangesAsync();

            return recipe.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var recipe = _shoppingListDbContext.Recipes
                .FirstOrDefault(x => x.Id == id);

            if (recipe != null)
            {
                recipe.IsDeleted = true;
                recipe.DeletedAt = DateTime.Now; // TODO: Maybe do it somewhere in the override SaveChanges function in ShoppingList.Database project?

                await _shoppingListDbContext.SaveChangesAsync();
            }

        }
    }
}
