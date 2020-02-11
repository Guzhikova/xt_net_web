using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Game
{
    abstract class Bonus : IImmovable
    {
        public Point Coordinate => throw new NotImplementedException();

        public double Width => throw new NotImplementedException();

        public double Height => throw new NotImplementedException();

        /// <summary>
        /// Величина, на которую увеличивается здоровье при взятии бонуса
        /// </summary>
  
        public int ReplenishmentHealth { get; }

        /// <summary>
        /// Величина, на которую увеличивается скорость при взятии бонуса
        /// </summary>
        public int ReplenishmentSpeed { get; }
    }
}
