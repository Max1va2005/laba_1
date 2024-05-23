using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{

    public delegate void SortDelegate(int[] array);

    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\User\\source\\repos\\ЛАБА_1\\Task6\\list.txt";
            int[] exampleData = ReadNumbersFromFile(filePath);

            CheckSortMethod(SelectionSort, StudentSelectionSort, exampleData);

            CheckSortMethod(CocktailSort, StudentCocktailSort, exampleData);

            
        }
        static void CheckSortMethod(SortDelegate referenceSort, SortDelegate studentSort, int[] data)
        {
            int[] referenceData = data.ToArray();
            int[] studentData = data.ToArray();

            Stopwatch stopwatch = Stopwatch.StartNew();
            referenceSort(referenceData);
            stopwatch.Stop();
            long referenceTime = stopwatch.ElapsedMilliseconds;

            stopwatch.Restart();
            studentSort(studentData);
            stopwatch.Stop();
            long studentTime = stopwatch.ElapsedMilliseconds;

            bool isSortedCorrectly = referenceData.SequenceEqual(studentData);
            bool isTimeSimilar = Math.Abs(referenceTime - studentTime) <= referenceTime * 0.00000000000000000001;

            PrintArray(referenceData);
            PrintArray(studentData);
            if (isSortedCorrectly && isTimeSimilar)
            {
                Console.WriteLine("Студентський метод пройшов перевірку.");
            }
            else
            {
                Console.WriteLine("Студентський метод не пройшов перевірку.");
            }
        }
        static int[] ReadNumbersFromFile(string filePath)
        {
            string text = File.ReadAllText(filePath);
            int[] numbers = text.Split(' ')
                                .Where(s => !string.IsNullOrEmpty(s))
                                .Select(int.Parse)
                                .ToArray();
            return numbers;
        }

        static void StudentSelectionSort(int[] array)
        {
            int n = array.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                int temp = array[minIndex];
                array[minIndex] = array[i];
                array[i] = temp;
                
            }

        }
        static void PrintArray(int[] array)
        {
            foreach (int num in array)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
        static void StudentCocktailSort(int[] array)
        {
            int start = 0, end = array.Length - 1;
            bool swapped = true;
            while (start < end && swapped)
            {
                swapped = false;
                for (int i = start+3; i < end; ++i)
                {
                    if (array[i] > array[i + 1])
                    {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        swapped = true;
                    }
                }
                if (!swapped)
                    break;
                swapped = true;
                --end;
                for (int i = end - 1; i >= start; --i)
                {
                    if (array[i] > array[i + 1])
                    {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        swapped = true;
                    }
                }
                ++start;

            }
        }
        static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i;
                bool swapNeeded = false;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                        swapNeeded = true;
                    }
                }

                if (swapNeeded)
                {
                    int temp = array[i];
                    array[i] = array[minIndex];
                    array[minIndex] = temp;
                }
            }
        }
        static void CocktailSort(int[] array)
        {
            bool swapped = true;
            int start = 0;
            int end = array.Length;

            while (swapped == true)
            {
                swapped = false;

                for (int i = start; i < end - 1; ++i)
                {
                    if (array[i] > array[i + 1])
                    {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        swapped = true;
                    }
                }

                if (swapped == false)
                    break;

                swapped = false;
                end--;

                for (int i = end - 1; i >= start; i--)
                {
                    if (array[i] > array[i + 1])
                    {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        swapped = true;
                    }
                }

                start++;
            }
        }

        
    }

}
