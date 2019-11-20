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
            ////Task 1.1. RECTANGLE
            //RectangleArea();

            ////Task 1.2. TRIANGLE
            //DrawRightAngledTriangle();

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

            StringBuilder stars = new StringBuilder(number);

            for (int i = 0; i < number; i++)
            {                
                Console.WriteLine(stars.Append("*"));
            }
        }

        static void DrawIsoscelesTriangle()
        {
            Console.WriteLine("\n----------------------Task 1.3. ANOTHER TRIANGLE----------------------");
            Console.Write("Введите число:");
            int number = ReadNumberFromConsole();

            StringBuilder stars = new StringBuilder(number * 2 - 1);
            stars.Append(' ', number * 2 - 1);
            
            for (int index = number-1; index > 0; index--)
            {
                if (index == (number - 1))
                {
                    stars.Insert(index, "*");
                }else
                {
                    stars.Insert(index, "*", 2);
                }

                Console.WriteLine(stars.ToString());
                stars.Remove(index - 1, 1);          

                if (index == 1)
                {
                    stars.Insert(0, "*", 2);
                    Console.WriteLine(stars.ToString());
                }
            }     

        }
    }
}
