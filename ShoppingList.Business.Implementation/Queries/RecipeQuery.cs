using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoppingList.Business.Models;
using ShoppingList.Business.Queries;
using ShoppingList.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Business.Implementation.Queries
{
    public class RecipeQuery : IRecipeQuery
    {
        private readonly ShoppingListDbContext _shoppingListDbContext;
        private readonly IMapper _mapper;

        public RecipeQuery(ShoppingListDbContext shoppingListDbContext, IMapper mapper)
        {
            _shoppingListDbContext = shoppingListDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RecipeModel>> GetAllAsync()
        {
            var recipes = await _shoppingListDbContext.Recipes
                .Where(x => !x.IsDeleted)
                .ToListAsync();

            return _mapper.Map<IEnumerable<RecipeModel>>(recipes);
        }

        public async Task<RecipeModel> GetAsync(Guid id)
        {
            var recipe = await _shoppingListDbContext.Recipes
                .Include(x => x.RecipeParts)
                .ThenInclude(x => x.Ingredient)
                .Where(x => x.Id == id && !x.IsDeleted)
                .FirstOrDefaultAsync();

            return _mapper.Map<RecipeModel>(recipe);
        }
    }
}
