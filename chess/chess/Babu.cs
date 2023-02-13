using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public string GetPiece()
        {
            return $"{Color.ToLower()}_{Name.ToLower()}";
        }
    }
}
