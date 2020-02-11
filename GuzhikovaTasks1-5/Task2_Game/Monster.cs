using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Game
{
    abstract class Monster : IMovable
    {
        public Point BaseCoordinate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public double Speed => throw new NotImplementedException();

        /// <summary>
        /// Урон, наносящийся здоровью игроку, при их [игрока и монстра] пересечнии
        /// </summary>
        public int Damage { get; }


        public virtual void MovementAlgorithm()
        {
            throw new NotImplementedException();
        }
    }
}
