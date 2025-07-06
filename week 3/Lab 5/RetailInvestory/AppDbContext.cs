using Microsoft.EntityFrameworkCore;
using RetailInvestory.Models;

namespace RetailInvestory
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
optionsBuilder.UseSqlite("Data Source=RetailInventoryDB.db");
        }
    }
}
