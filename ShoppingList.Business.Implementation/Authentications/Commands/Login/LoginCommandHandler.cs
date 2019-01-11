using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShoppingList.Business.Helpers;
using ShoppingList.Security;

namespace ShoppingList.Business.Implementation.Authentications.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IAuthenticateHelper _authenticateHelper;
        private readonly IOptions<JwtSettings> _jwtSettings;

        public LoginCommandHandler(IAuthenticateHelper authenticateHelper, IOptions<JwtSettings> jwtSettings)
        {
            _authenticateHelper = authenticateHelper;
            _jwtSettings = jwtSettings;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var areValidCredentials = await _authenticateHelper.CheckIfUserCanBeLoggedAsync(request.Email, request.Password);
            if (!areValidCredentials)
            {
                return null;
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Value.SecretKey));
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
