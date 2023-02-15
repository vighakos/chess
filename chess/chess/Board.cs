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
        public Cella[,] Map;
        public int[,] iMap;

        public Board()
        {
            /*
                0 - empty
                1 - pawn
                2 - bishop
                3 - knight
                4 - rook
                5 - queen
                6 - king
            */
            iMap = new int[, ] {
                {4, 3, 2, 5, 6, 2, 3, 4}, 
                {1, 1, 1, 1, 1, 1, 1, 1},
                {0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0},
                {1, 1, 1, 1, 1, 1, 1, 1},
                {4, 3, 2, 5, 6, 2, 3, 4}
            };
        }

        public Image GetPiece(int x)
        {
            switch (x)
            {
                case 1:
                    return Properties.Resources.pawn;
                case 2:
                    return Properties.Resources.bishop;
                case 3:
                    return Properties.Resources.knight;
                case 4:
                    return Properties.Resources.rook;
                case 5:
                    return Properties.Resources.queen;
                case 6:
                    return Properties.Resources.king;
                case 0:
                default:
                    return null;
            }
        }
    }
}
