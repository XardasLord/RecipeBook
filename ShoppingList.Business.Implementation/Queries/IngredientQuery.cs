using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoppingList.Business.Models;
using ShoppingList.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Business.Implementation.Queries
{
    public class IngredientQuery : IIngredientQuery
    {
        private readonly ShoppingListDbContext _shoppingListDbContext;
        private readonly IMapper _mapper;

        public IngredientQuery(ShoppingListDbContext shoppingListDbContext, IMapper mapper)
        {
            _shoppingListDbContext = shoppingListDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<IngredientModel>> GetAllAsync()
        {
            var ingredients = await _shoppingListDbContext.Ingredients
                .Where(x => !x.IsDeleted)
                .ToListAsync();

            return _mapper.Map<IEnumerable<IngredientModel>>(ingredients);
        }

        public async Task<IngredientModel> GetAsync(Guid id)
        {
            var ingredient = await _shoppingListDbContext.Ingredients
                .Where(x => x.Id == id && !x.IsDeleted)
                .FirstOrDefaultAsync();

            return _mapper.Map<IngredientModel>(ingredient);
        }
    }
}
