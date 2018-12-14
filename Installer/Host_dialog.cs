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
    public partial class Host_dialog : Form
    {
        public Host_dialog()
        {
            InitializeComponent();

            this.Grid.Location = new System.Drawing.Point(1, 1);
            this.Grid.Size = new System.Drawing.Size(500, 500);
            this.ClientSize = new System.Drawing.Size(502, 502);
            dialog11.Dock = DockStyle.Fill;
            dialog21.Dock = DockStyle.Fill;
            dialog31.Dock = DockStyle.Fill;
            final1.Dock = DockStyle.Fill;
            dialog11.Visible = false;
            dialog21.Visible = false;
            dialog31.Visible = false;
            final1.Visible = false;

            if (Program.page ==1)
                dialog11.Visible = true;

            if (Program.page == 2)
                dialog21.Visible = true;

            if (Program.page == 3)
                dialog31.Visible = true;

            if (Program.page == 4)
                final1.Visible = true;

            update.Start();

        }

        private void update_Tick(object sender, EventArgs e)
        {


            if (Program.page == 1)
            {
                dialog21.Visible = false;
                dialog31.Visible = false;
                final1.Visible = false;

                dialog11.Visible = true;
            }
            if (Program.page == 2)
            {
                dialog11.Visible = false;
                dialog31.Visible = false;
                final1.Visible = false;

                dialog21.Visible = true;
            }

            if (Program.page == 3)
            {
                dialog11.Visible = false;
                dialog21.Visible = false;
                final1.Visible = false;

                dialog31.Visible = true;
            }

            if (Program.page == 4)
            {
                dialog11.Visible = false;
                dialog21.Visible = false;
                dialog31.Visible = false;

                final1.Visible = true;
            }
        }
        public void A_NEXT()
        {

        }
        public void A_BACK()
        {

        }
        public void A_CANCLE()
        {

        }

        private void Host_dialog_FormClosing(object sender, FormClosingEventArgs e)
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
