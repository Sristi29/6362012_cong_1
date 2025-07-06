using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RetailInventory.Models;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("EF Core 8.0 Lab 7: Full CRUD + LINQ + Aggregations");
        Console.WriteLine("---------------------------------------------------");

        using (var context = new AppDbContext())
        {
            // 1️⃣ INSERT: Add data if DB is empty
            if (!context.Categories.Any())
            {
                var electronics = new Category { Name = "Electronics" };
                var groceries = new Category { Name = "Groceries" };

                context.Categories.AddRange(electronics, groceries);
                context.Products.AddRange(
                    new Product { Name = "Laptop", Price = 75000, Category = electronics },
                    new Product { Name = "Smartphone", Price = 50000, Category = electronics },
                    new Product { Name = "Rice Bag", Price = 1200, Category = groceries },
                    new Product { Name = "Wheat Flour", Price = 800, Category = groceries }
                );

                context.SaveChanges();
                Console.WriteLine("✔ Inserted initial Categories and Products.");
            }
            else
            {
                Console.WriteLine("ℹ Data already exists. Skipping insert.");
            }

            // 2️⃣ UPDATE: Increase all Electronics prices by 15%
            var electronicsProducts = context.Products
                .Include(p => p.Category)
                .Where(p => p.Category.Name == "Electronics")
                .ToList();

            foreach (var product in electronicsProducts)
            {
                product.Price *= 1.15M; // Increase by 15%
            }
            context.SaveChanges();
            Console.WriteLine("✔ Updated Electronics product prices by 15%.");

            // 3️⃣ DELETE: Remove 'Rice Bag' if present
            var riceBag = context.Products.FirstOrDefault(p => p.Name == "Rice Bag");
            if (riceBag != null)
            {
                context.Products.Remove(riceBag);
                context.SaveChanges();
                Console.WriteLine("✔ Deleted 'Rice Bag' from DB.");
            }
            else
            {
                Console.WriteLine("ℹ 'Rice Bag' not found. Skipping delete.");
            }

            // 4️⃣ LINQ QUERIES
            // a) Display all products sorted by price
            Console.WriteLine("\n📦 Products (sorted by price):");
            var sortedProducts = context.Products
                .Include(p => p.Category)
                .OrderByDescending(p => p.Price)
                .ToList();

            foreach (var product in sortedProducts)
            {
                Console.WriteLine($"- {product.Name} ({product.Category.Name}) : ₹{product.Price:F2}");
            }

            // b) Display min, max, avg prices
            var minPrice = context.Products.Min(p => p.Price);
            var maxPrice = context.Products.Max(p => p.Price);
            var avgPrice = context.Products.Average(p => p.Price);

            Console.WriteLine("\n📊 Price Statistics:");
            Console.WriteLine($"✔ Minimum Price: ₹{minPrice:F2}");
            Console.WriteLine($"✔ Maximum Price: ₹{maxPrice:F2}");
            Console.WriteLine($"✔ Average Price: ₹{avgPrice:F2}");

            // c) Filter expensive products (>₹10,000)
            Console.WriteLine("\n💎 Products priced above ₹10,000:");
            var expensiveProducts = context.Products
                .Include(p => p.Category)
                .Where(p => p.Price > 10000)
                .ToList();

            foreach (var product in expensiveProducts)
            {
                Console.WriteLine($"- {product.Name} ({product.Category.Name}) : ₹{product.Price:F2}");
            }
        }

        Console.WriteLine("\n🎉 Lab 7 Completed Successfully!");
    }
}
