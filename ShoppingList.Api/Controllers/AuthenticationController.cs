using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Business.Models;
using ShoppingList.Business.Services;

namespace ShoppingList.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;

        public AuthenticationController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        // POST: api/Authenticate
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserModel user)
        {
            var createdId = await _authenticateService.Register(user);
            user.Id = createdId;

            return Ok(); // Created (201) ?
        }
    }
}
