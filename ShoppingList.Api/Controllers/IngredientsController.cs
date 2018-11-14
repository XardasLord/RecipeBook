using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Business;
using ShoppingList.Business.Models;
using ShoppingList.Business.Services;

namespace ShoppingList.Api.Controllers
{
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientQuery _ingredientQuery;
        private readonly IIngredientService _ingredientService;

        public IngredientsController(IIngredientQuery ingredientQuery, IIngredientService ingredientService)
        {
            _ingredientQuery = ingredientQuery;
            _ingredientService = ingredientService;
        }

        // GET: api/Ingredients
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _ingredientQuery.GetAllAsync());
        }

        // GET: api/Ingredients/00000000-0000-0000-0000-000000000000
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _ingredientQuery.GetAsync(id));
        }

        // POST: api/Ingredients
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] IngredientModel model)
        {
            var createdId = await _ingredientService.AddAsync(model);
            model.Id = createdId;

            return CreatedAtAction("Get", new { id = createdId }, model);
        }
    }
}
