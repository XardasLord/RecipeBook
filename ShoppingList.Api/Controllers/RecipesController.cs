using Microsoft.AspNetCore.Mvc;
using ShoppingList.Business.Models;
using ShoppingList.Business.Queries;
using ShoppingList.Business.Services;
using System.Threading.Tasks;

namespace ShoppingList.Api.Controllers
{
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeQuery _recipeQuery;
        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeQuery recipeQuery)
        {
            _recipeQuery = recipeQuery;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _recipeQuery.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] RecipeModel model)
        {
            var result = await _recipeService.AddAsync(model);

            if (result > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Recipe save failed");
            }
        }
    }
}
