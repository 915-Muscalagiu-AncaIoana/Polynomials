using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matematica
{
    public partial class Comparare_Functii : Form
    {
        Pen creion = new Pen(Color.Black);
        Graphics g = null;
        float a1, b1, a2, b2, c2, a3, x, y;

        private void button2_Click(object sender, EventArgs e)
        {
            Lupa f = new Lupa();
            f.Show();

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.Transparent);
            a1 = (float)Double.Parse(textBox3.Text);
            b1 = (float)Double.Parse(textBox7.Text);
            a2 = (float)Double.Parse(textBox6.Text);
            b2= (float)Double.Parse(textBox5.Text);
            c2 = (float)Double.Parse(textBox8.Text);
            a3= (float)Double.Parse(textBox4.Text);
            x= (float)Double.Parse(textBox2.Text);
            y= (float)Double.Parse(textBox1.Text);
            float xmax, ymax, xmin, ymin;
            float imax, imin, jmax, jmin;
            float i0, j0;
            float didx, djdy;
            imax = pictureBox1.Width; imin = 0; jmin = 0; jmax = pictureBox1.Height;
            xmin = -20; ymin = -20;
            xmax = 20; ymax = 20;
            float Ax, Ay, Bx, By;
            Ax = (imax - imin) / (xmax - xmin);
            Bx = imin - Ax * xmin;
            Ay = (jmax - jmin) / (ymax - ymin);
            By = jmin - Ay * ymin;
            int nrpct = 100;
            float pas;

            
                i0 = Ax * 0 + Bx;
                g.DrawLine(creion, i0, jmin, i0, jmax);
            
            
            
                j0 = Ay * 0 + By;
                g.DrawLine(creion, imin, j0, imax, j0);

            
            float xf = x, yf, ip, jp, iant, jant;
            double A, X,fx;
            pas = (float)(y - x) / nrpct;
            iant = Ax * x + Bx;
            jant = Ay * ((float)a1 * x + b1) + By;
            jant = jant - 2 * (jant - j0);
            xf = x;
            for (var k = 1; k<= nrpct; k++)
            {
                xf = xf + pas;
                yf = (float)a1 * xf + b1;
                ip = Ax * xf + Bx;
                jp = Ay * yf + By;
                jp = jp - 2 * (jp - j0);
                g.DrawLine(creion, iant, jant, ip, jp);
                iant = ip; jant = jp;
            }
            xf = x;
            iant = Ax * x + Bx;
            jant = Ay * (a2 * x * x + b2 * x + c2)+By;
            jant = jant - 2 * (jant - j0);
              for(var k2=1; k2<=nrpct;k2++)
               {
                xf = xf + pas;
                yf = a2*xf* xf + b2*xf+c2;

                ip = Ax * xf + Bx;
                jp = Ay * yf + By;
                jp = jp - 2 * (jp - j0);
                g.DrawLine(creion, iant, jant, ip, jp);
                iant = ip; jant = jp;
            }
            
           
            A = (double)a3; X = (double)x;
            fx = Math.Pow(A, X);
            iant = Ax * x + Bx;
            jant = Ay * (float)fx + By;
            jant = jant - 2 * (jant - j0);
            xf = x;
            for (var k3 = 1; k3 <= nrpct; k3++)
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
            pictureBox1.Refresh();
        }



        public Comparare_Functii()
        {
            InitializeComponent();
            Bitmap Img;
            Img = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            pictureBox1.Image = Img;
            g = Graphics.FromImage(pictureBox1.Image);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
