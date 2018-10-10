using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoppingList.Business.Models;
using ShoppingList.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Business.Implementation.Queries
{
    public class IngredientsQuery : IIngredientsQuery
    {
        private readonly ShoppingListDbContext _shoppingListDbContext;
        private readonly IMapper _mapper;

        public IngredientsQuery(ShoppingListDbContext shoppingListDbContext, IMapper mapper)
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
    }
}
