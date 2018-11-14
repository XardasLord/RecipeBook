using System.Collections.Generic;

namespace ShoppingList.Entities
{
    public class Recipe : BaseEntity
    {
        public Recipe()
        {
        }

        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public virtual ICollection<RecipePart> RecipeParts { get; set; }
    }
}
