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

            Size size = new Size(70, 70);
            for (int sor = 0; sor < 8; sor++)
                for (int oszlop = 0; oszlop < 8; oszlop++)
                {
                    bool sotete = sor % 2 == 0 && oszlop % 2 == 0 || sor % 2 == 1 && oszlop % 2 == 1;
                    PictureBox uj = new PictureBox()
                    {
                        Size = size,
                        Location = new Point(20 + oszlop * 70, 20 + sor * 70),
                        Name = $"{sor}_{oszlop}",
                        SizeMode = PictureBoxSizeMode.CenterImage
                    };

                    uj.BackColor = sotete ? Color.Black : Color.White;
                    uj.Click += new EventHandler(Pb_Click);
                    this.Controls.Add(uj);
                }
        }

        private void Pb_Click(object sender, EventArgs e)
        {
            
        }
    }
}
