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
            Map = new Cella[8, 8];
        }

        public void Lepesek(Cella cella)
        {
            cella._Babu.Lepesek.Clear();

            switch (cella._Babu.Piece)
            {
                case "pawn":
                    {
                        if (cella._Babu.Color == "white")
                        {
                            if (cella._Babu.ElsoLepes)
                            {
                                if (Map[cella.Sor - 1, cella.Oszlop]._Babu == null)
                                {
                                    cella._Babu.Lepesek.Add(Map[cella.Sor - 1, cella.Oszlop]);
                                    if (Map[cella.Sor - 2, cella.Oszlop]._Babu == null)
                                        cella._Babu.Lepesek.Add(Map[cella.Sor - 2, cella.Oszlop]);
                                }
                            }
                            else if (cella.Sor - 1 >= 0)
                            {
                                if (Map[cella.Sor - 1, cella.Oszlop]._Babu == null)
                                    cella._Babu.Lepesek.Add(Map[cella.Sor - 1, cella.Oszlop]);
                            }
                        }
                        else
                        {
                            if (cella._Babu.ElsoLepes)
                            {
                                if (Map[cella.Sor + 1, cella.Oszlop]._Babu == null)
                                {
                                    cella._Babu.Lepesek.Add(Map[cella.Sor + 1, cella.Oszlop]);
                                    if (Map[cella.Sor + 2, cella.Oszlop]._Babu == null)
                                        cella._Babu.Lepesek.Add(Map[cella.Sor + 2, cella.Oszlop]);
                                }
                            }
                            else if (cella.Sor + 1 < 8)
                            {
                                if (Map[cella.Sor + 1, cella.Oszlop]._Babu == null)
                                    cella._Babu.Lepesek.Add(Map[cella.Sor + 1, cella.Oszlop]);
                            }
                        }
                        
                        break;
                    }

            }

            foreach (Cella item in cella._Babu.Lepesek) item.Pbox.BackColor = Color.LawnGreen;
        }

        public string GetPiece(int x)
        {
            switch (x)
            {
                case 1:
                    return "pawn";
                case 2:
                    return "bishop";
                case 3:
                    return "knight";
                case 4:
                    return "rook";
                case 5:
                    return "queen";
                case 6:
                    return "king";
                case 0:
                default:
                    return null;
            }
        }
    }
}
