using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_7
{
    class Ring : Round
    {

        public Ring(Point point, int outerRadius, int innerRadius) : base(point, outerRadius)
        {
            Point = point;
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
            return String.Format($"КОЛЬЦО с центром в точке ({Point.X}, {Point.Y})." +
                $"{Environment.NewLine}Внешний радиус R = {Radius}, внутренний радиус r = {InnerRadius}." +
                $"{Environment.NewLine}Суммарная длина внешней и внутренней окружностей L = {Length.ToString("0.0")}. " +
                $"{Environment.NewLine}Площадь S = {Area.ToString("0.0")}");
        }
    }
}
