using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class Player
    {
        public string Color;
        public List<Babu> Babus;

        public Player(string color)
        {
            Color = color;
            Babus = new List<Babu>();
        }
    }
}
