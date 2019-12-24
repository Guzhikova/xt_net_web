using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Encapsulation
{
    internal class Round
    {
        private int _radius;
        public Round(int x = 0, int y = 0, int radius = 1)
        {
            X = x;
            Y = y;
            Radius = radius;
        }

        public int X { get; set; }
        public int Y { get; set; }

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

        public void GetInfo()
        {
            string info = String.Format("Центр ({0}, {1}). Радиус {2}. Длина описанной окружности {3}. Площадь круга {4}.",
          X, Y, Radius, Length.ToString("0.0"), Area.ToString("0.0"));

            Console.WriteLine(info);
        }
    }

}
