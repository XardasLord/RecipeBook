using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShoppingList.Business.Models;
using ShoppingList.Database;

namespace ShoppingList.Business.Implementation.Ingredients.Queries.GetIngredient
{
    public class GetIngredientQueryHandler : IRequestHandler<GetIngredientQuery, IngredientModel>
    {
        private readonly IShoppingListDbContext _shoppingListDbContext;
        private readonly IMapper _mapper;

        public GetIngredientQueryHandler(IShoppingListDbContext shoppingListDbContext, IMapper mapper)
        {
            _shoppingListDbContext = shoppingListDbContext;
            _mapper = mapper;
        }

        public async Task<IngredientModel> Handle(GetIngredientQuery request, CancellationToken cancellationToken)
        {
            var ingredient = await _shoppingListDbContext.Ingredients
                .Where(x => x.Id == request.Id && !x.IsDeleted)
                .FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map<IngredientModel>(ingredient);
        }
    }
}
