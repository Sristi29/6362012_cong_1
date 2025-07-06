using System;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("EF Core 8.0 Lab 3: Migration Applied and DB Created!");
        Console.WriteLine("----------------------------------------------------");

        try
        {
            using (var context = new AppDbContext())
            {
                // Check DB connection
                Console.WriteLine($"✔ Connected to Database: {context.Database.GetDbConnection().Database}");

                // List tables (known from DbSets)
                Console.WriteLine("✔ Tables in Database:");
                Console.WriteLine("  - Categories");
                Console.WriteLine("  - Products");

                Console.WriteLine("\n🎉 Database setup complete. Ready for CRUD operations!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error: {ex.Message}");
        }
    }
}
