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
    public partial class Functie_de_gradul_1 : Form
    { Pen creion = new Pen(Color.Black);
        Graphics g = null;
        float i0, j0;

        private void button2_Click(object sender, EventArgs e)
        {
            Lupa f = new Lupa();
            f.Show();


        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        float a, b, x, y;

        public Functie_de_gradul_1()
        {
            InitializeComponent();
            
            Bitmap Img;
            Img = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            pictureBox1.Image = Img;
            g = Graphics.FromImage(pictureBox1.Image);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
        private void button1_Click(object sender, EventArgs e)
        { 

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            g.Clear(Color.Transparent);

            float xmax, ymax, xmin, ymin;
             float imax, imin, jmax, jmin;
            float didx, djdy;
            imax = pictureBox1.Width; imin= 0; jmin = 0; jmax = pictureBox1.Height;
            xmin = -200; ymin = -200;
            xmax = 200; ymax = 200;
            float Ax, Ay,Bx,By;
            Ax = (imax - imin) / (xmax - xmin);
            Bx = imin - Ax * xmin;
            Ay = (jmax - jmin) / (ymax - ymin);
            By = jmin - Ay * ymin;
            int nrpct = 100;
            float pas;

            if (xmin * xmax < 0)
            {
                i0 = Ax * 0 + Bx;
                g.DrawLine(creion, i0, jmin, i0, jmax);
            }
            if ( ymin * ymax < 0)
            {
                j0= Ay * 0 + By;
                g.DrawLine(creion, imin, j0, imax, j0);

            }
            
            a = (float)Double.Parse(textBox3.Text);
            b = (float)Double.Parse(textBox4.Text);
            x = (float)Double.Parse(textBox1.Text);
            y = (float)Double.Parse(textBox2.Text);
            float xf=x, yf, ip ,jp, iant, jant;
            pas = (float) (y - x) / nrpct ;
            iant = Ax * x + Bx ;
            jant = Ay * ((float)a * x + b) + By;
            jant = jant - 2 * (jant - j0);
            for(var k=1;k<nrpct;k++)
             {
                xf = xf + pas;
                yf = (float)a * xf + b;
                ip = Ax * xf + Bx;
                jp = Ay * yf + By;
                jp = jp - 2 * (jp - j0);
                g.DrawLine(creion, iant, jant, ip, jp);
                iant = ip; jant = jp;
             }
            float maxim, minim;
            maxim = a * y + b;
            minim = a * x + b;
            textBox5.Text = Convert.ToString(minim);
            textBox10.Text = Convert.ToString(maxim);
            
            pictureBox1.Refresh();
            
            
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
           
           
        }
        
    }
}
