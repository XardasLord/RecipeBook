using System;
using MediatR;
using RecipeBook.Business.Models;

namespace RecipeBook.Business.Implementation.Ingredients.Queries.GetIngredient
{
    public class GetIngredientQuery : IRequest<IngredientModel>
    {
        public Guid Id { get; set; }
    }
}
