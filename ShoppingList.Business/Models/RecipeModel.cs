using System.Collections.Generic;

namespace ShoppingList.Business.Models
{
    public class RecipeModel
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public IEnumerable<IngredientModel> Ingredients { get; set; }
    }
}