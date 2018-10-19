using AutoMapper;
using ShoppingList.Business.Models;
using ShoppingList.Business.Services;
using ShoppingList.Database;
using ShoppingList.Entities;
using System;
using System.Linq;
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

        public async Task<Guid> AddAsync(RecipeModel model)
        {
            var recipe = _mapper.Map<Recipe>(model);

            _shoppingListDbContext.Recipes.Add(recipe);
            await _shoppingListDbContext.SaveChangesAsync();

            return recipe.Id;
        }

        public async Task UpdateAsync(RecipeModel model)
        {
            var recipeParts = _shoppingListDbContext.Recipes
                .Where(x => x.Id == model.Id)
                .SelectMany(x => x.RecipeParts)
                .ToList();

            foreach (var recipePart in recipeParts)
            {
                recipePart.IsDeleted = true;
                recipePart.DeletedAt = DateTime.Now; // TODO: Maybe do it somewhere in the override SaveChanges function in ShoppingList.Database project?
            }

            var recipe = _mapper.Map<Recipe>(model);

            _shoppingListDbContext.Recipes.Add(recipe);
            await _shoppingListDbContext.SaveChangesAsync();
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
