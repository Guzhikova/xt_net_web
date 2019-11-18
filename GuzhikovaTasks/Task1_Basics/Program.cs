using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task 1.1. RECTANGLE
            RectangleArea();

            //Task 1.2. TRIANGLE
            DrawRightAngledTriangle();

            //Task 1.3. ANOTHER TRIANGLE

            Console.ReadKey();
        }

        static int ReadNumberFromConsole ()
        {
            int number;
            string enteredString = Console.ReadLine();

            // УЧЕСТЬ ИГНОР и ДОПИСАТЬ

            while (!(Int32.TryParse(enteredString, out number) && number > 0))
            {
                Console.WriteLine("Введенное число некорректно! Пожалуйста, веедите снова");
                enteredString = Console.ReadLine();
            }

            return number;
        }

        static void RectangleArea ()
        {
            Console.WriteLine("----------------------Task 1.1. RECTANGLE----------------------");

            Console.Write("Введите сторону а: ");
            int a = ReadNumberFromConsole();

            Console.Write("Введите сторону b: ");
            int b = ReadNumberFromConsole();

            Console.WriteLine("Площадь прямоугольника со сторонами {0} и {1} равна {2}", a, b, a * b);

        }

        static void DrawRightAngledTriangle()
        {
            Console.WriteLine("\n----------------------Task 1.2. TRIANGLE----------------------");
            Console.Write("Введите число:");
            int number = ReadNumberFromConsole();

            for (string i = "*"; i.Length <= number; i+="*")
            {
                Console.WriteLine(i);
            }
        }

        static void DrawIsoscelesTriangle()
        {
            Console.WriteLine("\n----------------------Task 1.3. ANOTHER TRIANGLE----------------------");
            Console.Write("Введите число:");
            int number = ReadNumberFromConsole();

        }
    }
}
