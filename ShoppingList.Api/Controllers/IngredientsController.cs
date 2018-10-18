using System;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Business;
using System.Threading.Tasks;
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _ingredientQuery.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _ingredientQuery.GetAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] IngredientModel model)
        {
            var createdId = await _ingredientService.AddAsync(model);
            model.Id = createdId;

            return CreatedAtAction("Get", new { id = createdId }, model);
        }
    }
}
