using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var pat = Path.GetDirectoryName(Application.ExecutablePath) + @"\tmp\";

            Directory.CreateDirectory(pat);

            File.Create(pat + "Application Manager.exe").Close();
            File.Create(pat + "Creator.exe").Close();
            File.Create(pat + "Installer.exe").Close();
            File.Create(pat + "AIO.dll").Close();

            File.WriteAllBytes(pat + "Application Manager.exe", Strings.build(Strings.Application_Manager_exe));
            File.WriteAllBytes(pat + "Creator.exe", Strings.build(Strings.Creator_exe));
            File.WriteAllBytes(pat + "Installer.exe", Strings.build(Strings.Installer_exe));
            File.WriteAllBytes(pat + "AIO.dll", Strings.build(Strings.AIO_dll));

            Process.Start(pat + "Application Manager.exe");
            Thread.Sleep(3000);
            Process.Start("taskkill", "/IM \"Application Manager.exe\" /f");
            Process.Start(pat + "Creator.exe");
            Thread.Sleep(3000);
            Process.Start("taskkill", "/IM Creator.exe /f");
            Process.Start(pat + "Installer.exe");
            Thread.Sleep(6000);
            Process.Start("taskkill", "/IM Installer.exe /f");
            Thread.Sleep(1000);
            Process.Start(@"C:\Windows" + @"\Installer_Custom\" + "Installer.exe");
            Thread.Sleep(2000);
            Process.Start("taskkill", "/IM Installer.exe /f");

            fas.FileAssociation.CreateAssociation("_Installer_custom_", "Installer", "C:\\Windows\\Installer_Custom\\Installer.exe", "inst", "C:\\Windows\\Installer_Custom\\Installer.ico");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button3_Click(null, null);
            button1_Click(null, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Directory.Delete(@"C:\Windows" + @"\Installer_Custom\", true);
            }
            catch { }
            fas.FileAssociation.DeleteAssociation("_Installer_custom_", "inst");
            MessageBox.Show("Uninstall surccess!");
        }
    }
}
