using MediatR;

namespace ShoppingList.Business.Implementation.Authentications.Commands.Login
{
    public class LoginCommand : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
