using MediatR;
using RecipeBook.Business.Models;

namespace RecipeBook.Business.Implementation.Ingredients.Commands.CreateIngredient
{
    public class CreateIngredientCommand : IRequest<IngredientModel>
    {
        public string Name { get; set; }
    }
}
