using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using RecipeBook.Database;
using RecipeBook.Entities;

namespace RecipeBook.Business.Implementation.Recipes.Commands.CreateRecipe
{
    public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, Guid>
    {
        private readonly IShoppingListDbContext _shoppingListDbContext;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public CreateRecipeCommandHandler(IShoppingListDbContext shoppingListDbContext, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _shoppingListDbContext = shoppingListDbContext;
            _mapper = mapper;
            _httpContext = httpContext;
        }

        public async Task<Guid> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            var recipe = _mapper.Map<Recipe>(request);

            foreach (var recipePart in recipe.RecipeParts)
            {
                _shoppingListDbContext.Ingredients.Attach(recipePart.Ingredient);
            }

            recipe.CreatedBy = _httpContext.HttpContext.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            _shoppingListDbContext.Recipes.Add(recipe);
            await _shoppingListDbContext.SaveChangesAsync(cancellationToken);

            return recipe.Id;
        }
    }
}
