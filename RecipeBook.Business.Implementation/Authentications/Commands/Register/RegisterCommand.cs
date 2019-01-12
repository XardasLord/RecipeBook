using System;
using MediatR;

namespace RecipeBook.Business.Implementation.Authentications.Commands.Register
{
    public class RegisterCommand : IRequest<Guid>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
