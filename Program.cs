using System;
using System.Globalization;
using System.Threading;

namespace ArrayMinMaxFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Задержка шага в мс (или Enter без задержки): ");
            int.TryParse(Console.ReadLine(), out int delay);

            Console.WriteLine("Введите числа через пробел:");
            string[] rawParts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (rawParts.Length == 0) return;

            double[] arr = new double[rawParts.Length];
            for (int i = 0; i < rawParts.Length; i++)
            {
                string val = rawParts[i].Replace(',', '.');
                arr[i] = double.Parse(val, CultureInfo.InvariantCulture);
            }

            double min = arr[0];
            double max = arr[0];

            // Проход по массиву с обновлением состояния на экране
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min) min = arr[i];
                if (arr[i] > max) max = arr[i];

                if (delay > 0)
                {
                    Console.Clear();
                    Console.WriteLine("=== Анализ массива в реальном времени ===");

                    // Показываем массив с подцветкой
                    Console.Write("Массив: ");
                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (j == i)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"[{arr[j]}] ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write($"{arr[j]} ");
                        }
                    }

                    // Табло текущих рекордов
                    Console.WriteLine("\n-----------------------------------------");
                    Console.WriteLine($"Текущий минимум : {min}");
                    Console.WriteLine($"Текущий максимум: {max}");
                    Console.WriteLine("-----------------------------------------");

                    Thread.Sleep(delay);
                }
            }

            // Финальный экран
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=== Анализ завершен ===");
            Console.ResetColor();
            Console.WriteLine($"Минимальный элемент: {min}");
            Console.WriteLine($"Максимальный элемент: {max}");

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}