using System;

namespace RecipeBook.Entities
{
    public class RecipePart : BaseEntity
    {
        public RecipePart()
        {
        }

        // Probably some unit's dictionary later?
        public string Unit { get; set; }
        public decimal Quantity { get; set; }
        public Guid IngredientId { get; set; }
        public virtual Ingredient Ingredient { get; set; }
        public Guid RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
