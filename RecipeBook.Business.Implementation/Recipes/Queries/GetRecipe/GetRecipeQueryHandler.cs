using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RecipeBook.Business.Models;
using RecipeBook.Database;

namespace RecipeBook.Business.Implementation.Recipes.Queries.GetRecipe
{
    public class GetRecipeQueryHandler : IRequestHandler<GetRecipeQuery, RecipeModel>
    {
        private readonly IShoppingListDbContext _shoppingListDbContext;
        private readonly IMapper _mapper;

        public GetRecipeQueryHandler(IShoppingListDbContext shoppingListDbContext, IMapper mapper)
        {
            _shoppingListDbContext = shoppingListDbContext;
            _mapper = mapper;
        }

        public async Task<RecipeModel> Handle(GetRecipeQuery request, CancellationToken cancellationToken)
        {
            var recipe = await _shoppingListDbContext.Recipes
                .Include(x => x.RecipeParts)
                .ThenInclude(x => x.Ingredient)
                .Where(x => x.Id == request.Id && !x.IsDeleted)
                .FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map<RecipeModel>(recipe);
        }
    }
}
