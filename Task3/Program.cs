using System;

namespace Task3
{
    class Program
    {
        delegate double SeriesTerm(int n); 
        static double CalculateSeriesSum(SeriesTerm term, double precision)
        {
            double sum = 0;
            int n = 0;
            double currentTermValue = term(n);

            while (true)
            {
                sum += currentTermValue;
                n++;
                currentTermValue = term(n);

                if (Math.Abs(currentTermValue) < precision) 
                    break;
            }

            return sum;
        }

        static void Main(string[] args)
        {
            double sum1 = CalculateSeriesSum(n => 1.0 / Math.Pow(2, n), 0.0001);
            Console.WriteLine($"Sum of series 1: {sum1}");

           
            double sum2 = CalculateSeriesSum(n => 1.0 / Factorial(n + 1), 0.0001);
            Console.WriteLine($"Sum of series 2: {sum2}");

           
            double sum3 = CalculateSeriesSum(n => Math.Pow(-1, n) * 1.0 / Math.Pow(2, n), 0.0001);
            Console.WriteLine($"Sum of series 3: {sum3}");
        }

        static double Factorial(int n)
        {
            double result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
