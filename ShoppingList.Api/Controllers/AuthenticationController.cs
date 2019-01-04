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

        // POST: api/Authenticate/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserModel user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            var createdId = await _authenticateService.RegisterAsync(user);
            user.Id = createdId;

            return Ok(); // Created (201) ?
        }

        // POST: api/Authenticate/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserModel user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            var token = await _authenticateService.LoginAsync(user);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
