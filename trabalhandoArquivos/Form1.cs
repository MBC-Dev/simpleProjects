using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace trabalhandoArquivos
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            gravar();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gravar();
            }

        }

        public void gravar()
        {
            File.AppendAllText("c:/nomes.txt", textBox1.Text + "\r\n");
            textBox1.Text = "";
            textBox1.Focus();
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listar l = new Listar();
            l.ShowDialog();
        }
    }
}
