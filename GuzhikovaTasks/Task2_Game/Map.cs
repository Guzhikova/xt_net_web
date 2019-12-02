using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Game
{
    class Map
    {
        public Map(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double Width { get;}
        public double Height { get;}

        public List<Obstacle> Obstacles { get; set; }
        public List<Bonus> Bonuses { get; set; }
        public List<Monster> Monsters { get; set; }

        public Player Player { get; set; }

    }
}
