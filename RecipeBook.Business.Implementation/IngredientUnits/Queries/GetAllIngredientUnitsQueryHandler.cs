using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace RecipeBook.Business.Implementation.IngredientUnits.Queries
{
    public class GetAllIngredientUnitsQueryHandler : IRequestHandler<GetAllIngredientUnitsQuery>
    {
        public Task<Unit> Handle(GetAllIngredientUnitsQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
