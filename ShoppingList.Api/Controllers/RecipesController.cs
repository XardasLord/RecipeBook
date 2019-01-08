using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        // GET: api/Recipes/00000000-0000-0000-0000-000000000000
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _mediator.Send(new GetRecipeQuery { Id = id }));
        }

        // POST: api/Recipes
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add([FromBody] RecipeModel model)
        {
            var createdId = await _recipeService.AddAsync(model);
            model.Id = createdId;

            return CreatedAtAction("Get", new { id = createdId }, model);
        }

        //TODO: Add ID parameter getting from route
        // PUT: api/Recipes
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] RecipeModel model)
        {
            await _recipeService.UpdateAsync(model);

            return CreatedAtAction("Get", new { id = model.Id }, model);
        }

        // DELETE: api/Recipes/00000000-0000-0000-0000-000000000000
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _recipeService.DeleteAsync(id);

            return NoContent();
        }
    }
}
