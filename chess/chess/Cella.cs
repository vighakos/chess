using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chess
{
    class Cella
    {
        public PictureBox Pbox;
        public Babu _Babu;
        public int Sor, Oszlop;

        public Cella(PictureBox pictureBox, Babu babu, int sor, int oszlop)
        {
            Pbox = pictureBox;
            _Babu = babu;
            Sor = sor;
            Oszlop = oszlop;
        }
    }
}
