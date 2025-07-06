using System;
using System.Linq;
using RetailInvestory.Models;
using Microsoft.EntityFrameworkCore;

namespace RetailInvestory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("EF Core 8.0 Lab 6: Advanced Queries & Aggregations");
            Console.WriteLine("---------------------------------------------------");

            using (var db = new AppDbContext())
            {
                // Ensure DB exists
                db.Database.EnsureCreated();

                // Seed data only if empty
                if (!db.Categories.Any())
                {
                    var electronics = new Category { Name = "Electronics" };
                    var groceries = new Category { Name = "Groceries" };

                    db.Categories.AddRange(electronics, groceries);

                    db.Products.AddRange(
                        new Product { Name = "Laptop", Price = 75000, Category = electronics },
                        new Product { Name = "Smartphone", Price = 50000, Category = electronics },
                        new Product { Name = "Rice Bag", Price = 1200, Category = groceries },
                        new Product { Name = "Wheat Flour", Price = 800, Category = groceries },
                        new Product { Name = "LED TV", Price = 45000, Category = electronics },
                        new Product { Name = "Sugar", Price = 60, Category = groceries }
                    );

                    db.SaveChanges();
                    Console.WriteLine("✔ Seeded initial data.");
                }
                else
                {
                    Console.WriteLine("✔ Data already exists.");
                }

                Console.WriteLine();

                // List all products sorted by price descending
               var products = db.Products
                 .Include(p => p.Category)
                 .AsEnumerable()
                 .OrderByDescending(p => (double)p.Price)
                 .ToList();

                Console.WriteLine("📦 Products (sorted by price):");
foreach (var p in products)
{
    Console.WriteLine($"- {p.Name} ({p.Category.Name}) : ₹{p.Price}");
}

                Console.WriteLine();

                // Aggregation: Total price of all products
                var totalPrice = db.Products.Sum(p => p.Price);
                Console.WriteLine($"💰 Total Inventory Value: ₹{totalPrice}");

                // Aggregation: Average price
                var averagePrice = db.Products.Average(p => p.Price);
                Console.WriteLine($"📊 Average Product Price: ₹{averagePrice}");

                // Count products per category
                Console.WriteLine("\n📂 Product count by category:");
                var counts = db.Categories
                               .Select(c => new
                               {
                                   c.Name,
                                   ProductCount = c.Products.Count
                               })
                               .ToList();
                foreach (var c in counts)
                {
                    Console.WriteLine($"- {c.Name}: {c.ProductCount} products");
                }
            }
        }
    }
}
