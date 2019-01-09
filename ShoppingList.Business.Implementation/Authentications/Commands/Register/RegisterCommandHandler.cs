using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ShoppingList.Database;
using ShoppingList.Entities;

namespace ShoppingList.Business.Implementation.Authentications.Commands.Register
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

            await _shoppingListDbContext.Users.AddAsync(user, cancellationToken);
            await _shoppingListDbContext.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
