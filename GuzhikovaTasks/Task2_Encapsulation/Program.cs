using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Encapsulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"----------------------Task 2.1. ROUND----------------------{Environment.NewLine}");
            Round();

            Console.WriteLine($"{Environment.NewLine}----------------------Task 2.2. TRIANGLE----------------------{Environment.NewLine}");

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

        static void Round()
        {
            Round round = new Round();

            Console.WriteLine("КРУГ ПО УМОЛЧАНИЮ: ");
            Round_GetInfo(round);

            int number;
            do
            {
                Console.WriteLine($"{Environment.NewLine} 1. Внести изменения в данный круг.{Environment.NewLine} " +
                    $"2. Создать новый круг. {Environment.NewLine} " +
                    $"3. Перейти к следующему заданию. [или любая другая цифра]");
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
            Round_GetParams(out x, out y, out radius);

            round.X = x;
            round.Y = y;
            round.Radius = radius;

            Console.WriteLine($"{Environment.NewLine}---ПАРАМЕТРЫ ТЕКУЩЕГО КРУГА ИЗМЕНЕНЫ: ");
            Round_GetInfo(round);
        }
        static void Round_CreateNew()
        {
            int x, y, radius;
            Round_GetParams(out x, out y, out radius);

            Round round = new Round(x, y, radius);

            Console.WriteLine($"{Environment.NewLine}---ЗАДАН НОВЫЙ КРУГ: ");
            Round_GetInfo(round);
        }
        static void Round_GetParams(out int x, out int y, out int radius)
        {
            Console.Write($"{Environment.NewLine}Введите координаты центра и радиус для круга: {Environment.NewLine}X = ");
            x = ReadNumberFromConsole();
            Console.Write("Y = ");
            y = ReadNumberFromConsole();
            Console.Write("r = ");
            radius = ReadNumberFromConsole();
        }

    }
}

class Round
{
    public Round()
    {
        X = 0;
        Y = 0;
        Radius = 1;
    }

    public Round(int x, int y, int radius)
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
        get { return _radius; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Radius should be more than zero", nameof(value));

            _radius = value;
        }
    }

    public double Length => 2 * Math.PI * Radius;
    public double Area => Math.PI * Radius * Radius;

}



