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

        //Replenishment... -  величина, на которую увеличивается характеристика (здоровье, скорость)
        //при взятии бонуса

        public int ReplenishmentHealth { get; }
        public int ReplenishmentSpeed { get; }
    }
}
