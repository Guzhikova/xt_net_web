using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_7
{
    class Rectangle
    {
        public Rectangle()
        { }

        public Rectangle(Point point, int sideA, int sideB)
        {
            UpperLeftPoint = point;
            SideA = sideA;
            SideB = SideB;
        }


        public Point UpperLeftPoint { get; set; }

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

        public double Perimeter { get => 2 * (SideA + SideB); }


    }
}
