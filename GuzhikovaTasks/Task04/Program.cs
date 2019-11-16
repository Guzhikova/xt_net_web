using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {

            int[][] userArray = CreateArray();            

            Console.WriteLine("\nПолученный ступенчатый массив:");
            DisplayArray(userArray);

            

            Console.ReadKey();
        }

        static int ReadNumberFromConsole()
        {
            int number;
            string enteredString = Console.ReadLine();

            while (!(Int32.TryParse(enteredString, out number) && number > 0))
            {
                Console.WriteLine("Введенное число некорректно! Пожалуйста, веедите снова");
                enteredString = Console.ReadLine();
            }

            return number;
        }
        static int[][] CreateArray ()
        {
            Console.WriteLine("Введите размерность массива:");

            int arraySize = ReadNumberFromConsole();

            int[][] array = new int[arraySize][];

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("\nВведите длину подмассива {0}:", i + 1);

                array[i] = new int[ReadNumberFromConsole()];

                Random rnd = new Random();

                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = rnd.Next(0, 100);
                }
            }

            return array;
        }
        static void DisplayArray (int[][] array)
        {
            Console.Write("{");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(" {");

                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write("{0}, ", array[i][j]);
                }

                Console.Write("} ");
            }

            Console.Write("}");
        }
    }
}
