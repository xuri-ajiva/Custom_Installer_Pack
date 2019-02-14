using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patch
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static void Install()
        {
            var pat = Path.GetDirectoryName(Application.ExecutablePath) + @"\tmp\";

            Directory.CreateDirectory(pat);

            Packer.GET_Strings.DePackTo(pat);
            
            //File.Create(pat + "Application Manager.exe").Close();
            //File.Create(pat + "Creator.exe").Close();
            //File.Create(pat + "Installer.exe").Close();
            //File.Create(pat + "AIO.dll").Close();
            //
            //File.WriteAllBytes(pat + "Application Manager.exe", Packer.GET_Strings.build(Packer.GET_Strings.Application_Manager_exe));
            //File.WriteAllBytes(pat + "Creator.exe", Packer.GET_Strings.build(Packer.GET_Strings.Creator_exe));
            //File.WriteAllBytes(pat + "Installer.exe", Packer.GET_Strings.build(Packer.GET_Strings.Installer_exe));
            //File.WriteAllBytes(pat + "AIO.dll", Packer.GET_Strings.build(Packer.GET_Strings.AIO_dll));

            Process.Start(pat + "ApplicationManager.exe");
            Thread.Sleep(3000);
            Process.Start("taskkill", "/IM \"ApplicationManager.exe\" /f");
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
            MessageBox.Show("Instalation erfolgreich!");
        }

        internal static void UnInstall()
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
