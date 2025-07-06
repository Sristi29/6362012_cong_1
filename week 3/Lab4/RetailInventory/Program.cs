using System;
using System.Linq;
using RetailInventory.Models;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("EF Core 8.0 Lab 4: CRUD Operations Started!");
        Console.WriteLine("--------------------------------------------");

        using (var context = new AppDbContext())
        {
            // 1️⃣ INSERT new Category and Products if not already added
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
                Console.WriteLine("✔ Inserted Categories and Products into DB.");
            }
            else
            {
                Console.WriteLine("✔ Data already exists. Skipping insert.");
            }

            // 2️⃣ READ & DISPLAY Products
            Console.WriteLine("\n📦 Products in DB:");
            var products = context.Products.Include(p => p.Category).ToList();
            foreach (var product in products)
            {
                Console.WriteLine($"- {product.Name} ({product.Category.Name}) : ₹{product.Price}");
            }
        }

        Console.WriteLine("\n🎉 CRUD Operations Completed!");
    }
}
