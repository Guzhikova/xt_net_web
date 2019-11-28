using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task2_Encapsulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"----------------------Task 2.1. ROUND----------------------{Environment.NewLine}");
            Round();

            Console.WriteLine($"{Environment.NewLine}----------------------Task 2.2. TRIANGLE----------------------");
            Triangle();

            Console.ReadKey();
        }

        static int ReadNumberFromConsole()
        {
            int number;
            string enteredString = Console.ReadLine();

            while (!Int32.TryParse(enteredString, out number))
            {
                Console.WriteLine("Введенное число некорректно! Пожалуйста, веедите снова");
                enteredString = Console.ReadLine();
            }

            return number;
        }

        /// <summary>
        /// The method reads three int parameters from Console
        /// </summary>
        /// <param name="name1">First parameters name</param>
        /// <param name="name2">Second parameters name</param>
        /// <param name="name3">Third parameters name</param>
        /// <param name="param1">First parameter</param>
        /// <param name="param2">Second parameter</param>
        /// <param name="param3">Third parameter</param>
        static void GetParameters(string name1, string name2, string name3, out int param1, out int param2, out int param3)
        {
            Console.Write($"{Environment.NewLine}Введите данные: {Environment.NewLine}{name1} = ");
            param1 = ReadNumberFromConsole();
            Console.Write($"{name2} = ");
            param2 = ReadNumberFromConsole();
            Console.Write($"{name3} = ");
            param3 = ReadNumberFromConsole();
        }

        static void Round()
        {
            Round round = new Round();

            Console.WriteLine("КРУГ ПО УМОЛЧАНИЮ: ");
            Round_GetInfo(round);

            int number;
            do
            {
                Console.WriteLine($"{Environment.NewLine}    1: Внести изменения в данный круг.{Environment.NewLine} " +
                    $"   2: Создать новый круг. {Environment.NewLine} " +
                    $"   Любая другая цифра: Перейти к следующему заданию. ");
                number = ReadNumberFromConsole();

                switch (number)
                {
                    case 1:
                        Round_Change(round);
                        break;
                    case 2:
                        Round_CreateNew();
                        break;

                    default:
                        break;
                }

            } while (number == 1 || number == 2);
        }
        static void Round_GetInfo(Round round)
        {
            Console.WriteLine("Центр ({0}, {1}). Радиус {2}. Длина описанной окружности {3}. Площадь круга {4}.",
          round.X, round.Y, round.Radius, round.Length.ToString("0.0"), round.Area.ToString("0.0"));
        }
        static void Round_Change(Round round)
        {
            int x, y, radius;
            GetParameters("X", "Y", "Radius", out x, out y, out radius);

            round.X = x;
            round.Y = y;

            try
            {
                round.Radius = radius;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"      {ex.Message}");
                Console.WriteLine("      Внимание! Значения радиуса изменены на значение по умолчанию (Radius = 1)");
                round.Radius = 1;
            }

            Console.WriteLine($"{Environment.NewLine}ПАРАМЕТРЫ ТЕКУЩЕГО КРУГА ИЗМЕНЕНЫ: ");
            Round_GetInfo(round);
        }
        static void Round_CreateNew()
        {
            int x, y, radius;
            GetParameters("X", "Y", "Radius", out x, out y, out radius);
            Round round;

            try
            {
                round = new Round(x, y, radius);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"      {ex.Message}");
                Console.WriteLine("      Внимание! Значения радиуса изменены на значение по умолчанию (Radius = 1)");

                round = new Round(x, y);
            }

            Console.WriteLine($"{Environment.NewLine}ЗАДАН НОВЫЙ КРУГ: ");
            Round_GetInfo(round);
        }

        static void Triangle()
        {
            Console.WriteLine("Расчёт периметра и площади треугольника по трем сторонам");
            Triangle triangle = new Triangle();
            int a = 0, b = 0, c = 0;
            bool isCorrectSides = false;

            do
            {
                try
                {
                    GetParameters("A", "B", "C", out a, out b, out c);
                    triangle = new Triangle(a, b, c);
                    isCorrectSides = true;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArithmeticException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (!isCorrectSides);

            Console.WriteLine($"Периметр данного треугольника равен {triangle.GetPerimeter()}, площадь равна {triangle.GetArea().ToString("0.00")}");
        }
    }

    class Round
    {
        public Round(int x = 0, int y = 0, int radius = 1)
        {
            X = x;
            Y = y;
            Radius = radius;
        }

        public int X { get; set; }
        public int Y { get; set; }

        private int _radius;
        public int Radius
        {
            get => _radius;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("ERROR! Radius should be more than zero");
                _radius = value;
            }
        }

        public double Length => 2 * Math.PI * Radius;
        public double Area => Math.PI * Radius * Radius;
    }

    class Triangle
    {
        public Triangle()
        {
            A = 1;
            B = 1;
            C = 1;
        }

        public Triangle(int a, int b, int c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentException("Error! The side of triangle should be more than zero.");

            if (a > (b + c) || b > (a + c) || c > (a + b))
                throw new ArithmeticException("Error! The side of triangle can't be greater than sum of other 2 sides.");

            A = a;
            B = b;
            C = c;
        }

        public int A { get; }
        public int B { get; }
        public int C { get; }

        public int GetPerimeter()
        {
            return A + B + C;
        }

        public double GetArea()
        {
            double p = (double)GetPerimeter() / 2;

            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }
    }
}





