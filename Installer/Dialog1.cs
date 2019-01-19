using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIO;

namespace Installer
{
    public partial class Dialog1 : UserControl
    {
        public Dialog1()
        {
            InitializeComponent();
            textBox1.Text = VAR.installfile;
        }



        private void b_cancle_Click_1(object sender, EventArgs e)
        {
            s();
            exit ex = new exit();
            if (ex.ShowDialog() == DialogResult.OK)
            {
                Environment.Exit(VAR.error);
            }
            else
            {

            }
        }
        private void open_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
                s();
            }
        }

        private void b_next_Click(object sender, EventArgs e)
        {
            s();
            VAR.page = 2;
        }

        private void B_back_Click(object sender, EventArgs e)
        {
            s();
            VAR.page = 1;
        }

        private void Dialog01_FormClosing(object sender, FormClosingEventArgs e)
        {
            s();
            exit ex = new exit();
            if (ex.ShowDialog() == DialogResult.OK)
            {
                Environment.Exit(VAR.error);
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void s()
        {
            VAR.installfile = textBox1.Text;
        }
    }
}
