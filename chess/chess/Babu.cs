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
        public string Color, Piece;
        public List<Cella> Lepesek;
        public bool ElsoLepes;

        public Babu(string color, string piece)
        {
            Color = color;
            Piece = piece;
            Lepesek = new List<Cella>();
            ElsoLepes = true;
        }

        public Image GetImage()
        {
            switch ($"{Color}_{Piece}")
            {
                case "white_pawn":
                    return Properties.Resources.white_pawn;
                case "white_bishop":
                    return Properties.Resources.white_bishop;
                case "white_knight":
                    return Properties.Resources.white_knight;
                case "white_rook":
                    return Properties.Resources.white_rook;
                case "white_queen":
                    return Properties.Resources.white_queen;
                case "white_king":
                    return Properties.Resources.white_king;

                case "black_pawn":
                    return Properties.Resources.black_pawn;
                case "black_bishop":
                    return Properties.Resources.black_bishop;
                case "black_knight":
                    return Properties.Resources.black_knight;
                case "black_rook":
                    return Properties.Resources.black_rook;
                case "black_queen":
                    return Properties.Resources.black_queen;
                case "black_king":
                    return Properties.Resources.black_king;

                default:
                    return null;
            }
        }
    }
}
