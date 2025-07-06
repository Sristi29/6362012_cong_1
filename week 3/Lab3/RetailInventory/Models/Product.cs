namespace RetailInventory.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Avoid CS8618 warning
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
