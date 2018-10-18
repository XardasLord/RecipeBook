using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingList.Entities
{
    public class RecipePart : BaseEntity
    {
        public RecipePart()
        {
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public Ingredient Ingredient { get; set; }
        public Recipe Recipe { get; set; }
        // Probably some unit's dictionary later?
        public string Unit { get; set; }
        public decimal Quantity { get; set; }
    }
}
