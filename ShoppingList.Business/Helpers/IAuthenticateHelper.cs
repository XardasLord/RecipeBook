using System.Threading.Tasks;

namespace ShoppingList.Business.Helpers
{
    public interface IAuthenticateHelper
    {
        Task<bool> CheckIfUserWithEmailExistAsync(string email);
        Task<bool> CheckIfUserCanBeLoggedAsync(string email, string password);
    }
}
