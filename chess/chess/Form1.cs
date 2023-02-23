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
        public int m = 0;
        public int s = 0;
        static Board board = new Board();
        static Cella selectedCella = null;

        public Form1()
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            this.BackColor = Color.FromArgb(0, 0, 0);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new Size(800, 640);
            timer1.Start();
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

            if (selectedCella == null)
            {
                if (cella._Babu != null)
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
                        selectedCella._Babu.Lepesek.Clear();
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
                            cella._Babu.ElsoLepes = false;
                            selectedCella._Babu = null;
                            selectedCella.Pbox.Image = null;
                            selectedCella = null;
                        }
                    }
                }
                else
                {
                    // Leütés
                    return;
                }
            }
        }

        private bool LepesCheck(Cella cella)
        {
            foreach (Cella item in selectedCella._Babu.Lepesek)
                if (item == cella) return true;

            return false;
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

        private void Timer1_Tick(object sender, EventArgs e)
        {
            s++;
            if (s == 60)
            {
                s = 0;
                m += 1;
            }
            if (s < 10)
            {
                secLbl.Text = "0" + s.ToString();
            }
            if (s >= 10)
            {
                secLbl.Text = s.ToString();
            }
            if (m < 10)
            {
                minLbl.Text = "0" + m.ToString();
            }
            if (m >= 10)
            {
                minLbl.Text = m.ToString();
            }
        }
    }
}
