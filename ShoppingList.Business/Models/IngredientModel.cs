using System;

namespace ShoppingList.Business.Models
{
    public class IngredientModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
    }
}
