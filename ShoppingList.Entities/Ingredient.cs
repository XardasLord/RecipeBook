using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingList.Entities
{
    public class Ingredient : BaseEntity
    {
        public Ingredient()
        {
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<RecipePart> RecipeParts { get; set; }
    }
}
