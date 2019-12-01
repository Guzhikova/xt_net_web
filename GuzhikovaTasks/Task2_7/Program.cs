using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_7
{

    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine($"----------------------Task 2.6. RING----------------------{Environment.NewLine}");
            //CreateRings();

            //Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}* * * Для перехода к следующему заданию нажмите любую клавишу * * *");
            //Console.ReadKey();

            Console.WriteLine($"----------------------Task 2.7. VECTOR GRAPHICS EDITOR----------------------");

            FigureChoosing();


            Console.ReadKey();
        }


        public static void CreateAndChangeRing()
        {
            try
            {
                Ring ring1 = new Ring(new Point { X = 0, Y = 5 }, 10, 2);
                Console.WriteLine($"   Исходное кольцо:{Environment.NewLine}{ring1.ToString()}");

                ring1.Center = new Point(10, 15);
                ring1.Radius = 22;
                ring1.InnerRadius = 8;

                Console.WriteLine($"{Environment.NewLine}   Измененное кольцо:{Environment.NewLine}{ring1.ToString()}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(Environment.NewLine + ex.Message);
            }
            catch (Exception ex)

            {
                Console.WriteLine(ex.Message);
            }
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

        public static void FigureChoosing()
        {
            int number;
            do
            {
                Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}   Выберите тип фигуры:{Environment.NewLine}   1: Отрезок" +
                    $"{Environment.NewLine}   2: Прямоугольник" +
                    $"{Environment.NewLine}   3: Окружность" +
                    $"{Environment.NewLine}   4: Круг" +
                    $"{Environment.NewLine}   5: Кольцо" +
                    $"{Environment.NewLine}   Любое другое значение: Выход{Environment.NewLine}");

                number = ReadNumberFromConsole();

                switch (number)
                {
                    case 1:
                        FigureChoosing_CreateLine();
                        break;
                    case 2:
                        FigureChoosing_CreateRectangle();
                        break;
                    case 3:
                        FigureChoosing_CreateCircle();
                        break;
                    case 4:
                        FigureChoosing_CreateRound();
                        break;
                    case 5:
                        FigureChoosing_CreateRing();
                        break;

                    default:
                        break;
                }

            } while (number == 1 || number == 2 || number == 3 || number == 4 || number == 5);
        }

        public static void FigureChoosing_CreateLine()
        {
            try
            {
                Point point1 = new Point(ReadParameter("X1"), ReadParameter("Y1"));
                Point point2 = new Point(ReadParameter("X2"), ReadParameter("Y2"));

                Line line = new Line(point1, point2);

                Console.WriteLine(Environment.NewLine + line.ToString());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void FigureChoosing_CreateRectangle()
        {
            try
            {
                int x = ReadParameter("координата левого верхнего угла X");
                int y = ReadParameter("координата левого верхнего угла Y");

                Point point = new Point(x, y);

                int a = ReadParameter("сторона А");
                int b = ReadParameter("сторона B");

                Rectangle rectangle = new Rectangle(point, a, b);
                Console.WriteLine(Environment.NewLine + rectangle.ToString());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void FigureChoosing_CreateCircle()
        {
            int x, y, radius;
            FigureChoosing_GetCircleParameters(out x, out y, out radius);

            try
            {
                Circle сircle = new Circle(new Point(x, y), radius);

                Console.WriteLine(Environment.NewLine + сircle.ToString());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void FigureChoosing_CreateRound()
        {
            int x, y, radius;
            FigureChoosing_GetCircleParameters(out x, out y, out radius);

            try
            {
                Round round = new Round(new Point(x, y), radius);
                Console.WriteLine(Environment.NewLine + round.ToString());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void FigureChoosing_CreateRing()
        {
            int x, y, radius, innerRadius;
            FigureChoosing_GetCircleParameters(out x, out y, out radius);

            innerRadius = ReadParameter("внутренний радиус r");

            try
            {
               Ring ring = new Ring(new Point(x, y), radius, innerRadius);

                Console.WriteLine(Environment.NewLine + ring.ToString());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void FigureChoosing_GetCircleParameters(out int x, out int y, out int radius)
        {
            x = ReadParameter("координата центра X");
            y = ReadParameter("координата центра Y");
            radius = ReadParameter("радиус");
        }


        /// <param name="parameter">The name of  parameter</param>
        public static int ReadParameter(string parameter)
        {
            Console.Write($"Введите параметр: {parameter} = ");
            return ReadNumberFromConsole();
        }

    }

    public struct Point
    {
        public int X, Y;
        public Point(int p1, int p2)
        {
            X = p1;
            Y = p2;
        }

        public static bool operator ==(Point point1, Point point2)
        {
            return (point1.X == point2.X) && (point1.Y == point2.Y);

        }

        public static bool operator !=(Point point1, Point point2)
        {
            return !(point1 == point2);
        }

        public override bool Equals(object otherPoint)
        {
            if (!(otherPoint is Point))
                return false;

            return this == (Point)otherPoint;
        }
        public override int GetHashCode()
        {
            return this.GetHashCode(); // ???
        }
    }
}
