using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chess
{
    public partial class Form1 : Form
    {
        static Board board = new Board();
        static Cella selectedCella = null;
        static List<Cella> KivertBabuk_White = new List<Cella>();
        static List<Cella> KivertBabuk_Black = new List<Cella>();
        static Player p_black = new Player("black"), p_white = new Player("white"), currentPlayer = p_white;
        static bool promotion = false;
        static List<PictureBox> promotionList;
        static Cella promote = null;

        public Form1()
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            for (int sor = 0; sor < 8; sor++)
                for (int oszlop = 0; oszlop < 8; oszlop++)
                {
                    bool sotete = (sor + oszlop) % 2 != 0;
                    PictureBox uj = new PictureBox()
                    {
                        Size = new Size(70, 70),
                        Location = new Point(20 + oszlop * 71, 20 + sor * 71),
                        Name = $"{sor}_{oszlop}",
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        BackColor = sotete ? Color.CornflowerBlue : Color.White
                    };

                    string color = "";
                    if (sor == 0 || sor == 1) color = "black";
                    else if (sor == 6 || sor == 7) color = "white";

                    Babu ujBabu = color == "" ? null : new Babu(color, board.GetPiece(board.iMap[sor, oszlop]));
                    board.Map[sor, oszlop] = new Cella(uj, ujBabu, sor, oszlop);

                    if (color != "") uj.Image = ujBabu.GetImage();
                    else if (color == "white") p_white.Babus.Add(ujBabu);
                    else if (color == "white") p_black.Babus.Add(ujBabu);

                    uj.Click += new EventHandler(Pb_Click);
                    this.Controls.Add(uj);
                }
        }

        private void Pb_Click(object sender, EventArgs e)
        {
            PictureBox item = (PictureBox)sender;
            int koord_x = Convert.ToInt32(item.Name.Split('_')[0]);
            int koord_y = Convert.ToInt32(item.Name.Split('_')[1]);

            Cella cella = board.Map[koord_x, koord_y];

            if (promotion) return;
            if (selectedCella == null)
            {
                if (cella._Babu != null && cella._Babu.Color == currentPlayer.Color)
                {
                    ClearBoard();
                    selectedCella = cella;
                    selectedCella.Pbox.BackColor = Color.Goldenrod;
                    board.Lepesek(cella);
                }
                else return;
            }
            else if (selectedCella == cella)
            {
                ClearBoard();
                selectedCella = null;
            }
            else if (selectedCella != null)
            {
                if (cella._Babu == null)
                {
                    if (selectedCella == cella)
                    {
                        ClearBoard();
                        selectedCella = null;
                        return;
                    }
                    else if (selectedCella != cella)
                    {
                        if (LepesCheck(cella))
                        {
                            ClearBoard();
                            cella.Pbox.Image = selectedCella.Pbox.Image;
                            cella._Babu = selectedCella._Babu;
                            if (cella._Babu.ElsoLepes) cella._Babu.ElsoLepes = false;
                            selectedCella.Pbox.Image = null;
                            selectedCella._Babu = null;
                            selectedCella.Pbox.Image = null;
                            selectedCella = null;

                            if (cella._Babu.Piece == "pawn")
                                if (cella.Sor == 0 && currentPlayer.Color == "white" || cella.Sor == 7 && currentPlayer.Color == "black")
                                    Promote(cella);

                            PlayerSwitch();
                        }
                    }
                }
                else if(cella._Babu.Color == selectedCella._Babu.Color) return;
                else
                {
                    if (LepesCheck(cella)) Kiver(cella);

                    return;
                }
            }
        }

        private void Promote(Cella cella)
        {
            promotion = true;
            promote = cella;
            promote.Pbox.BackColor = Color.Goldenrod;
            nextPlayerLbl.Text = "Válassz egy bábut:";

            promotionList = new List<PictureBox>();
            PictureBox queen = new PictureBox()
            {
                Size = new Size(50, 50),
                Location = new Point(700, 315),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = currentPlayer.Color == "white" ? Properties.Resources.white_queen : Properties.Resources.black_queen,
                BackColor = Color.White,
                Name = "queen"
            };
            queen.Click += Promote_Click;
            promotionList.Add(queen);
            this.Controls.Add(queen);

            PictureBox rook = new PictureBox()
            {
                Size = new Size(50, 50),
                Location = new Point(755, 315),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = currentPlayer.Color == "white" ? Properties.Resources.white_rook : Properties.Resources.black_rook,
                BackColor = Color.White,
                Name = "rook"
            };
            rook.Click += Promote_Click;
            promotionList.Add(rook);
            this.Controls.Add(rook);

            PictureBox knight = new PictureBox()
            {
                Size = new Size(50, 50),
                Location = new Point(810, 315),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = currentPlayer.Color == "white" ? Properties.Resources.white_knight : Properties.Resources.black_knight,
                BackColor = Color.White,
                Name = "knight"
            };
            knight.Click += Promote_Click;
            promotionList.Add(knight);
            this.Controls.Add(knight);

            PictureBox bishop = new PictureBox()
            {
                Size = new Size(50, 50),
                Location = new Point(865, 315),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = currentPlayer.Color == "white" ? Properties.Resources.white_bishop : Properties.Resources.black_bishop,
                BackColor = Color.White,
                Name = "bishop"
            };
            bishop.Click += Promote_Click;
            promotionList.Add(bishop);
            this.Controls.Add(bishop);
        }

        private void PlayerSwitch()
        {
            if (currentPlayer.Color == "white")
            {
                currentPlayer = p_black;
                nextPlayerLbl.Text = "Fekete játékos következik";
            }
            else
            {
                currentPlayer = p_white;
                nextPlayerLbl.Text = "Fehér játékos következik";
            }

            if (!timer.Enabled) timer.Start();
        }

        private void Kiver(Cella cella)
        {
            ClearBoard();

            this.Controls.Add(new PictureBox()
            {
                Size = new Size(25, 25),
                Location = new Point(600 + (cella._Babu.Color == "white" ? KivertBabuk_White.Count : KivertBabuk_Black.Count) * 26, cella._Babu.Color == "white" ? 70 : 100),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = cella._Babu.GetImage(),
                BackColor = Color.White
            });

            if (cella._Babu.Color == "white") KivertBabuk_White.Add(cella);
            else KivertBabuk_Black.Add(cella);

            currentPlayer.Babus.Remove(cella._Babu);
            cella.Pbox.Image = selectedCella.Pbox.Image;
            cella._Babu = selectedCella._Babu;
            if (cella._Babu.ElsoLepes) cella._Babu.ElsoLepes = false;
            selectedCella.Pbox.Image = null;
            selectedCella._Babu = null;
            selectedCella.Pbox.Image = null;
            selectedCella = null;

            if (cella._Babu.Piece == "pawn")
                if (cella.Sor == 0 && currentPlayer.Color == "white" || cella.Sor == 7 && currentPlayer.Color == "black")
                    Promote(cella);


            if (!promotion) PlayerSwitch();
        }

        private bool LepesCheck(Cella cella)
        {
            foreach (Cella item in selectedCella._Babu.Lepesek)
                if (item == cella) return true;

            return false;
        }

        private void Promote_Click(object sender, EventArgs e)
        {
            PictureBox item = (PictureBox)sender;

            promote.Pbox.Image = item.Image;
            promote._Babu.Piece = item.Name;

            foreach (PictureBox pbox in promotionList)
                this.Controls.Remove(pbox);

            ClearBoard();

            promote = null;
            promotion = false;
            PlayerSwitch();
        }

        private void ClearBoard()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 != 0) board.Map[i, j].Pbox.BackColor = Color.CornflowerBlue;
                    else board.Map[i, j].Pbox.BackColor = Color.White;
                }

        }

        private void Timer_tick(object sender, EventArgs e)
        {
            int min, sec;

            if (currentPlayer.Color == "white")
            {
                min = Convert.ToInt32(white_min.Text);

                string secText = white_sec.Text;

                if (secText == "00") sec = 0;
                else if (secText[0] == '0')
                {
                    secText = white_sec.Text[1].ToString();
                    sec = Convert.ToInt32(secText);
                }
                else sec = Convert.ToInt32(white_sec.Text);
            }
            else
            {
                min = Convert.ToInt32(black_min.Text);

                string secText = black_sec.Text;

                if (secText == "00") sec = 0;
                else if (secText[0] == '0')
                {
                    secText = black_sec.Text[1].ToString();
                    sec = Convert.ToInt32(secText);
                }
                else sec = Convert.ToInt32(black_sec.Text);
            }

            if (sec == 0 && min == 0)
            {
                timer.Stop();
                string color = currentPlayer.Color == "white" ? "Fekete" : "Fehér";

                DialogResult a = MessageBox.Show($"{color} játékos nyert! Szeretnél újat kezdeni?", "Lejárt az idő", MessageBoxButtons.YesNo);

                if (a == DialogResult.Yes) Application.Restart();
                else Application.Exit();
            }

            if (sec == 0)
            {
                sec = 59;
                min--;
            }
            else sec--;

            if (currentPlayer.Color == "white")
            {
                white_min.Text = min.ToString();
                if (sec < 10)
                {
                    white_sec.Text = 0 + sec.ToString();
                }
                else white_sec.Text = sec.ToString();
            }
            else
            {
                black_min.Text = min.ToString();
                if (sec < 10)
                {
                    black_sec.Text = 0 + sec.ToString();
                }
                else black_sec.Text = sec.ToString();
            }
        }
    }
}
