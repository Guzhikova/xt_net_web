using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Game
{
    class Player : IMovable
    {
        public Point BaseCoordinate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public double Speed => throw new NotImplementedException();

        public int Health { get; set; }

        public Bonus CollectedBonuses { get; set; }

        public void MovementAlgorithm()
        {
            throw new NotImplementedException();
        }
    }
}
