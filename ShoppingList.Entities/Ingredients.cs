namespace ShoppingList.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Ingredients : BaseEntity
    {
        public Ingredients()
        {
        }

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
    }
}
