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
            //list all files
            for (int i = VAR.interduction; i < VAR.intedic.Length; i++)
            {
                VAR.cur[i] = VAR.intedic[i].Split('>');
                this.Invoke((MethodInvoker)delegate
                {
                    log.Items.Add("[Info] " + VAR.intedic[i].Substring(1));
                });
            }
            
            //Copy files
            start_install();

            if (VAR.error == 0)
            {
                //finish process
                surccess();
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    log.Items.Add("Installation With " + VAR.error + " Errors finished!");
                });
                //ask for retry
                G_retry();
            }
        }
        public void start_install()
        {
            //extract files
            Extract_7zip();
            //copy  uninstall file to install dir
            t_p();
            //Copy all files To Install dir
            Copy_Files();
        }
        private void Extract_7zip()
        {
            return;
        }
        private void Copy_Files()
        {
            for (int c = VAR.interduction; c < VAR.intedic.Length; c++)
            {
                try
                {
                    //check directory
                    string directory = Path.GetDirectoryName(VAR.installdir + "\\" + VAR.cur[c][1]);
                    if (!Directory.Exists(directory))
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            log.Items.Add("Creating Dyrectory: [" + directory + "]");
                        });
                        Directory.CreateDirectory(directory);
                    }

                    //copy file
                    string dir1 = VAR.installfiles + "\\" + VAR.cur[c][0].Substring(1);
                    string dir2 = VAR.installdir + "\\" + VAR.cur[c][1];
                    File.Copy(dir1, dir2, true);
                    this.Invoke((MethodInvoker)delegate
                    {
                        log.Items.Add("[Copy] " + dir1 + "   =>   " + dir2);
                    });
                }
                catch (Exception exp)
                {
                    Exeption_Call(exp);
                }
            }
        }
        public void G_retry()
        {
            //ask for retry
            var r = MessageBox.Show("Installation With " + VAR.error + " Errors finished!\nRetry ?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Hand);
            //yes
            if (r == DialogResult.Yes)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    log.Items.Clear();
                });
                VAR.er = true;
                VAR.error = 0;
                Install_prepar();
            }
            //no
            else if (r == DialogResult.No)
            {
                //finish installer
                surccess();
            }
            
        }
        //copy  uninstall file to install dir
        private void t_p()
        {
            //no comment!
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
            //finish installer
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
        private void Exeption_Call(Exception e)
        {
            //check exeption and print to screen
            if (e.Message.ToLower() != "Der Index war außerhalb des Arraybereichs.".ToLower())
            {
                VAR.error++;
                this.Invoke((MethodInvoker)delegate
                {
                    log.Items.Add("[Error]:" + e.Message);
                });
            }
        }
    }
}
