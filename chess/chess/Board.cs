using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chess
{
    class Board
    {
        public int[,] Map;

        public Board()
        {
            Map = null;
        }

        public void GenerateMap()
        {
            Map = new int[8, 8];
        }
    }
}
