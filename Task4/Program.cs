using System;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    var delegates = new Func<double, double>[]
                    {
                        x => Math.Sqrt(Math.Abs(x)),
                        x => Math.Pow(x, 3),
                        x => x + 3.5
                    };

                    var input = Console.ReadLine().Trim().Split();
                    if (input.Length == 2)
                    {
                        int index = int.Parse(input[0]);
                        double value = double.Parse(input[1]);
                        Console.WriteLine(delegates[index](value));
                    }
                    else
                    {
                        throw new FormatException("Invalid input format. Please provide index and value separated by space.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"An error occurred: {e.Message}");
                    break;
                }
            }
        }
    }
}
