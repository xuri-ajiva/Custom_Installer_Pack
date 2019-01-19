using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace Installer
{
    public partial class Final : UserControl
    {

        private static Log l = new Log();
        public Final()
        {
            InitializeComponent();
        }

        private void b_next_Click(object sender, EventArgs e)
        {
            //button1_Click(null, null);
            this.PB.Visible = true;
            
            Thread t = new Thread(() => {
                var para = "";
                if (Program.installdir != para && Program.installfile != para && Program.installfiles != para)
                {
                    try
                    {
                        Install_prepar();
                    }
                    catch (Exception expr)
                    {
                        MessageBox.Show(expr.Message);
                    }
                }
                else
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.PB.Visible = false;
                        MessageBox.Show("Nicht alle parameter erfüllt!");
                    });
                }
            });
            t.Start();
        }


        private void Final_Load(object sender, EventArgs e)
        {
            Program.readfile();
            update.Start();
        }
        
        private void update_Tick(object sender, EventArgs e)
        {
            try
            {
                label1.Text = "Info: " + Program.intedic[0].Substring(1);
                label2.Text = "Download: " + Program.intedic[1].Substring(1);
                label3.Text = "Version: " + Program.intedic[2].Substring(1);
                label4.Text = "Name: " + Program.intedic[3].Substring(1);
                label5.Text = "\nInstallations Verzeichnis: " + Program.installdir;
            }
            catch{ }
            try
            {
                foreach (var x in log.Items)
                {
                    if (!x.ToString().Equals(l.listBox1.Items[l.listBox1.Items.Count]))
                    {
                        l.listBox1.Items.Add(x);
                    }
                }
            }
            catch{ }
        }
        private void Install_prepar()
        {
            for (int i = Program.interduction; i < Program.intedic.Length; i++)
            {
                Program.cur[i] = Program.intedic[i].Split('>');
                this.Invoke((MethodInvoker)delegate
                {
                    log.Items.Add("[Info] " + Program.intedic[i].Substring(1));
                });

            }
            
            start_install();
            if (Program.error == 0)
            {
                surccess();
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    log.Items.Add("Installation With " + Program.error + " Errors finished!");
                });
                G_retry();
            }
        }
        public void start_install()
        {
            t_p();
            for (int c = Program.interduction; c < Program.intedic.Length; c++)
            {
                try
                {
                    if (!Directory.Exists(Path.GetDirectoryName(Program.installdir + "\\" + Program.cur[c][1])))
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            log.Items.Add("Creating Dyrectory: ["+ Path.GetDirectoryName(Program.installdir + "\\" + Program.cur[c][1])+"]");
                        });
                        Directory.CreateDirectory(Path.GetDirectoryName(Program.installdir + "\\" + Program.cur[c][1]));
                    }
                    File.Copy(Program.installfiles + "\\" + Program.cur[c][0].Substring(1), Program.installdir + "\\" + Program.cur[c][1], true);
                    this.Invoke((MethodInvoker)delegate
                    {
                        log.Items.Add("[Copy] " + Program.installfiles + "\\" + Program.cur[c][0].Substring(1) + "   =>   " + Program.installdir + "\\" + Program.cur[c][1]);
                    });
                }
                catch (Exception exp)
                {
                    if (exp.Message.ToLower() != "Der Index war außerhalb des Arraybereichs.".ToLower())
                    {
                        Program.error++;
                        this.Invoke((MethodInvoker)delegate
                        {
                            log.Items.Add("[Error]:" + exp.Message);
                        });
                    }
                }
            }
        }
        public void G_retry()
        {
            if (MessageBox.Show("Installation With " + Program.error + " Errors finished!\nRetry ?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Hand) == DialogResult.Yes)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    log.Items.Clear();
                });
                Program.er = true;
                Program.error = 0;
                Install_prepar();
            }
            
        }
        private void t_p()
        {

            StreamWriter WStream1 = new StreamWriter(Program.regfull, true);
            WStream1.WriteLine(Program.intedic[3]);
            WStream1.Close();
            File.Delete(Program.reg + @"\" + Program.intedic[3].Substring(1));
            StreamWriter WStream2 = new StreamWriter(Program.reg + @"\" + Program.intedic[3].Substring(1), true);
            WStream2.WriteLine(Program.intedic[0]);
            WStream2.WriteLine(Program.intedic[1]);
            WStream2.WriteLine(Program.intedic[2]);
            WStream2.WriteLine(Program.intedic[3]);
            WStream2.WriteLine("#" + Program.installdir);
            var fil = ("#" + Program.installdir + "\\" + Path.GetFileName(Program.installfile) +
                ("[" + DateTime.Now + "].inst").Replace('\\', '-').Replace('/', '-').Replace(':', '-').Replace('*', '-')
                .Replace('?', '-').Replace('<', '-').Replace('>', '-').Replace('|', '-'));
            WStream2.WriteLine(fil);
            WStream2.Close();
            if (!Directory.Exists(Path.GetDirectoryName(fil.Substring(1))))
            {
                this.Invoke((MethodInvoker) delegate
                {
                    log.Items.Add("Creating Dyrectory: [" + Path.GetDirectoryName(fil.Substring(1)) + "]");
                });
                Directory.CreateDirectory(Path.GetDirectoryName(fil.Substring(1)));
            }
            File.Copy(Program.installfile, fil.Substring(1), true);
        }
        public void surccess()
        {
            this.Invoke((MethodInvoker)delegate
            {
                log.Items.Add("Installation surccess!");
                B_back.Enabled = false;
                b_cancle.Text = "Finish";
                b_next.Enabled = false;
                this.button1.Visible = true;
            });
        }

        private void b_cancle_Click(object sender, EventArgs e)
        {
            Environment.Exit(Program.error);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                l.Close();
                l = new Log();
                l.Show();
                this.log = l.listBox1;
            }
            catch { }
        }

        private void B_back_Click(object sender, EventArgs e)
        {
            Program.page--;
        }
    }
}
