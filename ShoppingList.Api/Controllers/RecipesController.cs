using Microsoft.AspNetCore.Mvc;
using ShoppingList.Business.Queries;
using System.Threading.Tasks;

namespace ShoppingList.Api.Controllers
{
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeQuery _recipesQuery;

        public RecipesController(IRecipeQuery recipesQuery)
        {
            _recipesQuery = recipesQuery;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _recipesQuery.GetAllAsync());
        }
    }
}
