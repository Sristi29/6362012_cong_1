using System;
using System.Collections.Generic;
using RetailInventory.Models;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("EF Core 8.0 Lab 2: DbContext & Models Example");
        Console.WriteLine("-----------------------------------------------");

        // Create dummy data to show model relationships
        var electronics = new Category
        {
            Id = 1,
            Name = "Electronics",
            Products = new List<Product>
            {
                new Product { Id = 101, Name = "Laptop", Price = 75000 },
                new Product { Id = 102, Name = "Smartphone", Price = 50000 }
            }
        };

        var groceries = new Category
        {
            Id = 2,
            Name = "Groceries",
            Products = new List<Product>
            {
                new Product { Id = 201, Name = "Rice Bag", Price = 1200 },
                new Product { Id = 202, Name = "Wheat Flour", Price = 800 }
            }
        };

        // Print Categories and Products
        PrintCategory(electronics);
        PrintCategory(groceries);
    }

    static void PrintCategory(Category category)
    {
        Console.WriteLine($"Category: {category.Name}");
        foreach (var product in category.Products)
        {
            Console.WriteLine($"  Product: {product.Name}, Price: ₹{product.Price}");
        }
        Console.WriteLine();
    }
}
