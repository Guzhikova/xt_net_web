using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Encapsulation
{

    internal class Triangle
    {
        public Triangle()
        {
            A = 1;
            B = 1;
            C = 1;
        }

        public Triangle(int a, int b, int c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentException("Error! The side of triangle should be more than zero.");

            if (a > (b + c) || b > (a + c) || c > (a + b))
                throw new ArithmeticException("Error! The side of triangle can't be greater than sum of other 2 sides.");

            A = a;
            B = b;
            C = c;
        }

        public int A { get; }
        public int B { get; }
        public int C { get; }

        public int GetPerimeter()
        {
            return A + B + C;
        }

        public double GetArea()
        {
            double p = (double)GetPerimeter() / 2;

            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }
    }
}
