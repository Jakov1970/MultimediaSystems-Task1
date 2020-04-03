using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "Image File (*.bmp,*.jpg,)|*.bmp;*.jpg";
            if(DialogResult.OK==o.ShowDialog())
            {
                this.pictureBox1.Image = new Bitmap(o.FileName);
            }
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap copy = new Bitmap((Bitmap)this.pictureBox1.Image);
            Parametri par = new Parametri(.501, .387, .114, 1, 2, 3);

            Obrada.GrayscaleAndGammma(copy, par);
            this.pictureBox2.Image = copy;
        }
    }
}
