using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Product[] products = {
            new Product(1, "Shoes", "Footwear"),
            new Product(2, "Shirt", "Clothing"),
            new Product(3, "Watch", "Accessories"),
            new Product(4, "Jeans", "Clothing"),
            new Product(5, "Laptop", "Electronics")
        };

        Console.WriteLine("🔍 Linear Search:");
        var result1 = LinearSearch(products, "Watch");
        Console.WriteLine(result1 != null ? $"Found: {result1.ProductName}" : "Not found");

        Console.WriteLine("\n🔍 Binary Search:");
        var sortedProducts = products.OrderBy(p => p.ProductName).ToArray();
        var result2 = BinarySearch(sortedProducts, "Watch");
        Console.WriteLine(result2 != null ? $"Found: {result2.ProductName}" : "Not found");

        Console.WriteLine("\n📈 Financial Forecast:");
        double current = 1000;
        double growth = 0.10;
        int years = 5;

        double future = ForecastFutureValue(current, growth, years);
        Console.WriteLine($"Future Value after {years} years: ₹{future:F2}");
    }

    static Product? LinearSearch(Product[] list, string name)
    {
        foreach (var product in list)
        {
            if (product.ProductName == name)
                return product;
        }
        return null;
    }

    static Product? BinarySearch(Product[] list, string name)
    {
        int low = 0, high = list.Length - 1;
        while (low <= high)
        {
            int mid = (low + high) / 2;
            int compare = string.Compare(name, list[mid].ProductName);
            if (compare == 0)
                return list[mid];
            else if (compare < 0)
                high = mid - 1;
            else
                low = mid + 1;
        }
        return null;
    }

    static double ForecastFutureValue(double currentValue, double growthRate, int years)
    {
        if (years == 0)
            return currentValue;

        return ForecastFutureValue(currentValue * (1 + growthRate), growthRate, years - 1);
    }
}
