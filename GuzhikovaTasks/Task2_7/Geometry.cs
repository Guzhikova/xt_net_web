using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_7
{
    abstract class Geometry
    {
        public abstract Point Point { get; set; }
        public abstract double Length { get; }
    }
}
