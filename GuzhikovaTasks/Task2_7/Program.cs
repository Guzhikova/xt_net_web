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

            Console.WriteLine($"----------------------Task 2.7. VECTOR GRAPHICS EDITOR----------------------{Environment.NewLine}");

            Line line = new Line(new Point(0, 2), new Point(0, 0));
            Console.WriteLine(line.ToString());

            line.Point2 = new Point(0, 0);
            Console.WriteLine(line.ToString());

            Console.ReadKey();
        }

        public static void CreateRings()
        {
            try
            {
                Ring ring1 = new Ring(new Point { X = 0, Y = 5 }, 10, 2);
                Console.WriteLine($"   КОЛЬЦО №1:{Environment.NewLine}{ring1.ToString()}");

                Ring ring2 = new Ring();
                ring2.Center = new Point(10, 15);
                ring2.Radius = 22;
                ring2.InnerRadius = 8;

                Console.WriteLine($"{Environment.NewLine}   КОЛЬЦО №2:{Environment.NewLine}{ring2.ToString()}");
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
    }
}
