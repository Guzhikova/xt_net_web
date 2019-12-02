using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Game
{
    abstract class Obstacle: IImmovable
    {
        public Point Coordinate => throw new NotImplementedException();

        public double Width => throw new NotImplementedException();

        public double Height => throw new NotImplementedException();

        /// <summary>
        /// Урон, который нанесется игроку, если он соприкоснется с объектом
        /// </summary>
        public int Damage { get; }
    }
}
