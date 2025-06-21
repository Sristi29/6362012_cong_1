using System;

class Program
{
    static void Main()
    {
        Forecast forecast = new Forecast();

        double presentValue = 1000;         
        double annualGrowthRate = 0.10;     
        int numberOfYears = 5;

        Console.WriteLine("📊 Financial Forecast Using Recursion:");
        double futureRecursive = forecast.CalculateFutureValueRecursive(presentValue, annualGrowthRate, numberOfYears);
        Console.WriteLine($"Recursive Future Value after {numberOfYears} years: ₹{futureRecursive:F2}");

        Console.WriteLine("\n⚙️ Financial Forecast Using Iteration:");
        double futureIterative = forecast.CalculateFutureValueIterative(presentValue, annualGrowthRate, numberOfYears);
        Console.WriteLine($"Iterative Future Value after {numberOfYears} years: ₹{futureIterative:F2}");
    }
}
