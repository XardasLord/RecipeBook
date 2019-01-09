using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Business.Implementation.Ingredients.Commands.CreateIngredient;
using ShoppingList.Business.Implementation.Ingredients.Queries.GetAllIngredients;
using ShoppingList.Business.Implementation.Ingredients.Queries.GetIngredient;

namespace ShoppingList.Api.Controllers
{
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IngredientsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllIngredientsQuery()));
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _mediator.Send(new GetIngredientQuery { Id = id }));
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateIngredientCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
