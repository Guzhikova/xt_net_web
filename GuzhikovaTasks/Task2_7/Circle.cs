using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_7
{
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

         public override string ToString()
        {
            return String.Format($"Окружность с центром в точке ({Center.X}, {Center.Y})." +
                $"{Environment.NewLine}Радиус R = {Radius}." +
                $"{Environment.NewLine}Длина окружности L = {Length.ToString("0.0")}. ");
        }
    }
}
