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
            Console.WriteLine("Введите размерность массива:");

            int arraySize = ReadNumberFromConsole();

            int[][] userArray = new int[arraySize][];
            for (int i = 0; i < userArray.Length; i++)
            {
                Console.WriteLine("Введите :")


            }

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
        static void CreateArray (int size)
        {

        }
    }
}
