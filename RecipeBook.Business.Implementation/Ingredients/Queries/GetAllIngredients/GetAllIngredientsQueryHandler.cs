using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RecipeBook.Business.Models;
using RecipeBook.Database;

namespace RecipeBook.Business.Implementation.Ingredients.Queries.GetAllIngredients
{
    public class GetAllIngredientsQueryHandler : IRequestHandler<GetAllIngredientsQuery, IEnumerable<IngredientModel>>
    {
        private readonly IShoppingListDbContext _shoppingListDbContext;
        private readonly IMapper _mapper;

        public GetAllIngredientsQueryHandler(IShoppingListDbContext shoppingListDbContext, IMapper mapper)
        {
            _shoppingListDbContext = shoppingListDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<IngredientModel>> Handle(GetAllIngredientsQuery request, CancellationToken cancellationToken)
        {
            var ingredients = await _shoppingListDbContext.Ingredients
                .Where(x => !x.IsDeleted)
                .OrderBy(x => x.Name)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<IngredientModel>>(ingredients);
        }
    }
}
