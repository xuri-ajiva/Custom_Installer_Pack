using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using AIO;

namespace Application_Manager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var fiel = File.ReadLines(VAR.regfull).Where(x => x.StartsWith("#")).ToArray();
                foreach (var fil in fiel)
                {
                    ListViewItem i = new ListViewItem();
                    try
                    {
                        VAR.intedic = File.ReadLines(VAR.reg + fil.Substring(1)).Where(x => x.StartsWith("#")).ToArray();
                        i.Text = VAR.intedic[3].Substring(1);
                        i.SubItems.Add(VAR.intedic[2].Substring(1));
                        i.SubItems.Add(VAR.intedic[1].Substring(1));
                        i.SubItems.Add(VAR.intedic[0].Substring(1));
                        i.SubItems.Add(VAR.intedic[4].Substring(1));
                        i.SubItems.Add(VAR.intedic[5].Substring(1));
                        i.Tag = VAR.intedic[3].Substring(1);
                        i.Name = VAR.intedic[3].Substring(1);
                        lstTransfers.Items.Add(i);
                        i.EnsureVisible();

                    }
                    catch (Exception f)
                    {
                        try { lstTransfers.Items.Add(i); } catch (Exception fx) { Console.WriteLine(fx.Message); }
                        Console.WriteLine(f.Message);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error!");
            }
        }
        private void uninstall(int si)
        {
            try
            {

                var da = File.ReadLines(lstTransfers.SelectedItems[si].SubItems[5].Text).Where(x => x.StartsWith("#")).ToArray();
                for (int c = VAR.interduction; c < da.Length; c++)
                {
                    VAR.cur[c] = da[c].Split('>');
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("[Info] ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" # ");
                        Console.Write(VAR.cur[c][0]);
                        Console.Write("  X  ");
                        Console.Write(VAR.cur[c][1] + "\n");
                    }
                    catch
                    {
                    }
                }


                for (int c = VAR.interduction; c < da.Length; c++)
                {
                    try
                    {
                        File.Delete(lstTransfers.SelectedItems[si].SubItems[4].Text + "\\" + VAR.cur[c][1]);
                        /*
                        File.Delete(@"c:\r\" + VAR.cur[c][0].Substring(1));
                        File.Move(lstTransfers.SelectedItems[0].SubItems[4].Text + "\\" + VAR.cur[c][0].Substring(1), @"c:\r\" + VAR.cur[c][0].Substring(1));
                        */
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("[Delete] ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(lstTransfers.SelectedItems[si].SubItems[4].Text + "\\" + VAR.cur[c][0].Substring(1));
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    catch (Exception exp)
                    {

                        VAR.error++;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[Error]:" + exp.Message);
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                }
                if (VAR.error < 5)
                {
                    File.Delete(lstTransfers.SelectedItems[si].SubItems[5].Text);
                    dl_reg(si);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!" + ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            VAR.error = 0;
            for (var si = 0; si < lstTransfers.SelectedItems.Count; si++)
            {
                try
                {
                    if (MessageBox.Show("Are you shure to uninstall " + lstTransfers.SelectedItems[si] + "\nUninstall conot be undoed!", "Shure?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        uninstall(si);
                        Thread.Sleep(9);
                    }
                }
                catch (Exception fx) { Console.WriteLine(fx.Message); }
            }
        }

        private void dl_reg(int si)
        {
            File.Delete(VAR.reg + @"\" + lstTransfers.SelectedItems[si].SubItems[0].Text);
            Console.WriteLine(VAR.reg + @"\" + lstTransfers.SelectedItems[si].SubItems[0].Text);
            var intedics = new string[9999];
            var redet = File.ReadLines(VAR.regfull).Where(x => x.StartsWith("#")).ToArray();
            for (var i = 0;i<redet.Length;i++)
            {
                if (redet[i].Substring(1) != (lstTransfers.SelectedItems[si].SubItems[0].Text))
                {
                    intedics[i] = redet[i];
                }
            }
            for (var i = 0; i < intedics.Length; i++)
            {
                if (!String.IsNullOrWhiteSpace(intedics[i]))
                {
                    Console.WriteLine(intedics[i]);
                }
            }

            File.Delete(VAR.regfull + "old");
            File.Move(VAR.regfull, VAR.regfull+"old");
            File.Create(VAR.regfull).Close();

            StreamWriter WStream2 = new StreamWriter(VAR.regfull, true);

            foreach ( var j in intedics)
            {
                if (!String.IsNullOrWhiteSpace(j))
                {
                    WStream2.WriteLine(j);
                }
            }
            WStream2.Close();
            rescan(null,null);
        }
        public void rescan(object sender, EventArgs e)
        {
            lstTransfers.Clear();
            this.lstTransfers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader2});
            this.lstTransfers.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstTransfers.FullRowSelect = true;
            this.lstTransfers.Location = new System.Drawing.Point(0, 0);
            this.lstTransfers.Name = "lstTransfers";
            this.lstTransfers.Size = new System.Drawing.Size(1039, 386);
            this.lstTransfers.TabIndex = 3;
            this.lstTransfers.UseCompatibleStateImageBehavior = false;
            this.lstTransfers.View = System.Windows.Forms.View.Details;
            Form1_Load(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VAR.error = 0;
            for (var si = 0; si < lstTransfers.SelectedItems.Count; si++)
            {
                try
                {
                    if (MessageBox.Show("Are you shure to uninstall " + lstTransfers.SelectedItems[si] + "\nUninstall conot be undoed!", "Shure?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        dl_reg(si);
                        Thread.Sleep(9);
                    }
                }
                catch (Exception fx) { Console.WriteLine(fx.Message); }
            }
        }
    }
}
