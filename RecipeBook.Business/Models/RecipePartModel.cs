using System;

namespace RecipeBook.Business.Models
{
    public class RecipePartModel
    {
        public Guid? Id { get; set; }
        public IngredientModel Ingredient { get; set; }
        public string Unit { get; set; }
        public decimal Quantity { get; set; }
    }
}
