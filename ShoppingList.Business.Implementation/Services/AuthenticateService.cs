using System;
using System.Threading.Tasks;
using AutoMapper;
using ShoppingList.Business.Models;
using ShoppingList.Business.Services;
using ShoppingList.Database;
using ShoppingList.Entities;

namespace ShoppingList.Business.Implementation.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IShoppingListDbContext _shoppingListDbContext;
        private readonly IMapper _mapper;

        public AuthenticateService(IShoppingListDbContext shoppingListDbContext, IMapper mapper)
        {
            _shoppingListDbContext = shoppingListDbContext;
            _mapper = mapper;
        }

        public async Task<Guid> Register(UserModel model)
        {
            var user = _mapper.Map<User>(model);

            await _shoppingListDbContext.Users.AddAsync(user);
            await _shoppingListDbContext.SaveChangesAsync();

            return user.Id;
        }
    }
}
