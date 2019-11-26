using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Encapsulation
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ReadKey();
        }
    }

    class Round
    {
        public Round()
        {
            _centerX = 0;
            _centerY = 0;
            _radius = 1;
        }

        public Round(double x, double y, double r)
        {

        }

        private double _centerX, _centerY, _radius;
        public int Length { get; set; }
        public int Area { get; set; }

    }
}
