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
            DrawIsoscelesTriangle();

            Console.ReadKey();
        }

        static int ReadNumberFromConsole ()
        {
            int number;
            string enteredString = Console.ReadLine();

            // УЧЕСТЬ ИГНОР и ДОПИСАТЬ

            while (!(Int32.TryParse(enteredString, out number) && number > 0))
            {
                if (enteredString.Equals("0") || number < 0)
                {
                    Console.WriteLine("Ошибка! Число должно быть больше нуля!");
                }
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

            string star = "*";
            string space = "*";
            for (int i = 0; i <= number; i ++)
            //{                
            //        space = new string(' ', (number - 1) / 2);
            //                    Console.WriteLine(space + star);
            //    star += "**";

            }

            //i+="**"  j=(n-1)/2

        }
    }
}
