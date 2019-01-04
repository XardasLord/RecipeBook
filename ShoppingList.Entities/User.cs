namespace ShoppingList.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool IsBlocked { get; set; }
    }
}
