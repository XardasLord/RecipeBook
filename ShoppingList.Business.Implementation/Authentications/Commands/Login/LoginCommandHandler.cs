using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShoppingList.Database;
using ShoppingList.Security;
using ShoppingList.Security.PasswordUtilities;

namespace ShoppingList.Business.Implementation.Authentications.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IShoppingListDbContext _shoppingListDbContext;
        private readonly IOptions<JwtSettings> _jwtSettings;

        public LoginCommandHandler(IShoppingListDbContext shoppingListDbContext, IOptions<JwtSettings> jwtSettings)
        {
            _shoppingListDbContext = shoppingListDbContext;
            _jwtSettings = jwtSettings;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _shoppingListDbContext.Users.FirstOrDefaultAsync(x => x.Email == request.Email && !x.IsDeleted, cancellationToken);
            if (user == null)
            {
                //TODO: Custom Exception types would be nice
                throw new Exception("Invalid credentials");
            }

            var isPasswordMatched = PasswordEncryptionUtilities.VerifyPassword(request.Password, user.Hash, user.Salt);
            if (!isPasswordMatched)
            {
                throw new Exception("Invalid credentials");
            }

            var tokenString = CreateTokenString();

            return tokenString;
        }

        private string CreateTokenString()
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Value.SecretKey));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: "http://localhost:4200",
                audience: "http://localhost:4200",
                claims: new List<Claim>(), // TODO: User roles, etc.
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: signinCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
    }
}
