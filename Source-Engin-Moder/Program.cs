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

namespace Source_Engin_Moder
{
    class Program
    {
        /// <summary>
        /// 

        public static string Name = "Source-Engin-Moder";

        /// 
        /// </summary>

        public static string reg = Environment.SystemDirectory + @"\Installer_Custom\";
        public static string regname = "install.inst";
        public static string regfull = reg + regname;
        public static string[][] cur = new string[9999][];
        public static string installfile = "slect!";
        public static string installdir = "slect!";
        public static string[] intedic = new string[9999];
        public static string installfiles = "slect!";
        public static int error = 0;
        public static bool er = false;
        public static int page = 1;

        public static int interduction = 5;

        public static Dialog01 d1 = new Dialog01();
        public static Dialog02 d2 = new Dialog02();
        public static Dialog03 d3 = new Dialog03();
        public static Log log = new Log();

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public const int SW_HIDE = 0;
        public const int SW_SHOW = 5;

        [STAThread]
        static void Main(string[] args)
        {

                Directory.CreateDirectory(Program.reg);
                File.Open(Program.regfull, FileMode.OpenOrCreate).Close();

            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            
            Console.Title = "OSVersion:\"" + Environment.OSVersion.ToString().ToLower() + "\" User:\"" + Environment.UserName.ToString().ToUpper() + "\" Programm:\"" + Name+"\"";
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);

            Thread t = new Thread(() =>
            {
                while (true)
                {
                    Console.WriteLine(Program.page);
                    Thread.Sleep(100);
                }
            });
            //t.Start();

            run();

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
