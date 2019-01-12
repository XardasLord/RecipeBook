using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using RecipeBook.Database;
using RecipeBook.Entities;
using RecipeBook.Security.PasswordUtilities;

namespace RecipeBook.Business.Implementation.Authentications.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Guid>
    {
        private readonly IShoppingListDbContext _shoppingListDbContext;
        private readonly IMapper _mapper;

        public RegisterCommandHandler(IShoppingListDbContext shoppingListDbContext, IMapper mapper)
        {
            _shoppingListDbContext = shoppingListDbContext;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);

            var hashSalt = PasswordEncryptionUtilities.GenerateSaltedHash(request.Password);
            user.Salt = hashSalt.Salt;
            user.Hash = hashSalt.Hash;

            await _shoppingListDbContext.Users.AddAsync(user, cancellationToken);
            await _shoppingListDbContext.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
