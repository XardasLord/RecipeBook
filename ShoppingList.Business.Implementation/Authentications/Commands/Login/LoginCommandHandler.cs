using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using ShoppingList.Business.Helpers;

namespace ShoppingList.Business.Implementation.Authentications.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private const string SecretKey = "cV0JzOy,O;Hi*=GlARx|DVW/;8SM/k"; //TODO: Move as an environment value
        private readonly IAuthenticateHelper _authenticateHelper;

        public LoginCommandHandler(IAuthenticateHelper authenticateHelper)
        {
            _authenticateHelper = authenticateHelper;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var areValidCredentials = await _authenticateHelper.CheckIfUserCanBeLoggedAsync(request.Email, request.Password);
            if (!areValidCredentials)
            {
                return null;
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: "http://localhost:4200",
                audience: "http://localhost:4200",
                claims: new List<Claim>(), // TODO: User roles, etc.
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return tokenString;
        }
    }
}
