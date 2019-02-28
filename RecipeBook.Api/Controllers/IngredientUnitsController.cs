using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.Business.Implementation.IngredientUnits.Queries;

namespace RecipeBook.Api.Controllers
{
    [Route("api/[controller]")]
    public class IngredientUnitsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IngredientUnitsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllIngredientUnitsQuery()));
        }
    }
}
