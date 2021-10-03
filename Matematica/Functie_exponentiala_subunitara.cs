using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matematica
{
    public partial class Functie_exponentiala_subunitara : Form
    {
        Pen creion = new Pen(Color.Black);
        Graphics g = null;
        float a, x, y;

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.Transparent);
            a = (float)Double.Parse(textBox1.Text);
            x = (float)Double.Parse(textBox2.Text);
            y = (float)Double.Parse(textBox3.Text);
            float xmin, xmax, ymin, ymax, imax, imin, jmax, jmin,j0,i0,pas;
            imax = pictureBox1.Width; imin = 0; jmin = 0; jmax = pictureBox1.Height;
            xmin = -10; xmax = 10;
            ymin = -10; ymax = 10;
            float Ax, Bx, Ay, By;
            int nrpct = 100;
            pas = (float)(y - x) / nrpct;
            Ax = (imax - imin) / (xmax - xmin);
            Bx = imin - Ax * xmin;
            Ay = (jmax - jmin) / (ymax - ymin);
            By = jmin - Ay * ymin;
            i0 = Bx; j0 = By;
            g.DrawLine(creion, i0, jmin, i0, jmax);
            g.DrawLine(creion, imin, j0, imax, j0);
            float xf, yf, ip, jp, iant, jant;
            double fx,A,X;
            A = (double)a; X = (double)x;
            fx = Math.Pow(A, X);
            iant = Ax * x + Bx;
            jant = Ay * (float)fx + By;
            jant = jant - 2 * (jant - j0);
            xf = x;
               for(var k=1;k<=nrpct;k++)
                 {
                   xf = xf + pas;
                   X = (double)xf;
                  fx = Math.Pow(A, X);
                  yf = (float)fx;
                  ip = Ax * xf + Bx;
                  jp = Ay * yf + By;
                jp = jp - 2 * (jp - j0);
                  g.DrawLine(creion, iant, jant, ip, jp);
                 iant = ip; jant = jp;
           
                 }
            float maxim, minim;
            X = (double)x;
            double Y;
            Y = (double)y;
            minim = (float)Math.Pow(A, Y);
            maxim = (float)Math.Pow(A, X);
            textBox5.Text = Convert.ToString(minim);
            textBox4.Text = Convert.ToString(maxim);

            pictureBox1.Refresh();
        }

        
        public Functie_exponentiala_subunitara()
        {
            InitializeComponent();
            Bitmap Img;
            Img = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            pictureBox1.Image = Img;
            g = Graphics.FromImage(pictureBox1.Image);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lupa f = new Lupa();
            f.Show();

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
           
        }
    }
}
