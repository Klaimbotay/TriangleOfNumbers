using System.IO;
using System;

namespace TriangleOfNumbersProgram
{
    class Program
    {
        static void Main()
        {
            List<List<int>> numbers = new List<List<int>>();
            try
            {
                using (StreamReader sr = new StreamReader("..\\..\\..\\TestFile.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        numbers.Add(line.Split(' ').Select(Int32.Parse).ToList());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            /*
             * Будем идти снизу вверх к вершине: для каждого элемента i-ой строки 
             * мы прибавляем наибольший из двух возможных элементов строки i+1, 
             * в итоге самый первый(верхний) элемент будет равен
             * максимально возможной сумме пути
             */

            int N = numbers.Count;

            for (int i = N - 2; i >= 0; i--)
                for (int j = 0; j <= i; j++)
                    numbers[i][j] += Math.Max(numbers[i + 1][j], numbers[i + 1][j + 1]);

            Console.WriteLine(numbers[0][0]);
        }
    }
}