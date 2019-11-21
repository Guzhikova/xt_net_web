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
            Console.WriteLine(Environment.NewLine + "Исходный массив:");
            DisplayArray(array);

        }

        static void MinValue(int[] array)
        {
            int min = array;

            for (int i = 0; i < array.Length; i++)
            {

            }
        }

        static void MaxValue(int[] array)
        {

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
    }
}
