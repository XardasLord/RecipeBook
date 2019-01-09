using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Business.Implementation.Recipes.Commands.CreateRecipe;
using ShoppingList.Business.Implementation.Recipes.Commands.DeleteRecipe;
using ShoppingList.Business.Implementation.Recipes.Commands.UpdateRecipe;
using ShoppingList.Business.Implementation.Recipes.Queries.GetAllRecipes;
using ShoppingList.Business.Implementation.Recipes.Queries.GetRecipe;

namespace ShoppingList.Api.Controllers
{
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RecipesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllRecipesQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _mediator.Send(new GetRecipeQuery { Id = id }));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateRecipeCommand command)
        {
            var recipeId = await _mediator.Send(command);

            return Ok(recipeId);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRecipeCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteRecipeCommand { Id = id });

            return NoContent();
        }
    }
}