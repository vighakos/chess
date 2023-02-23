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
                case "bishop":
                    {
                        /*
                        for (int sor = cella.Sor - 1; sor >= 0; sor--)
                        {
                            if (sor < 0 || cella.Oszlop - sor < 0) break;
                            if (Map[sor, cella.Oszlop - sor]._Babu == null)
                            {
                                cella._Babu.Lepesek.Add(Map[sor, cella.Oszlop - sor]);
                            }
                            else break;
                        }
                        */
                        break;
                    }

                case "knight":
                    {
                        if (cella.Sor + 2 < 7 && cella.Oszlop - 1 >= 0 && Map[cella.Sor + 2, cella.Oszlop - 1]._Babu == null)
                            cella._Babu.Lepesek.Add(Map[cella.Sor + 2, cella.Oszlop - 1]);

                        if (cella.Sor + 2 < 7 && cella.Oszlop + 1 < 7 && Map[cella.Sor + 2, cella.Oszlop + 1]._Babu == null)
                            cella._Babu.Lepesek.Add(Map[cella.Sor + 2, cella.Oszlop + 1]);

                        if (cella.Sor - 2 >= 0 && cella.Oszlop - 1 >= 0 && Map[cella.Sor - 2, cella.Oszlop - 1]._Babu == null)
                            cella._Babu.Lepesek.Add(Map[cella.Sor - 2, cella.Oszlop - 1]);

                        if (cella.Sor - 2 >= 0 && cella.Oszlop + 1 < 8 && Map[cella.Sor - 2, cella.Oszlop + 1]._Babu == null)
                            cella._Babu.Lepesek.Add(Map[cella.Sor - 2, cella.Oszlop + 1]);


                        if (cella.Sor - 1 >= 0 && cella.Oszlop + 2 < 8 && Map[cella.Sor - 1, cella.Oszlop + 2]._Babu == null)
                            cella._Babu.Lepesek.Add(Map[cella.Sor - 1, cella.Oszlop + 2]);

                        if (cella.Sor - 1 >= 0 && cella.Oszlop - 2 >= 0 && Map[cella.Sor - 1, cella.Oszlop - 2]._Babu == null)
                            cella._Babu.Lepesek.Add(Map[cella.Sor - 1, cella.Oszlop - 2]);

                        if (cella.Sor + 1 < 8 && cella.Oszlop + 2 < 8 && Map[cella.Sor + 1, cella.Oszlop + 2]._Babu == null)
                            cella._Babu.Lepesek.Add(Map[cella.Sor + 1, cella.Oszlop + 2]);

                        if (cella.Sor + 1 < 8 && cella.Oszlop - 2 < 8 && Map[cella.Sor + 1, cella.Oszlop - 2]._Babu == null)
                            cella._Babu.Lepesek.Add(Map[cella.Sor + 1, cella.Oszlop - 2]);

                        break;
                    }

                case "rook":
                    {

                        for (int i = cella.Sor + 1; i < 8; i++)
                        {
                            if (Map[i, cella.Oszlop]._Babu == null)
                            {
                                cella._Babu.Lepesek.Add(Map[i, cella.Oszlop]);
                            }
                            else if (Map[i, cella.Oszlop]._Babu.Color != cella._Babu.Color)
                            {
                                cella._Babu.Lepesek.Add(Map[i, cella.Oszlop]);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int i = cella.Sor - 1; i >= 0; i--)
                        {
                            if (Map[i, cella.Oszlop]._Babu == null)
                            {
                                cella._Babu.Lepesek.Add(Map[i, cella.Oszlop]);
                            }
                            else if (Map[i, cella.Oszlop]._Babu.Color != cella._Babu.Color)
                            {
                                cella._Babu.Lepesek.Add(Map[i, cella.Oszlop]);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int j = cella.Oszlop + 1; j < 8; j++)
                        {
                            if (Map[cella.Sor, j]._Babu == null)
                            {
                                cella._Babu.Lepesek.Add(Map[cella.Sor, j]);
                            }
                            else if (Map[cella.Sor, j]._Babu.Color != cella._Babu.Color)
                            {
                                cella._Babu.Lepesek.Add(Map[cella.Sor, j]);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int j = cella.Oszlop - 1; j >= 0; j--)
                        {
                            if (Map[cella.Sor, j]._Babu == null)
                            {
                                cella._Babu.Lepesek.Add(Map[cella.Sor, j]);
                            }
                            else if (Map[cella.Sor, j]._Babu.Color != cella._Babu.Color)
                            {
                                cella._Babu.Lepesek.Add(Map[cella.Sor, j]);
                                break;
                            }
                            else
                            {
                                break;
                            }


                            
                        }break;
                    }

                case "queen":
                    {

                        break;
                    }

                case "king":
                    {
                        if (cella.Sor + 1 < 8 && Map[cella.Sor + 1, cella.Oszlop]._Babu == null)
                            cella._Babu.Lepesek.Add(Map[cella.Sor + 1, cella.Oszlop]);

                        if (cella.Sor + 1 < 8 && cella.Oszlop + 1 < 8 && Map[cella.Sor + 1, cella.Oszlop + 1]._Babu == null)
                            cella._Babu.Lepesek.Add(Map[cella.Sor + 1, cella.Oszlop + 1]);

                        if (cella.Oszlop + 1 < 8 && Map[cella.Sor, cella.Oszlop + 1]._Babu == null)
                            cella._Babu.Lepesek.Add(Map[cella.Sor, cella.Oszlop + 1]);

                        if (cella.Sor - 1 >= 0 && cella.Oszlop + 1 < 8 && Map[cella.Sor - 1, cella.Oszlop + 1]._Babu == null)
                            cella._Babu.Lepesek.Add(Map[cella.Sor - 1, cella.Oszlop + 1]);

                        if (cella.Sor - 1 >= 0 && Map[cella.Sor - 1, cella.Oszlop]._Babu == null)
                            cella._Babu.Lepesek.Add(Map[cella.Sor - 1, cella.Oszlop]);

                        if (cella.Sor - 1 >= 0 && cella.Oszlop - 1 >= 0 && Map[cella.Sor - 1, cella.Oszlop - 1]._Babu == null)
                            cella._Babu.Lepesek.Add(Map[cella.Sor - 1, cella.Oszlop - 1]);

                        if (cella.Oszlop - 1 >= 0 && Map[cella.Sor, cella.Oszlop - 1]._Babu == null)
                            cella._Babu.Lepesek.Add(Map[cella.Sor, cella.Oszlop - 1]);

                        if (cella.Sor + 1 < 8 && cella.Oszlop - 1 >= 0 && Map[cella.Sor + 1, cella.Oszlop - 1]._Babu == null)
                            cella._Babu.Lepesek.Add(Map[cella.Sor + 1, cella.Oszlop - 1]);
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
