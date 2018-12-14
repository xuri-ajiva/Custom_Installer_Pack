using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Source_Engin_Moder
{
    public partial class Dialog03 : Form
    {
        public Dialog03()
        {
            InitializeComponent();
            textBox1.Text = Program.installfiles;
        }
        private void open_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                Program.installfiles = fbd.SelectedPath;
                textBox1.Text = Program.installfiles;
            }
        }

        private void b_next_Click(object sender, EventArgs e)
        {
            this.PB.Visible = true;
            Thread t = new Thread(() => {
                var handle = Program.GetConsoleWindow();
                Program.ShowWindow(handle, Program.SW_SHOW);
                if (Program.installdir != "slect!" && Program.installfile != "slect!" && Program.installfiles != "slect!")
                {
                    try
                    {
                        code.Dialog_install();
                    }
                    catch (Exception expr)
                    {
                        MessageBox.Show(expr.Message);
                    }
                }
                else
                {
                    this.Invoke((MethodInvoker) delegate
                    {
                        this.PB.Visible = false;
                        this.Hide();
                        Program.d1.ShowDialog();
                    });
                }
            });
            t.Start();
        }


        private void B_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.d2.Show();
        }

        private void b_cancle_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Dialog03_FormClosing(object sender, FormClosingEventArgs e)
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
