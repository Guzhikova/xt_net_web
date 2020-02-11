using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Game
{
    interface IMovable
    {
        Point BaseCoordinate { get; set; }
        double Speed { get; }
        void MovementAlgorithm();
    }
}
