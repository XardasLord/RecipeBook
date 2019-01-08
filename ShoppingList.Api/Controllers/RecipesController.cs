using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Business.Implementation.Recipes.Commands.CreateRecipe;
using ShoppingList.Business.Implementation.Recipes.Queries.GetAllRecipes;
using ShoppingList.Business.Implementation.Recipes.Queries.GetRecipe;
using ShoppingList.Business.Models;
using ShoppingList.Business.Services;

namespace ShoppingList.Api.Controllers
{
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly IMediator _mediator;

        public RecipesController(IRecipeService recipeService, IMediator mediator)
        {
            _recipeService = recipeService;
            _mediator = mediator;
        }

        // GET: api/recipes
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllRecipesQuery()));
        }

        // GET: api/recipes/guid
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _mediator.Send(new GetRecipeQuery { Id = id }));
        }

        // POST: api/recipes
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add([FromBody] CreateRecipeCommand command)
        {
            var recipeId = await _mediator.Send(command);

            return Ok(recipeId);
        }

        //TODO: Add ID parameter getting from route
        // PUT: api/recipes
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] RecipeModel model)
        {
            await _recipeService.UpdateAsync(model);

            return CreatedAtAction("Get", new { id = model.Id }, model);
        }

        // DELETE: api/recipes/guid
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _recipeService.DeleteAsync(id);

            return NoContent();
        }
    }
}
