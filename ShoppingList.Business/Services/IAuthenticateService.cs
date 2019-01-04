using System;
using System.Threading.Tasks;
using ShoppingList.Business.Models;

namespace ShoppingList.Business.Services
{
    public interface IAuthenticateService
    {
        Task<Guid> RegisterAsync(UserModel model);
        Task<string> LoginAsync(UserModel model);
    }
}
