using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingList.Entities
{
    public class Recipe : BaseEntity
    {
        public Recipe()
        {
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<RecipePart> RecipeParts { get; set; }
    }
}
