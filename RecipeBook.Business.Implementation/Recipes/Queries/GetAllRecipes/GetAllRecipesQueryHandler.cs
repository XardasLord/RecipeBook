using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RecipeBook.Business.Models;
using RecipeBook.Database;

namespace RecipeBook.Business.Implementation.Recipes.Queries.GetAllRecipes
{
    public class GetAllRecipesQueryHandler : IRequestHandler<GetAllRecipesQuery, IEnumerable<RecipeModel>>
    {
        private readonly IShoppingListDbContext _shoppingListDbContext;
        private readonly IMapper _mapper;

        public GetAllRecipesQueryHandler(IShoppingListDbContext shoppingListDbContext, IMapper mapper)
        {
            _shoppingListDbContext = shoppingListDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RecipeModel>> Handle(GetAllRecipesQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            ValidateRequest(request);

            var recipes = await _shoppingListDbContext.Recipes
                .Where(x => !x.IsDeleted)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<RecipeModel>>(recipes);
        }

        private static void ValidateRequest(GetAllRecipesQuery request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(GetAllRecipesQuery), "The GetAllRecipesQuery is null");
            }
        }
    }
}
