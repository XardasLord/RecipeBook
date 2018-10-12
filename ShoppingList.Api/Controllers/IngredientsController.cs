using Microsoft.AspNetCore.Mvc;
using ShoppingList.Business;
using System.Threading.Tasks;

namespace ShoppingList.Api.Controllers
{
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientQuery _ingredientQuery;

        public IngredientsController(IIngredientQuery ingredientQuery)
        {
            _ingredientQuery = ingredientQuery;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _ingredientQuery.GetAllAsync());
        }
    }
}
