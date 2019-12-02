using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Game
{
    abstract class Monster : IMovable
    {
        /// <summary>
        /// Урон, наносящийся здоровью игроку, при их [игрока и монстра] пересечнии
        /// </summary>
        public int Damage { get; }
        double Speed { get => throw new NotImplementedException();  }

        double IMovable.Speed => throw new NotImplementedException();

        public void MovementAlgorithm()
        {
            throw new NotImplementedException();
        }
    }
}
