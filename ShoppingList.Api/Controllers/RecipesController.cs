using Microsoft.AspNetCore.Mvc;
using ShoppingList.Business.Queries;
using System.Threading.Tasks;

namespace ShoppingList.Api.Controllers
{
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipesQuery _recipesQuery;

        public RecipesController(IRecipesQuery recipesQuery)
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
