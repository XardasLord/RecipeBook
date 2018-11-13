namespace ShoppingList.Entities
{
    public class RecipePart : BaseEntity
    {
        public RecipePart()
        {
        }

        public Ingredient Ingredient { get; set; }
        public Recipe Recipe { get; set; }
        // Probably some unit's dictionary later?
        public string Unit { get; set; }
        public decimal Quantity { get; set; }
    }
}
