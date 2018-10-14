using Microsoft.AspNetCore.Mvc;
using ShoppingList.Business.Models;
using ShoppingList.Business.Queries;
using ShoppingList.Business.Services;
using System;
using System.Threading.Tasks;

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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _recipeQuery.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _recipeQuery.GetAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] RecipeModel model)
        {
            await _recipeService.AddAsync(model);

            return CreatedAtAction("Get", new {id = model.Id}, model);
        }
    }
}
