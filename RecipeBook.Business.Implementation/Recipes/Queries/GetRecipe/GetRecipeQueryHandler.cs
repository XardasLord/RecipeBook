using System;
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

        public async Task<RecipeModel> Handle(GetRecipeQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(GetRecipeQuery), "The GetRecipeQuery is null");
            }

            if (request.Id == Guid.Empty)
            {
                throw new ArgumentException(nameof(request.Id), "ID in GetRecipeQuery request is empty");
            }

            var recipe = await _shoppingListDbContext.Recipes
                .Include(x => x.RecipeParts)
                .ThenInclude(x => x.Ingredient)
                .Where(x => x.Id == request.Id && !x.IsDeleted)
                .FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map<RecipeModel>(recipe);
        }
    }
}
