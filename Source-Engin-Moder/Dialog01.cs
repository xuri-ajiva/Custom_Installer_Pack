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
    public partial class Dialog01 : Form
    {
        public Dialog01()
        {
            InitializeComponent();
            textBox1.Text =Program.installfile;
        }

        private void open_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Program.installfile = ofd.FileName;
                textBox1.Text = Program.installfile;
            }
        }

        private void b_next_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.d2.Show();
        }

        private void B_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.d1.Show();
        }

        private void b_cancle_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Dialog01_FormClosing(object sender, FormClosingEventArgs e)
        {
            exit ex = new exit();
            if (ex.ShowDialog() == DialogResult.OK)
            {
                Environment.Exit(Program.error);
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
