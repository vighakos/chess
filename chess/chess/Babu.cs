using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class Babu
    {
        public string Color;
        public string Name;
        public List<Cella> Lepesek;

        public Babu(string color, string name)
        {
            Color = color;
            Name = name;
            Lepesek = new List<Cella>();
        }
    }
}
