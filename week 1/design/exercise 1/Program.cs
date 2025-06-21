using System;

class Program
{
    static void Main()
    {
        Logger logger1 = Logger.Instance;
        logger1.Log("First log message");

        Logger logger2 = Logger.Instance;
        logger2.Log("Second log message");

        Console.WriteLine("Are logger1 and logger2 the same instance? " +
                          (object.ReferenceEquals(logger1, logger2) ? "Yes" : "No"));
    }
}
