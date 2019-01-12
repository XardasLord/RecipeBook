using System.Collections.Generic;

namespace RecipeBook.Entities
{
    public class Ingredient : BaseEntity
    {
        public Ingredient()
        {
        }

        public string Name { get; set; }
        public virtual ICollection<RecipePart> RecipeParts { get; set; }
    }
}
