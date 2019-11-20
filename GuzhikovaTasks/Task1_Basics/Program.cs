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
            Console.WriteLine("----------------------Task 1.1. RECTANGLE----------------------");
            RectangleArea();

            Console.WriteLine("\n----------------------Task 1.2. TRIANGLE----------------------");
            DrawRightAngledTriangle();

            Console.WriteLine("\n----------------------Task 1.3. ANOTHER TRIANGLE----------------------");
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
            Console.Write("Введите сторону а: ");
            int a = ReadNumberFromConsole();

            Console.Write("Введите сторону b: ");
            int b = ReadNumberFromConsole();

            Console.WriteLine("Площадь прямоугольника со сторонами {0} и {1} равна {2}", a, b, a * b);

        }

        static void DrawRightAngledTriangle()
        {
            Console.Write("Введите число:");

            int number = ReadNumberFromConsole();

            StringBuilder stars = new StringBuilder(number);

            for (int i = 0; i < number; i++)
            {                
                Console.WriteLine(stars.Append("*"));
            }
        }

        static void DrawIsoscelesTriangle()
        {
            Console.Write("Введите число:");
            int number = ReadNumberFromConsole();

            StringBuilder stars = new StringBuilder(number * 2 - 1);
            stars.Append(' ', number * 2 - 1);

            for (int index = (number - 1); index >= 0; index--)
            {              
                stars.Insert(index, "*", (index == number-1) ? 1 : 2);
          
                Console.WriteLine(stars.ToString());

                if (index > 0)
                stars.Remove(index - 1, 1);                
            }      
        }
    }
}
