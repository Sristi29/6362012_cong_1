namespace RetailInvestory.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public Category Category { get; set; } = null!;
    }
}
