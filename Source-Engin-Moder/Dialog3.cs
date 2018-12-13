using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Source_Engin_Moder
{
    public partial class Dialog3 : UserControl
    {
        public Dialog3()
        {
            InitializeComponent();
            textBox1.Text = Program.installfiles;
        }
        private void b_cancle_Click(object sender, EventArgs e)
        {
            s();
            exit ex = new exit();
            if (ex.ShowDialog() == DialogResult.OK)
            {
                Environment.Exit(Program.error);
            }
            else
            {

            }
        }
        private void open_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                s();
            }
        }

        private void b_next_Click(object sender, EventArgs e)
        {
            s();
            Program.page = 4;
        }

        private void B_back_Click(object sender, EventArgs e)
        {
            s();
            Program.page = 2;
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
        private void s()
        {
            Program.installfiles = fbd.SelectedPath;
            textBox1.Text = Program.installfiles;
        }
    }
}

