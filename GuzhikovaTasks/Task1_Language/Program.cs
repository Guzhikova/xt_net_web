using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Language
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------------Task 1.7. ARRAY PROCESSING----------------------");
            ArrayProcessing();

            Console.ReadKey();
        }

        static void ArrayProcessing()
        {
            int[] array = CreateArray(20);

            Console.Write($"{Environment.NewLine} Исходный массив: min = { MinValue(array)}, max = { MaxValue(array) + Environment.NewLine}");
            DisplayArray(array);

            SortArray(array);

            Console.Write($"{Environment.NewLine} Отсортированный массив: {Environment.NewLine}");
            DisplayArray(array);
        }

        static int MinValue(int[] array)
        {
            int min = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                    min = array[i];
            }

            return min;
        }

        static int MaxValue(int[] array)
        {
            int max = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                    max = array[i];
            }

            return max;
        }

        static int[] CreateArray(int length)
        {
            int[] array = new int[length];

            Random rnd = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(100);
            }

            return array;
        }

        static void DisplayArray(int[] array)
        {
            Console.Write(Environment.NewLine + "{");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($" {array[i]} ");
            }

            Console.Write("}" + Environment.NewLine);
        }

        static void SortArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int min = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                        min = j;
                }

                int temp = array[i];
                array[i] = array[min];
                array[min] = temp;
            }
        }
    }
}
