using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Game
{
    class Player : IMovable
    {
        public double Speed => throw new NotImplementedException();

        public void MovementAlgorithm()
        {
            throw new NotImplementedException();
        }

        public int Health { get; set; }

        public Bonus CollectedBonuses { get; set; }
    }
}
