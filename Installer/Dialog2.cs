using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Installer
{
    public partial class Dialog2 : UserControl
    {
        public static bool back = true;
        public Dialog2()
        {
            InitializeComponent();
            textBox1.Text = Program.installdir;
            B_back.Enabled=back;
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
                textBox1.Text = fbd.SelectedPath;
                s();
            }
        }

        private void b_next_Click(object sender, EventArgs e)
        {
            s();
            Program.page = 3;
        }

        private void B_back_Click(object sender, EventArgs e)
        {
            s();
            Program.page = 1;
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
            Program.installdir = textBox1.Text;
            Program.readfile();
            if (Program.intedic[4].Substring(1, 4) == "this")
                Dialog3.skip = true;
        }

    }
}
