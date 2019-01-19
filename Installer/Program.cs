using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Win32;
using System.Security;
using System.Collections;
using AIO;

namespace Installer
{
    class Program
    {

        public static Log Log { get; private set; }
        //*

        // # Start
        [STAThread]
        static void Main(string[] args)
        {
            Console.Title = "OSVersion:\"" + Environment.OSVersion.ToString().ToLower() + "\" User:\"" + Environment.UserName.ToString().ToUpper() + "\" Programm:\"" + VAR.Name + "\"";
            Thread.Sleep(100);
         
            First();
            Reg();

            if (args.Length >= 1)
            {
                VAR.installfile = args[0];
                VAR.page = 2;
                VAR.min_page = 2;
                Dialog2.back = false;
            }

            run();

        }

        private static void Reg()
        {
            fas.FileAssociation.CreateAssociation("_Installer_custom_", "Installer", "C:\\Windows\\SysWOW64\\Installer_Custom\\Installer.exe", "inst", VAR.regiconfull);

            ///Build icon hex use '[application].exe >output.hex'
            //var x = File.ReadAllBytes(@"C:\ProgramData\Microsoft\Windows\DeviceMetadataCache\dmrccache\en-US\6dad89d3-68a4-4000-acc2-f7ac969847cd\DeviceStage\Task\{05f68c0e-d993-4e8e-b40b-c8f9c013510d}\task_icon_11.ico");
            //string r = BitConverter.ToString(x).Replace("-", string.Empty);
            //Console.WriteLine(r);
            ///*

            //build icon bytes
            Installer.iconcode.build();
            //create icon
            if (!File.Exists(VAR.regiconfull))
                File.Create(VAR.regiconfull);
            else
                File.WriteAllBytes(VAR.regiconfull, Installer.iconcode.icon_byte);
            //set icon in regestry
        }

        private static void First()
        {
            //building programm dir
            Directory.CreateDirectory(VAR.reg);
            File.Open(VAR.regfull, FileMode.OpenOrCreate).Close();

            ///copy Applicatiom
            if (!Path.Equals(Path.GetDirectoryName(Application.ExecutablePath) + @"\", VAR.reg))
            {
                //dll
                if (File.Exists(VAR.dllfull))
                    try
                    {
                        Thread.Sleep(500);
                        Console.WriteLine("[DELET]: "+ VAR.dllfull);
                        File.Delete(VAR.dllfull);
                    }
                    catch { }
                Thread.Sleep(500);
                Console.WriteLine("[COPY]: "+ Path.GetDirectoryName(Application.ExecutablePath) + @"\" + VAR.dll+" --> "+ VAR.dllfull);
                File.Copy(Path.GetDirectoryName(Application.ExecutablePath) + @"\" + VAR.dll, VAR.dllfull);
                //programm
                if (File.Exists(VAR.reg + Path.GetFileName(Application.ExecutablePath)))
                    try
                    {
                        Thread.Sleep(500);
                        Console.WriteLine("[DELET]: " + VAR.reg + Path.GetFileName(Application.ExecutablePath));
                        File.Delete(VAR.reg + Path.GetFileName(Application.ExecutablePath));
                    }
                    catch { }
                Thread.Sleep(500);
                Console.WriteLine("[COPY]: " + Application.ExecutablePath + " --> " + VAR.reg + Path.GetFileName(Application.ExecutablePath));
                File.Copy(Application.ExecutablePath, VAR.reg + Path.GetFileName(Application.ExecutablePath));
                //exit
                Console.WriteLine("[Finished]");
                Thread.Sleep(2000);
                Console.WriteLine("[START]: "+ VAR.reg + Path.GetFileName(Application.ExecutablePath));
                Thread.Sleep(1000);
                Process.Start(VAR.reg + Path.GetFileName(Application.ExecutablePath));
                Environment.Exit(+1);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //# hide console
            var handle = VAR.GetConsoleWindow();
            VAR.ShowWindow(handle, VAR.SW_HIDE);

            Log = new Log();
        }


        static void run()
        {
            while (true)
            {
                Application.Run(new Host_dialog());
            }
        }
    }
}
