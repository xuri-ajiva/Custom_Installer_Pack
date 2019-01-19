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

namespace Installer
{
    class Program
    {
        /// <summary>
        /// 

        public static string Name = "Installer";

        /// 
        /// </summary>
        //# reg
        public static string reg = @"C:\Windows\SysWOW64" + @"\Installer_Custom\";
        public static string regname = "install.inst";
        public static string regiconname = "installer.ico";
        public static string regfull = reg + regname;
        public static string regiconfull = reg + regiconname;

        //# install vars
        public static string installfile = "";
        public static string installdir = "";
        public static string installfiles = "";

        //# buffer
        public static string[] intedic = new string[9999];
        public static string[][] cur = new string[9999][];
        public static int interduction = 5;

        //# errror and ui controal
        public static int error = 0;
        public static bool er = false;
        public static int page = 1;
        public static int min_page = 0;
        
        //# Dependensis
        //* Kernel imports
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public const int SW_HIDE = 0;
        public const int SW_SHOW = 5;

        internal static void readfile()
        {
            try
            {
                Program.intedic = File.ReadLines(Program.installfile).Where(x => x.StartsWith("#")).ToArray();
            }
            catch
            {
                Console.WriteLine("Error!");
            }
        }

        public static Log Log { get; private set; }
        //*

        // # Start
        [STAThread]
        static void Main(string[] args)
        {
            fas.FileAssociation.CreateAssociation("_Installer_custom_","Installer", "C:\\Windows\\SysWOW64\\Installer_Custom\\Installer.exe","inst",regiconfull);
            
            First();
            Reg();


            
            Console.Title = "OSVersion:\"" + Environment.OSVersion.ToString().ToLower() + "\" User:\"" + Environment.UserName.ToString().ToUpper() + "\" Programm:\"" + Name+"\"";
            Thread.Sleep(100);

            //# hide console
            var handle = GetConsoleWindow();
            //ShowWindow(handle, SW_HIDE);

            if (args.Length >= 1)
            {
                installfile = args[0];
                Program.page = 2;
                Program.min_page = 2;
                Dialog2.back = false;
            }

            run();

        }

        private static void Reg()
        {
            
            /*
            Org.Mentalis.Utilities.FileAssociation FA = new Org.Mentalis.Utilities.FileAssociation();
            FA.Extension = "inst";
            FA.IconPath = regiconfull;
            FA.ContentType = "application/Installer";
            FA.FullName = "Instalazionsanweisungdatei";
            FA.ProperName = "inst File";
            FA.AddCommand("open", Application.ExecutablePath);
            //FA.Create();
            // Remove the file type from the registry
            FA.Remove();
            */
            ///Build icon hex use '[application].exe >output.hex'
            //var x = File.ReadAllBytes(@"C:\ProgramData\Microsoft\Windows\DeviceMetadataCache\dmrccache\en-US\6dad89d3-68a4-4000-acc2-f7ac969847cd\DeviceStage\Task\{05f68c0e-d993-4e8e-b40b-c8f9c013510d}\task_icon_11.ico");
            //string r = BitConverter.ToString(x).Replace("-", string.Empty);
            //Console.WriteLine(r);
            ///*


            //build icon bytes
            Installer.iconcode.build();
            //create icon
            if (!File.Exists(regiconfull))
                File.Create(regiconfull);
            else
                File.WriteAllBytes(regiconfull, Installer.iconcode.icon_byte);
            //set icon in regestry
        }

        private static void First()
        {
            //building programm dir
            Directory.CreateDirectory(Program.reg);
            File.Open(Program.regfull, FileMode.OpenOrCreate).Close();

            if (!Path.Equals(Path.GetDirectoryName(Application.ExecutablePath)+@"\",reg))
            {
                if (File.Exists(reg + Path.GetFileName(Application.ExecutablePath)))
                    try { File.Delete(reg + Path.GetFileName(Application.ExecutablePath)); }catch { }
                File.Copy(Application.ExecutablePath, reg + Path.GetFileName(Application.ExecutablePath));
                Process.Start(reg + Path.GetFileName(Application.ExecutablePath));
                Environment.Exit(+1);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


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
