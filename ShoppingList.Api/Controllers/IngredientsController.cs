using Microsoft.AspNetCore.Mvc;
using ShoppingList.Business;
using System.Threading.Tasks;

namespace ShoppingList.Api.Controllers
{
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientsQuery _ingredientsQuery;

        public IngredientsController(IIngredientsQuery ingredientsQuery)
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
