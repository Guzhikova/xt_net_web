using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Ring
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"----------------------Task 2.6. RING----------------------{Environment.NewLine}");

            CreateRings();

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
    }

    class Circle
    {
        public Circle()
        { }

        public Circle(Point point, int radius)
        {
            Center = point;
            Radius = radius;
        }

        public Point Center { get; set; }

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

        public virtual double Length { get => 2 * Math.PI * Radius; }

    }

    class Round : Circle
    {
        public Round() : base()
        { }

        public Round(Point point, int radius) : base(point, radius)
        {
            Center = point;
            Radius = radius;
        }

        public virtual double Area { get => Math.PI * Radius * Radius; }
    }

    class Ring : Round
    {
        public Ring() : base()
        { }

        public Ring(Point point, int outerRadius, int innerRadius) : base(point, outerRadius)
        {
            Center = point;
            Radius = outerRadius;
            InnerRadius = innerRadius;
        }

        private int _innerRadius;
        public int InnerRadius
        {
            get => _innerRadius;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("ERROR! Radius should be more than zero");

                if (value >= Radius)
                    throw new ArgumentException("ERROR! Inner radius should be less than outer radius", "InnerRadius");

                _innerRadius = value;
            }
        }

        public override double Length => base.Length + (2 * Math.PI * InnerRadius);

        public override double Area => base.Area - Math.PI * InnerRadius * InnerRadius;

        public override string ToString()
        {
            return String.Format($"Кольцо с центром в точке ({Center.X}, {Center.Y})." +
                $"{Environment.NewLine}Внешний радиус R = {Radius}, внутренний радиус r = {InnerRadius}." +
                $"{Environment.NewLine}Суммарная длина внешней и внутренней окружностей L = {Length.ToString("0.0")}. " +
                $"{Environment.NewLine}Площадь S = {Area.ToString("0.0")}");
        }

    }
}
