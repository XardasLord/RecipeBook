using MediatR;
using ShoppingList.Business.Models;

namespace ShoppingList.Business.Implementation.Ingredients.Commands.CreateIngredient
{
    public class CreateIngredientCommand : IRequest<IngredientModel>
    {
        public string Name { get; set; }
    }
}
