using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_7
{
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
