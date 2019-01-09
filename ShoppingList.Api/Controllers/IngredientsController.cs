using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Business.Implementation.Ingredients.Commands.CreateIngredient;
using ShoppingList.Business.Implementation.Ingredients.Queries.GetAllIngredients;
using ShoppingList.Business.Implementation.Ingredients.Queries.GetIngredient;
using ShoppingList.Business.Models;
using ShoppingList.Business.Services;

namespace ShoppingList.Api.Controllers
{
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;
        private readonly IMediator _mediator;

        public IngredientsController(IIngredientService ingredientService, IMediator mediator)
        {
            _ingredientService = ingredientService;
            _mediator = mediator;
        }

        // GET: api/ingredients
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllIngredientsQuery()));
        }

        // GET: api/ingredients/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _mediator.Send(new GetIngredientQuery { Id = id }));
        }

        // POST: api/ingredients
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateIngredientCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
