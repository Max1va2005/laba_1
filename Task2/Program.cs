namespace Task2
{
    internal class Program
    {
        static void PrintArray(int[] array)
        {
            foreach (int num in array)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        static List<int> GetDivisibleByK(int[] array, int k)
        {
            Func<int, bool> isDivisibleBy = n => n % k == 0;
            List<int> newArray = new List<int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (isDivisibleBy(array[i]))
                {
                    newArray.Add(array[i]);
                }
            }

            return newArray;
        }
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int k = 2; 
            
            Func<int, bool> isDivisibleBy = n => n % k == 0;
            int[] newArray = array.Where(isDivisibleBy).ToArray();
            PrintArray(newArray);

            List<int> newList = GetDivisibleByK(array, k);
            Console.WriteLine(string.Join(" ", newList));

        }
    }
}