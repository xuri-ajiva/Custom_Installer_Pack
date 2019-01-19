using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIO;

namespace Installer
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
                VAR.installfile = openFileDialog1.FileName;
                textBox1.Text = VAR.installfile;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                VAR.installdir = folderBrowserDialog1.SelectedPath;
                textBox2.Text = VAR.installdir;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                VAR.installfiles = folderBrowserDialog2.SelectedPath;
                textBox3.Text = VAR.installfiles;
            }
        }
    }
}
