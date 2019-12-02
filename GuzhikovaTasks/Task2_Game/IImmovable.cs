using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Game
{
    interface IImmovable
    {
       Point Coordinate { get; }
       double Width { get; }
       double Height { get; }
       
    }
}
