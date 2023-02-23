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
                            
                            if (cella.Sor - 1 >= 0 && cella.Oszlop - 1 >= 0)
                            {
                                if (Map[cella.Sor - 1, cella.Oszlop - 1]._Babu != null && Map[cella.Sor - 1, cella.Oszlop - 1]._Babu.Color != cella._Babu.Color)
                                {
                                    cella._Babu.Lepesek.Add(Map[cella.Sor - 1, cella.Oszlop - 1]);
                                }
                            }
                            if (cella.Sor - 1 >= 0 && cella.Oszlop + 1 < 8)
                            {
                                if (Map[cella.Sor - 1, cella.Oszlop + 1]._Babu != null && Map[cella.Sor - 1, cella.Oszlop + 1]._Babu.Color != cella._Babu.Color)
                                {
                                    cella._Babu.Lepesek.Add(Map[cella.Sor - 1, cella.Oszlop + 1]);
                                }
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

                            if (cella.Sor + 1 < 8 && cella.Oszlop - 1 >= 0)
                            {
                                if (Map[cella.Sor + 1, cella.Oszlop - 1]._Babu != null && Map[cella.Sor + 1, cella.Oszlop - 1]._Babu.Color != cella._Babu.Color)
                                {
                                    cella._Babu.Lepesek.Add(Map[cella.Sor + 1, cella.Oszlop - 1]);
                                }
                            }
                            if (cella.Sor + 1 < 8 && cella.Oszlop + 1 < 8)
                            {
                                if (Map[cella.Sor + 1, cella.Oszlop + 1]._Babu != null && Map[cella.Sor + 1, cella.Oszlop + 1]._Babu.Color != cella._Babu.Color)
                                {
                                    cella._Babu.Lepesek.Add(Map[cella.Sor + 1, cella.Oszlop + 1]);
                                }
                            }
                        }
                        
                        break;
                    }

                case "bishop":
                    {
                        for (int i = 1; i < 8; i++)
                        {
                            if (cella.Sor - i >= 0 && cella.Oszlop - i >= 0)
                            {
                                if (Map[cella.Sor - i, cella.Oszlop - i]._Babu == null)
                                    cella._Babu.Lepesek.Add(Map[cella.Sor - i, cella.Oszlop - i]);
                                else if (Map[cella.Sor - i, cella.Oszlop - i]._Babu.Color == cella._Babu.Color) break;
                                else if (Map[cella.Sor - i, cella.Oszlop - i]._Babu.Color != cella._Babu.Color)
                                {
                                    cella._Babu.Lepesek.Add(Map[cella.Sor - i, cella.Oszlop - i]);
                                    break;
                                }
                            }
                        }

                        for (int i = 1; i < 8; i++)
                        {
                            if (cella.Sor - i >= 0 && cella.Oszlop + i < 8)
                            {
                                if (Map[cella.Sor - i, cella.Oszlop + i]._Babu == null)
                                    cella._Babu.Lepesek.Add(Map[cella.Sor - i, cella.Oszlop + i]);
                                else if (Map[cella.Sor - i, cella.Oszlop + i]._Babu.Color == cella._Babu.Color) break;
                                else if (Map[cella.Sor - i, cella.Oszlop + i]._Babu.Color != cella._Babu.Color)
                                {
                                    cella._Babu.Lepesek.Add(Map[cella.Sor - i, cella.Oszlop + i]);
                                    break;
                                }
                            }
                        }

                        for (int i = 1; i < 8; i++)
                        {
                            if (cella.Sor + i < 8 && cella.Oszlop + i < 8)
                            {
                                if (Map[cella.Sor + i, cella.Oszlop + i]._Babu == null)
                                    cella._Babu.Lepesek.Add(Map[cella.Sor + i, cella.Oszlop + i]);
                                else if (Map[cella.Sor + i, cella.Oszlop + i]._Babu.Color == cella._Babu.Color) break;
                                else if (Map[cella.Sor + i, cella.Oszlop + i]._Babu.Color != cella._Babu.Color)
                                {
                                    cella._Babu.Lepesek.Add(Map[cella.Sor + i, cella.Oszlop + i]);
                                    break;
                                }
                            }
                        }

                        for (int i = 1; i < 8; i++)
                        {
                            if (cella.Sor + i < 8 && cella.Oszlop - i >= 0)
                            {
                                if (Map[cella.Sor + i, cella.Oszlop - i]._Babu == null)
                                    cella._Babu.Lepesek.Add(Map[cella.Sor + i, cella.Oszlop - i]);
                                else if (Map[cella.Sor + i, cella.Oszlop - i]._Babu.Color == cella._Babu.Color) break;
                                else if (Map[cella.Sor + i, cella.Oszlop - i]._Babu.Color != cella._Babu.Color)
                                {
                                    cella._Babu.Lepesek.Add(Map[cella.Sor + i, cella.Oszlop - i]);
                                    break;
                                }
                            }
                        }

                        break;
                    }

                case "knight":
                    {
                        if (cella.Sor + 2 < 8  && cella.Oszlop - 1 >= 0)
                            cella._Babu.Lepesek.Add(Map[cella.Sor + 2, cella.Oszlop - 1]);

                        if (cella.Sor + 2 < 8  && cella.Oszlop + 1 < 8)
                            cella._Babu.Lepesek.Add(Map[cella.Sor + 2, cella.Oszlop + 1]);

                        if (cella.Sor - 2 >= 0  && cella.Oszlop - 1 >= 0)
                            cella._Babu.Lepesek.Add(Map[cella.Sor - 2, cella.Oszlop - 1]);

                        if (cella.Sor - 2 >= 0 && cella.Oszlop + 1 < 8)
                            cella._Babu.Lepesek.Add(Map[cella.Sor - 2, cella.Oszlop + 1]);


                        if (cella.Sor - 1 >= 0 && cella.Oszlop + 2 < 8)
                            cella._Babu.Lepesek.Add(Map[cella.Sor - 1, cella.Oszlop + 2]);

                        if (cella.Sor - 1 >= 0 && cella.Oszlop - 2 >= 0)
                            cella._Babu.Lepesek.Add(Map[cella.Sor - 1, cella.Oszlop - 2]);

                        if (cella.Sor + 1 < 8 && cella.Oszlop + 2 < 8)
                            cella._Babu.Lepesek.Add(Map[cella.Sor + 1, cella.Oszlop + 2]);

                        if (cella.Sor + 1 < 8 && cella.Oszlop - 2 < 8)
                            cella._Babu.Lepesek.Add(Map[cella.Sor + 1, cella.Oszlop - 2]);

                        break;
                    }

                case "rook":
                    {
                        for (int sor = cella.Sor + 1; sor < 8; sor++)
                        {
                            if (sor > 7) break;

                            if (Map[sor, cella.Oszlop]._Babu == null)
                                cella._Babu.Lepesek.Add(Map[sor, cella.Oszlop]);
                            else if (Map[sor, cella.Oszlop]._Babu.Color == cella._Babu.Color) break;
                            else if (Map[sor, cella.Oszlop]._Babu.Color != cella._Babu.Color)
                            {
                                cella._Babu.Lepesek.Add(Map[sor, cella.Oszlop]);
                                break;
                            }
                        }

                        for (int sor = cella.Sor - 1; sor >= 0; sor--)
                        {
                            if (sor < 0) break;

                            if (Map[sor, cella.Oszlop]._Babu == null)
                                cella._Babu.Lepesek.Add(Map[sor, cella.Oszlop]);
                            else if (Map[sor, cella.Oszlop]._Babu.Color == cella._Babu.Color) break;
                            else if (Map[sor, cella.Oszlop]._Babu.Color != cella._Babu.Color)
                            {
                                cella._Babu.Lepesek.Add(Map[sor, cella.Oszlop]);
                                break;
                            }
                        }

                        for (int oszlop = cella.Oszlop + 1; oszlop < 8; oszlop++)
                        {
                            if (oszlop > 7) break;

                            if (Map[cella.Sor, oszlop]._Babu == null)
                                cella._Babu.Lepesek.Add(Map[cella.Sor, oszlop]);
                            else if (Map[cella.Sor, oszlop]._Babu.Color == cella._Babu.Color) break;
                            else if (Map[cella.Sor, oszlop]._Babu.Color != cella._Babu.Color)
                            {
                                cella._Babu.Lepesek.Add(Map[cella.Sor, oszlop]);
                                break;
                            }
                        }

                        for (int oszlop = cella.Oszlop - 1; oszlop >= 0; oszlop--)
                        {
                            if (oszlop < 0) break;

                            if (Map[cella.Sor, oszlop]._Babu == null)
                                cella._Babu.Lepesek.Add(Map[cella.Sor, oszlop]);
                            else if (Map[cella.Sor, oszlop]._Babu.Color == cella._Babu.Color) break;
                            else if (Map[cella.Sor, oszlop]._Babu.Color != cella._Babu.Color)
                            {
                                cella._Babu.Lepesek.Add(Map[cella.Sor, oszlop]);
                                break;
                            }
                        }

                        break;
                    }

                case "queen":
                    {
                        for (int i = 1; i < 8; i++)
                        {
                            if (cella.Sor - i >= 0 && cella.Oszlop - i >= 0)
                            {
                                if (Map[cella.Sor - i, cella.Oszlop - i]._Babu == null)
                                    cella._Babu.Lepesek.Add(Map[cella.Sor - i, cella.Oszlop - i]);
                                else if (Map[cella.Sor - i, cella.Oszlop - i]._Babu.Color == cella._Babu.Color) break;
                                else if (Map[cella.Sor - i, cella.Oszlop - i]._Babu.Color != cella._Babu.Color)
                                {
                                    cella._Babu.Lepesek.Add(Map[cella.Sor - i, cella.Oszlop - i]);
                                    break;
                                }
                            }
                        }

                        for (int i = 1; i < 8; i++)
                        {
                            if (cella.Sor - i >= 0 && cella.Oszlop + i < 8)
                            {
                                if (Map[cella.Sor - i, cella.Oszlop + i]._Babu == null)
                                    cella._Babu.Lepesek.Add(Map[cella.Sor - i, cella.Oszlop + i]);
                                else if (Map[cella.Sor - i, cella.Oszlop + i]._Babu.Color == cella._Babu.Color) break;
                                else if (Map[cella.Sor - i, cella.Oszlop + i]._Babu.Color != cella._Babu.Color)
                                {
                                    cella._Babu.Lepesek.Add(Map[cella.Sor - i, cella.Oszlop + i]);
                                    break;
                                }
                            }
                        }

                        for (int i = 1; i < 8; i++)
                        {
                            if (cella.Sor + i < 8 && cella.Oszlop + i < 8)
                            {
                                if (Map[cella.Sor + i, cella.Oszlop + i]._Babu == null)
                                    cella._Babu.Lepesek.Add(Map[cella.Sor + i, cella.Oszlop + i]);
                                else if (Map[cella.Sor + i, cella.Oszlop + i]._Babu.Color == cella._Babu.Color) break;
                                else if (Map[cella.Sor + i, cella.Oszlop + i]._Babu.Color != cella._Babu.Color)
                                {
                                    cella._Babu.Lepesek.Add(Map[cella.Sor + i, cella.Oszlop + i]);
                                    break;
                                }
                            }
                        }

                        for (int i = 1; i < 8; i++)
                        {
                            if (cella.Sor + i < 8 && cella.Oszlop - i >= 0)
                            {
                                if (Map[cella.Sor + i, cella.Oszlop - i]._Babu == null)
                                    cella._Babu.Lepesek.Add(Map[cella.Sor + i, cella.Oszlop - i]);
                                else if (Map[cella.Sor + i, cella.Oszlop - i]._Babu.Color == cella._Babu.Color) break;
                                else if (Map[cella.Sor + i, cella.Oszlop - i]._Babu.Color != cella._Babu.Color)
                                {
                                    cella._Babu.Lepesek.Add(Map[cella.Sor + i, cella.Oszlop - i]);
                                    break;
                                }
                            }
                        }

                        for (int sor = cella.Sor + 1; sor < 8; sor++)
                        {
                            if (sor > 7) break;

                            if (Map[sor, cella.Oszlop]._Babu == null)
                                cella._Babu.Lepesek.Add(Map[sor, cella.Oszlop]);
                            else if (Map[sor, cella.Oszlop]._Babu.Color == cella._Babu.Color) break;
                            else if (Map[sor, cella.Oszlop]._Babu.Color != cella._Babu.Color)
                            {
                                cella._Babu.Lepesek.Add(Map[sor, cella.Oszlop]);
                                break;
                            }
                        }

                        for (int sor = cella.Sor - 1; sor >= 0; sor--)
                        {
                            if (sor < 0) break;

                            if (Map[sor, cella.Oszlop]._Babu == null)
                                cella._Babu.Lepesek.Add(Map[sor, cella.Oszlop]);
                            else if (Map[sor, cella.Oszlop]._Babu.Color == cella._Babu.Color) break;
                            else if (Map[sor, cella.Oszlop]._Babu.Color != cella._Babu.Color)
                            {
                                cella._Babu.Lepesek.Add(Map[sor, cella.Oszlop]);
                                break;
                            }
                        }

                        for (int oszlop = cella.Oszlop + 1; oszlop < 8; oszlop++)
                        {
                            if (oszlop > 7) break;

                            if (Map[cella.Sor, oszlop]._Babu == null)
                                cella._Babu.Lepesek.Add(Map[cella.Sor, oszlop]);
                            else if (Map[cella.Sor, oszlop]._Babu.Color == cella._Babu.Color) break;
                            else if (Map[cella.Sor, oszlop]._Babu.Color != cella._Babu.Color)
                            {
                                cella._Babu.Lepesek.Add(Map[cella.Sor, oszlop]);
                                break;
                            }
                        }

                        for (int oszlop = cella.Oszlop - 1; oszlop >= 0; oszlop--)
                        {
                            if (oszlop < 0) break;

                            if (Map[cella.Sor, oszlop]._Babu == null)
                                cella._Babu.Lepesek.Add(Map[cella.Sor, oszlop]);
                            else if (Map[cella.Sor, oszlop]._Babu.Color == cella._Babu.Color) break;
                            else if (Map[cella.Sor, oszlop]._Babu.Color != cella._Babu.Color)
                            {
                                cella._Babu.Lepesek.Add(Map[cella.Sor, oszlop]);
                                break;
                            }
                        }

                        break;
                    }

                case "king":
                    {
                        if (cella.Sor + 1 < 8 && cella.Oszlop + 1 < 8)
                            cella._Babu.Lepesek.Add(Map[cella.Sor + 1, cella.Oszlop + 1]);

                        if (cella.Sor + 1 < 8 && cella.Oszlop - 1 >= 0)
                            cella._Babu.Lepesek.Add(Map[cella.Sor + 1, cella.Oszlop - 1]);

                        if (cella.Sor - 1 >= 0 && cella.Oszlop - 1 >= 0)
                            cella._Babu.Lepesek.Add(Map[cella.Sor - 1, cella.Oszlop - 1]);

                        if (cella.Sor - 1 >= 0 && cella.Oszlop + 1 < 8)
                            cella._Babu.Lepesek.Add(Map[cella.Sor - 1, cella.Oszlop + 1]);

                        if (cella.Oszlop + 1 < 8)
                            cella._Babu.Lepesek.Add(Map[cella.Sor, cella.Oszlop + 1]);

                        if (cella.Sor + 1 < 8)
                            cella._Babu.Lepesek.Add(Map[cella.Sor + 1, cella.Oszlop]);

                        if (cella.Sor - 1 >= 0)
                            cella._Babu.Lepesek.Add(Map[cella.Sor - 1, cella.Oszlop]);

                        if (cella.Oszlop - 1 >= 0)
                            cella._Babu.Lepesek.Add(Map[cella.Sor, cella.Oszlop - 1]);

                        break;
                    }
            }

            foreach (Cella item in cella._Babu.Lepesek)
            {
                if (item._Babu == null)
                    item.Pbox.BackColor = Color.LawnGreen;
                else if (item._Babu.Color != cella._Babu.Color)
                    item.Pbox.BackColor = Color.IndianRed;
            }
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
