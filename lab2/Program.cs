using System;

namespace ConsoleApp5
{
    class Program
    {
        // Метод для розв'язання системи лінійних рівнянь методом простої ітерації
        static void SimplIter(double[] cons, double[,] cofs, double epsilon, double[] start)
        {
            // Цикл для обмеження кількості ітерацій
            for (int i = 0; i != 30; i++)
            {
                // Обчислення нових значень змінних 
                double x1 = (cons[0] - cofs[0, 1] * start[1] - cofs[0, 2] * start[2]) / cofs[0, 0];
                double x2 = (cons[1] - cofs[1, 0] * start[0] - cofs[1, 2] * start[2]) / cofs[1, 1];
                double x3 = (cons[2] - cofs[2, 0] * start[0] - cofs[2, 1] * start[1]) / cofs[2, 2];

                double E1 = Math.Abs(x1) - Math.Abs(start[0]);
                double E2 = Math.Abs(x2) - Math.Abs(start[1]);
                double E3 = Math.Abs(x3) - Math.Abs(start[2]);

                // Виведення значень змінних та похибок на консоль
                Console.WriteLine($"{i + 1}:   {x1:f4}   {x2:f4}   {x3:f4}   {E1:f4}   {E2:f4}   {E3:f4}");

                // Перевірка умови завершення ітерацій
                if (E1 <= epsilon && E2 <= epsilon && E3 <= epsilon)
                {
                    Console.WriteLine("Перевірка результатів");
                    // Виведення результатів перевірки на початкових рівняннях системи
                    Console.WriteLine($"{cofs[0, 0]}*{x1}+{cofs[0, 1]}*{x2}+{cofs[0, 2]}*{x3}={cofs[0, 0] * x1 + cofs[0, 1] * x2 + cofs[0, 2] * x3}");
                    Console.WriteLine($"{cofs[1, 0]}*{x1}+{cofs[1, 1]}*{x2}+{cofs[1, 2]}*{x3}={cofs[1, 0] * x1 + cofs[1, 1] * x2 + cofs[1, 2] * x3}");
                    Console.WriteLine($"{cofs[2, 0]}*{x1}+{cofs[2, 1]}*{x2}+{cofs[2, 2]}*{x3}={cofs[2, 0] * x1 + cofs[2, 1] * x2 + cofs[2, 2] * x3}");
                    break; // Вихід з циклу, якщо досягнута необхідна точність
                }
                // Оновлення значень для наступної ітерації
                start[0] = x1;
                start[1] = x2;
                start[2] = x3;
            }
        }

        static void Main(string[] args)
        {
            // Встановлення кодування консолі UTF-8 для коректного відображення тексту
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Визначення матриці коефіцієнтів та вектора вільних членів
            double[,] cofs = { { -2, 1, 1 }, { 1, -2, 1 }, { -1, 3, -6 } };
            double[] cons = { 15, 10, 12 };
            double epsilon = 0.01; 
            double[] start = { cons[0] / cofs[0, 0], cons[1] / cofs[1, 1], cons[2] / cofs[2, 2] }; // Початкові значення змінних

            // Виведення заголовка таблиці на консоль
            Console.WriteLine($"{"Ітер",0}{"x1",7}{"x2",7}{"x3",7},{"E1",7}{"E2",7}{"E3",7}");

            SimplIter(cons, cofs, epsilon, start);

            Console.ReadLine();
        }
    }
}
