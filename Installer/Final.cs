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
using AIO;


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
                if (VAR.installdir != para && VAR.installfile != para && VAR.installfiles != para)
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
            VAR.readfile();
            update.Start();
        }
        
        private void update_Tick(object sender, EventArgs e)
        {
            try
            {
                label1.Text = "Info: " + VAR.intedic[0].Substring(1);
                label2.Text = "Download: " + VAR.intedic[1].Substring(1);
                label3.Text = "Version: " + VAR.intedic[2].Substring(1);
                label4.Text = "Name: " + VAR.intedic[3].Substring(1);
                label5.Text = "\nInstallations Verzeichnis: " + VAR.installdir;
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
            for (int i = VAR.interduction; i < VAR.intedic.Length; i++)
            {
                VAR.cur[i] = VAR.intedic[i].Split('>');
                this.Invoke((MethodInvoker)delegate
                {
                    log.Items.Add("[Info] " + VAR.intedic[i].Substring(1));
                });

            }
            
            start_install();
            if (VAR.error == 0)
            {
                surccess();
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    log.Items.Add("Installation With " + VAR.error + " Errors finished!");
                });
                G_retry();
            }
        }
        public void start_install()
        {
            t_p();
            for (int c = VAR.interduction; c < VAR.intedic.Length; c++)
            {
                try
                {
                    if (!Directory.Exists(Path.GetDirectoryName(VAR.installdir + "\\" + VAR.cur[c][1])))
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            log.Items.Add("Creating Dyrectory: ["+ Path.GetDirectoryName(VAR.installdir + "\\" + VAR.cur[c][1])+"]");
                        });
                        Directory.CreateDirectory(Path.GetDirectoryName(VAR.installdir + "\\" + VAR.cur[c][1]));
                    }
                    File.Copy(VAR.installfiles + "\\" + VAR.cur[c][0].Substring(1), VAR.installdir + "\\" + VAR.cur[c][1], true);
                    this.Invoke((MethodInvoker)delegate
                    {
                        log.Items.Add("[Copy] " + VAR.installfiles + "\\" + VAR.cur[c][0].Substring(1) + "   =>   " + VAR.installdir + "\\" + VAR.cur[c][1]);
                    });
                }
                catch (Exception exp)
                {
                    if (exp.Message.ToLower() != "Der Index war außerhalb des Arraybereichs.".ToLower())
                    {
                        VAR.error++;
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
            if (MessageBox.Show("Installation With " + VAR.error + " Errors finished!\nRetry ?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Hand) == DialogResult.Yes)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    log.Items.Clear();
                });
                VAR.er = true;
                VAR.error = 0;
                Install_prepar();
            }
            
        }
        private void t_p()
        {

            StreamWriter WStream1 = new StreamWriter(VAR.regfull, true);
            WStream1.WriteLine(VAR.intedic[3]);
            WStream1.Close();
            File.Delete(VAR.reg + @"\" + VAR.intedic[3].Substring(1));
            StreamWriter WStream2 = new StreamWriter(VAR.reg + @"\" + VAR.intedic[3].Substring(1), true);
            WStream2.WriteLine(VAR.intedic[0]);
            WStream2.WriteLine(VAR.intedic[1]);
            WStream2.WriteLine(VAR.intedic[2]);
            WStream2.WriteLine(VAR.intedic[3]);
            WStream2.WriteLine("#" + VAR.installdir);
            var fil = ("#" + VAR.installdir + "\\" + Path.GetFileName(VAR.installfile) +
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
            File.Copy(VAR.installfile, fil.Substring(1), true);
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
            Environment.Exit(VAR.error);
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
            VAR.page--;
        }
    }
}
