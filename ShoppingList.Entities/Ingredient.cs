using System.Collections.Generic;

namespace ShoppingList.Entities
{
    public class Ingredient : BaseEntity
    {
        public Ingredient()
        {
        }

        public string Name { get; set; }
        public virtual IEnumerable<RecipePart> RecipeParts { get; set; }
    }
}
