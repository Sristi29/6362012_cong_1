public class Forecast
{
    public double CalculateFutureValueRecursive(double currentValue, double growthRate, int years)
    {
        if (years == 0)
            return currentValue;

        return CalculateFutureValueRecursive(currentValue * (1 + growthRate), growthRate, years - 1);
    }

    public double CalculateFutureValueIterative(double currentValue, double growthRate, int years)
    {
        for (int i = 0; i < years; i++)
        {
            currentValue *= (1 + growthRate);
        }
        return currentValue;
    }
}
