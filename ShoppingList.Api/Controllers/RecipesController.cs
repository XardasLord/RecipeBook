using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Business.Models;
using ShoppingList.Business.Queries;
using ShoppingList.Business.Services;

namespace ShoppingList.Api.Controllers
{
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeQuery _recipeQuery;
        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeQuery recipeQuery, IRecipeService recipeService)
        {
            _recipeQuery = recipeQuery;
            _recipeService = recipeService;
        }

        // GET: api/Recipes
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _recipeQuery.GetAllAsync());
        }

        // GET: api/Recipes/00000000-0000-0000-0000-000000000000
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _recipeQuery.GetAsync(id));
        }

        // POST: api/Recipes
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] RecipeModel model)
        {
            var createdId = await _recipeService.AddAsync(model);
            model.Id = createdId;

            return CreatedAtAction("Get", new { id = createdId }, model);
        }

        //TODO: Add ID parameter getting from route
        // PUT: api/Recipes
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RecipeModel model)
        {
            await _recipeService.UpdateAsync(model);

            return CreatedAtAction("Get", new { id = model.Id }, model);
        }

        // DELETE: api/Recipes/00000000-0000-0000-0000-000000000000
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _recipeService.DeleteAsync(id);

            return NoContent();
        }
    }
}
