using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_7
{
    class Rectangle : Geometry
    {

        /// <param name="point">The top left point of rectangle</param>
        /// <param name="sideA">The side A of rectangle</param>
        /// <param name="sideB">The side B of rectangle</param>
        public Rectangle(Point point, int a, int b)
        {
            if (a == 0 || b==0)
                throw new ArgumentException("ERROR! The sides must be more than zero");

            TopLeftPoint = point;
            _sideA = a;
            _sideB = b;

        }


        /// <summary>
        /// The coordinates of top left point
        /// </summary>
        public Point TopLeftPoint { get; set; }

        private int _sideA, _sideB;

        public int SideA
        {
            get => _sideA;
            set
            {
                if (value == 0)
                    throw new ArgumentException("ERROR! The side must be more than zero", "SideA");
                _sideA = value;
            }
        }
        public int SideB
        {
            get => _sideB;
            set
            {
                if (value == 0)
                    throw new ArgumentException("ERROR! The side must be more than zero", "SideB");
                _sideB = value;
            }
        }


        public  double Perimeter { get => 2 * (SideA + SideB); }

        public double Area { get => SideA * SideB; }

        public override string ToString()
        {
            return String.Format($"ПРЯМОУГОЛЬНИК с координатой верхнего левого угла ({TopLeftPoint.X}, {TopLeftPoint.Y})" +
                $"{Environment.NewLine}Сторона А = {SideA}, B = {SideB}." +
                $"{Environment.NewLine}Периметр Р = {Perimeter.ToString("0.0")}." +
                $"{Environment.NewLine}Площадь S = {Area.ToString("0.0")}");
        }

    }
}
