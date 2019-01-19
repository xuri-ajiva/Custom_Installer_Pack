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
    public partial class Host_dialog : Form
    {
        private UserControl dialog;

        public Host_dialog()
        {
            InitializeComponent();

            this.Grid.Location = new System.Drawing.Point(0, 0);
            this.Grid.Size = new System.Drawing.Size(500, 500);
            this.ClientSize = new System.Drawing.Size(500, 500);
            /*
            switch (VAR.page)
            {
                case 1:
                    this.dialog = new Source_Engin_Moder.Dialog1();
                    break;
                case 2:
                    this.dialog = null;
                    this.dialog = new Source_Engin_Moder.Dialog2();
                    break;
                case 3:
                    this.dialog = new Source_Engin_Moder.Dialog3();
                    break;
                case 4:
                    this.dialog = new Source_Engin_Moder.Final();
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }


            this.dialog.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dialog.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dialog.Location = new System.Drawing.Point(0, 0);
            this.dialog.Name = "dialog11";
            this.dialog.Size = new System.Drawing.Size(500, 500);
            this.dialog.TabIndex = 0;
            //this.dialog.Dock = DockStyle.Fill;
            this.Grid.Controls.Add(this.dialog);
            */
            update.Start();

        }

        private int temp = 0;
        private void update_Tick(object sender, EventArgs e)
        {
            if (VAR.page != temp)
            {
                this.Grid.Controls.Clear();
                this.dialog = null;
                switch (VAR.page)
                {

                    case 1:
                        this.dialog = new Installer.Dialog1();
                        break;
                    case 2:
                        this.dialog = new Installer.Dialog2();
                        if (VAR.min_page == 2)
                            Dialog2.back = false;
                        break;
                    case 3:
                        this.dialog = new Installer.Dialog3();
                        break;
                    case 4:
                        this.dialog = new Installer.Final();
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
            }
            temp = VAR.page;
            this.dialog.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dialog.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dialog.Location = new System.Drawing.Point(0, 0);
            this.dialog.Name = "dialog11";
            this.dialog.Size = new System.Drawing.Size(500, 500);
            this.dialog.TabIndex = 0;
            //this.dialog.Dock = DockStyle.Fill;
            this.Grid.Controls.Add(this.dialog);
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
                Environment.Exit(VAR.error);
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
