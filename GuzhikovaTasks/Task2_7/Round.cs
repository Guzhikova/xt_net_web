using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_7
{
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
}
