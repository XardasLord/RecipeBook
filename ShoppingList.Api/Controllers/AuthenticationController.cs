using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Business.Implementation.Authentications.Commands.Login;
using ShoppingList.Business.Implementation.Authentications.Commands.Register;
using ShoppingList.Business.Services;

namespace ShoppingList.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;
        private readonly IMediator _mediator;

        public AuthenticationController(IAuthenticateService authenticateService, IMediator mediator)
        {
            _authenticateService = authenticateService;
            _mediator = mediator;
        }

        // POST: api/authenticate/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        // POST: api/authenticate/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var token = await _mediator.Send(command);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { Token = token });
        }
    }
}
