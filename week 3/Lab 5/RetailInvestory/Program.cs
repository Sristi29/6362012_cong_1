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
            Console.WriteLine("EF Core 8.0 Lab 5: Advanced Queries & Aggregations");
            Console.WriteLine("---------------------------------------------------");

            using (var context = new AppDbContext())
            {
                // Ensure DB is created
                context.Database.EnsureCreated();

                // Seed data if empty
                if (!context.Categories.Any())
                {
                    var electronics = new Category { Name = "Electronics" };
                    var groceries = new Category { Name = "Groceries" };

                    electronics.Products.Add(new Product { Name = "Laptop", Price = 75000 });
                    electronics.Products.Add(new Product { Name = "Smartphone", Price = 50000 });
                    groceries.Products.Add(new Product { Name = "Rice Bag", Price = 1200 });
                    groceries.Products.Add(new Product { Name = "Wheat Flour", Price = 800 });

                    context.Categories.AddRange(electronics, groceries);
                    context.SaveChanges();

                    Console.WriteLine("✔ Seeded initial data.");
                }
                else
                {
                    Console.WriteLine("✔ Data already exists.");
                }

                Console.WriteLine();

                // 🔥 LINQ Query 1: List all products ordered by price descending
                var products = context.Products
    .Include(p => p.Category) // 👈 Eager load Category
    .AsEnumerable()
    .OrderByDescending(p => (double)p.Price)
    .ToList();


                Console.WriteLine("📦 Products (sorted by price):");
                foreach (var p in products)
                {
                    Console.WriteLine($"- {p.Name} ({p.Category.Name}) : ₹{p.Price:N2}");
                }

                Console.WriteLine();

                // 🔥 LINQ Query 2: Total number of products per category
                var productCounts = context.Categories
                    .Select(c => new
                    {
                        Category = c.Name,
                        Count = c.Products.Count
                    })
                    .ToList();

                Console.WriteLine("📊 Product Count by Category:");
                foreach (var c in productCounts)
                {
                    Console.WriteLine($"- {c.Category}: {c.Count} items");
                }

                Console.WriteLine();

                // 🔥 LINQ Query 3: Average price of products
                var avgPrice = context.Products
                    .AsEnumerable()
                    .Average(p => (double)p.Price);
                Console.WriteLine($"💰 Average Product Price: ₹{avgPrice:N2}");

                Console.WriteLine("\n🎉 Advanced Queries Completed!");
            }
        }
    }
}
