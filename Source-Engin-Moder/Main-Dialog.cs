using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Source_Engin_Moder
{
    public partial class Main_Dialog : Form
    {
        public Main_Dialog()
        {
            InitializeComponent();
        }

        private void open_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Program.installfile = openFileDialog1.FileName;
                textBox1.Text = Program.installfile;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Program.installdir = folderBrowserDialog1.SelectedPath;
                textBox2.Text = Program.installdir;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                Program.installfiles = folderBrowserDialog2.SelectedPath;
                textBox3.Text = Program.installfiles;
            }
        }
    }
}
