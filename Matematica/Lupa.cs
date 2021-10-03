using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matematica
{
    public partial class Lupa : Form
    {
        Graphics Capture;
        Bitmap Img;
        Point Mouse;
        Boolean Buton ;
        int Zoom = 1;

        public Lupa()
        {
            InitializeComponent();
            this.TransparencyKey = Color.Turquoise;
            this.BackColor = Color.Turquoise;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int Latime, Lungime;
            int MouseX, MouseY;
            Latime = pictureBox1.Height;
            Lungime = pictureBox1.Width;
            MouseX = MousePosition.X;
            MouseY = MousePosition.Y;
            
            //Captura de ecran
            Img = new Bitmap(Lungime / Zoom, Latime / Zoom, System.Drawing.Imaging.PixelFormat.Format64bppArgb);
            Capture = this.CreateGraphics();
            
            //Copia exacta a ecranului
            Capture = Graphics.FromImage(Img);
            Capture.CopyFromScreen(MouseX - Lungime / (Zoom * 2), MouseY - Latime / (Zoom * 2), 0, 0, pictureBox1.Size);
            
            // Adaptare dimensiune ecran 
            Bitmap Imgnou = new Bitmap(Lungime, Latime);
            Capture = Graphics.FromImage(Imgnou);
            Capture.SmoothingMode = SmoothingMode.HighQuality;
            Capture.DrawImage(Img, new Rectangle(0, 0, Lungime, Latime));
            pictureBox1.Image = Imgnou;

            // Forma circulara a lupei

            Rectangle forma = new Rectangle(0, 0, Lungime, Latime);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(forma);
            pictureBox1.Region = new Region(path);

            //Forma circulara a panel-ului

            Rectangle formap = new Rectangle(0, 0, panel1.Width, panel1.Height);
            GraphicsPath pathp = new GraphicsPath();
            pathp.AddEllipse(formap);
            panel1.Region = new Region(pathp);

            //Lupa se misca dupa mouse

            this.Location = new Point(Cursor.Position.X, Cursor.Position.Y);

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {  if(Buton==true)
            {
                Location = new Point(Cursor.Position.X - Mouse.X, Cursor.Position.Y - Mouse.Y);

            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Mouse = new Point(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y);
            Buton = true;

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Buton = false;

        }

        private void Lupa_KeyDown(object sender, KeyEventArgs e)
        {
            //Comanda de a mari zoomul la apasarea tastei Z
            if ((e.KeyCode & Keys.Z) == Keys.Z)
                Zoom++;

            // Comanda de a micsora zoomul la apasarea tastei Ctrl, daca acesta a fost marit inainte
            if ((e.KeyCode & Keys.ControlKey) == Keys.ControlKey)
                if (Zoom > 1)
                    Zoom--;

            //Comanda de a iesi din utilizarea lupei la apasarea tastei Esc
            if ((e.KeyCode & Keys.Escape) == Keys.Escape)
                this.Close();
        }
    }
}
