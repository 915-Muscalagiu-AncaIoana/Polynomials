using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matematica
{
    public partial class Functie_de_gradul_2 : Form
    {
        Pen creion = new Pen(Color.Black);
        Graphics g = null;
        static int centru_x, centru_y;
        static float Oxs_x, Oxs_y, Oys_x, Oys_y;
        float a, b, c, x, y;

        private void button2_Click(object sender, EventArgs e)
        {
            Lupa f = new Lupa();
            f.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.Transparent);
            a = (float)Double.Parse(textBox1.Text);
            b = (float)Double.Parse(textBox2.Text);
            c = (float)Double.Parse(textBox3.Text);
            x = (float)Double.Parse(textBox4.Text);
            y = (float)Double.Parse(textBox5.Text);
            float i0, j0, xmax, ymax, xmin, ymin;
            float imax, imin, jmax, jmin;
            float Ax, Ay, Bx, By;
            imax = pictureBox1.Width; imin = 0; jmin = 0; jmax = pictureBox1.Height;
            xmin = -40; xmax = 40;
            ymin = -200; ymax = 200;
            Ax = (imax - imin) / (xmax - xmin);
            Bx = imin - Ax * xmin;
            Ay = (jmax - jmin) / (ymax - ymin);
            By = jmin - Ay * ymin;
            int nrpct = 100;
            float pas;
            i0 = Bx; j0 = By;
            g.DrawLine(creion, i0, jmin, i0, jmax);
            g.DrawLine(creion, imin, j0, imax, j0);
            float xf, yf, ip, jp, iant, jant;
            pas = (float)(y - x) / nrpct;
            iant = Ax * x + Bx;
            jant = Ay * (a * x * x + b * x + c) + By;
            jant = jant - 2 * (jant - j0);
            xf = x;
            for(var k=1;k<=nrpct;k++)
            {
                xf = xf + pas;
                yf = a * xf * xf + b * xf + c;

                ip = Ax * xf + Bx;
                jp = Ay * yf + By;
                jp = jp - 2 * (jp - j0);
                g.DrawLine(creion, iant, jant, ip, jp);
                iant = ip;jant = jp;
            
            }
            float maxim, minim, min1, min2, max1, max2;
            if (a < 0)
            {  float vv= (-b) / (2 * a);
                
                min1 = a * x * x + b * x + c;
                min2 = a * y * y + b * y + c;
                max1 = min1; max2 = min2;
                if (vv >= x && vv <= y)
                    maxim = a * (-b / (2 * a)) * (-b / (2 * a)) + b * (-b / (2 * a)) + c;
                else if (max1 > max2)
                    maxim = max1;
                     else maxim = max2;
                if (min1 > min2)
                    minim = min2;
                else minim = min1;
            }
            else { 
                  
                float v = (-b) / (2 * a);
                 max1= a * x * x + b * x + c;
                 max2 = a * y * y + b * y + c;
                min1 = max1; min2 = max2;
                if (v >= x && v <= y)
                    minim = a * (-b / (2 * a)) * (-b / (2 * a)) + b * (-b / (2 * a)) + c;
                else if (min1 > min2)
                    minim = min2;
                     else minim = min1;
                if (max1 > max2)
                    maxim = max1;
                else maxim = max2;
                 }
            textBox7.Text = Convert.ToString(minim);
            textBox6.Text = Convert.ToString(maxim);
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
           // e.Graphics.DrawLine(creion, Oxs_x, Oxs_y, Oxf_x, Oxf_y);
          //  e.Graphics.DrawLine(creion, Oys_x, Oys_y, Oyf_x, Oyf_y);
        }

        static float Oxf_x, Oxf_y, Oyf_x, Oyf_y;
        

        public Functie_de_gradul_2()
        {
            InitializeComponent();
            Bitmap Img;
            Img = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            pictureBox1.Image = Img;
            g = Graphics.FromImage(pictureBox1.Image);

        }

        private void Functie_de_gradul_2_Load(object sender, EventArgs e)
        {

        }
    }
}
