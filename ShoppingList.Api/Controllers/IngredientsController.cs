using Microsoft.AspNetCore.Mvc;
using ShoppingList.Business;
using System.Threading.Tasks;

namespace ShoppingList.Api.Controllers
{
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientQuery _ingredientsQuery;

        public IngredientsController(IIngredientQuery ingredientsQuery)
        {
            _ingredientsQuery = ingredientsQuery;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _ingredientsQuery.GetAllAsync());
        }
    }
}
