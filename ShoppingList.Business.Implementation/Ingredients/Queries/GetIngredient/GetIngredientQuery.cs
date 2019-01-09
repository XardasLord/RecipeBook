using System;
using MediatR;
using ShoppingList.Business.Models;

namespace ShoppingList.Business.Implementation.Ingredients.Queries.GetIngredient
{
    public class GetIngredientQuery : IRequest<IngredientModel>
    {
        public Guid Id { get; set; }
    }
}
