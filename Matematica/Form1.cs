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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void functiiDeGradul1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Functie_de_gradul_1 f = new Functie_de_gradul_1() ;
            f.Show();
        }

        private void functiiDeGradul2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Functie_de_gradul_2 f = new Functie_de_gradul_2();
            f.Show();

        }

        private void bazaSubunitaraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Functie_exponentiala_subunitara f = new Functie_exponentiala_subunitara();
            f.Show();
        }

        private void bazaSupraunitaraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Functie_exponentiala_supraunitara f = new Functie_exponentiala_supraunitara();
            f.Show();

        }

        private void comparareFunctiicomplexitateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Comparare_Functii f = new Comparare_Functii();
            f.Show();
        }

        private void fuctiiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void proprietatiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proprietati_generale f = new Proprietati_generale();
            f.Show();
        }
    }
}
