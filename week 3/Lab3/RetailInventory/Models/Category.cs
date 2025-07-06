namespace RetailInventory.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Avoid CS8618 warning
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
