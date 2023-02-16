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
        public Form1()
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            this.BackColor = Color.FromArgb(192, 192, 192);
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
                        Location = new Point(20 + oszlop * 70, 20 + sor * 70),
                        Name = $"{sor}_{oszlop}",
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        BackColor = sotete ? Color.Black : Color.White,
                        BackgroundImage = board.GetPiece(board.iMap[sor, oszlop])
                    };
                    /*
                    Babu ujBabu = new Babu("light", "a");
                    board.Map[sor, oszlop] = new Cella(uj, ujBabu, sor, oszlop);
                    */
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

            MessageBox.Show(cella.Pbox.Image.ToString());
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
