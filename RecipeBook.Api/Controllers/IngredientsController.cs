using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.Business.Implementation.Ingredients.Commands.CreateIngredient;
using RecipeBook.Business.Implementation.Ingredients.Queries.GetAllIngredients;
using RecipeBook.Business.Implementation.Ingredients.Queries.GetIngredient;

namespace RecipeBook.Api.Controllers
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
