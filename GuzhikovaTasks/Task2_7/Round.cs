using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_7
{
    class Round : Circle
    {

        public Round(Point point, int radius) : base(point, radius)
        {
            Point = point;
            Radius = radius;
        }

        public virtual double Area { get => Math.PI * Radius * Radius; }

        public override string ToString()
        {
            return String.Format($"КРУГ с центром в точке ({Point.X}, {Point.Y})." +
                $"{Environment.NewLine}Радиус R = {Radius}." +
                $"{Environment.NewLine}Длина описанной окружности L = {Length.ToString("0.0")}. " +
                $"{Environment.NewLine}Площадь S = {Area.ToString("0.0")}");
        }
    }
}
