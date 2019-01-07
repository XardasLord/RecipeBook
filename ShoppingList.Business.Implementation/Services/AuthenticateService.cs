using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using ShoppingList.Business.Helpers;
using ShoppingList.Business.Models;
using ShoppingList.Business.Services;
using ShoppingList.Database;
using ShoppingList.Entities;

namespace ShoppingList.Business.Implementation.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private const string SecretKey = "cV0JzOy,O;Hi*=GlARx|DVW/;8SM/k"; //TODO: Move as an environment value
        private readonly IShoppingListDbContext _shoppingListDbContext;
        private readonly IMapper _mapper;
        private readonly IAuthenticateHelper _authenticateHelper;

        public AuthenticateService(
            IShoppingListDbContext shoppingListDbContext, 
            IMapper mapper, 
            IAuthenticateHelper authenticateHelper)
        {
            _shoppingListDbContext = shoppingListDbContext;
            _mapper = mapper;
            _authenticateHelper = authenticateHelper;
        }

        public async Task<Guid> RegisterAsync(UserModel model)
        {
            var user = _mapper.Map<User>(model);

            await _shoppingListDbContext.Users.AddAsync(user);
            await _shoppingListDbContext.SaveChangesAsync();

            return user.Id;
        }

        public async Task<string> LoginAsync(UserModel model)
        {
            var areValidCredentials = await _authenticateHelper.CheckIfUserCanBeLoggedAsync(model.Email, model.Password);
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
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return tokenString;
        }
    }
}
