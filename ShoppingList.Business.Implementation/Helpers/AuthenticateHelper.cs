using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingList.Business.Helpers;
using ShoppingList.Database;

namespace ShoppingList.Business.Implementation.Helpers
{
    public class AuthenticateHelper : IAuthenticateHelper
    {
        private readonly IShoppingListDbContext _shoppingListDbContext;

        public AuthenticateHelper(IShoppingListDbContext shoppingListDbContext)
        {
            _shoppingListDbContext = shoppingListDbContext;
        }

        public async Task<bool> CheckIfUserWithEmailExistAsync(string email)
        {
            return await _shoppingListDbContext
                .Users
                .AnyAsync(x => !x.IsBlocked && !x.IsDeleted && x.Email == email);
        }

        public async Task<bool> CheckIfUserCanBeLoggedAsync(string email, string password)
        {
            return await _shoppingListDbContext
                .Users
                .AnyAsync(x => !x.IsBlocked && !x.IsDeleted && x.Email == email && x.Password == password);
        }
    }
}
