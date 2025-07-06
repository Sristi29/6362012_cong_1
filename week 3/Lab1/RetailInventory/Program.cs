// --------------------------------------------
// Lab 1: Understanding ORM with EF Core 8.0
// --------------------------------------------

// ✅ What is ORM?
// ORM (Object-Relational Mapping) maps C# classes to database tables.
// Developers work with C# objects instead of raw SQL queries.
// EF Core takes care of translating object changes into SQL commands.

// ✅ EF Core vs EF Framework
// EF Core: Cross-platform, lightweight, supports LINQ and async queries.
// EF Framework (EF6): Windows-only, mature, but heavier.

// ✅ EF Core 8.0 Features
// - JSON column mapping
// - Compiled models for faster startup
// - Better bulk operations
// - Interceptors for advanced control

using System;

class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        // Create sample data
        var category = new Category { Id = 1, Name = "Electronics" };
        var product = new Product { Id = 101, Name = "Laptop", Price = 75000, Category = category };

        // Print demo ORM mapping
        Console.WriteLine("EF Core 8.0 Lab 1: ORM Mapping Example");
        Console.WriteLine("--------------------------------------");
        Console.WriteLine($"Category ID: {category.Id}, Name: {category.Name}");
        Console.WriteLine($"Product ID: {product.Id}, Name: {product.Name}");
        Console.WriteLine($"Price: ₹{product.Price}");
        Console.WriteLine($"Belongs to Category: {product.Category.Name}");
    }
}
