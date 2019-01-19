using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace AIO
{
    public static class VAR
    {
        /// <summary>
        /// 

        public static string Name = "Installer";

        /// 
        /// </summary>
        //# reg
        public static string reg = @"C:\Windows\SysWOW64" + @"\Installer_Custom\";
        public static string dll = "AIO.dll"; 
        public static string regname = "install.inst";
        public static string regiconname = "installer.ico";
        public static string regfull = reg + regname;
        public static string regiconfull = reg + regiconname;
        public static string dllfull = reg + dll;

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
                VAR.intedic = File.ReadLines(VAR.installfile).Where(x => x.StartsWith("#")).ToArray();
            }
            catch(Exception ex)
            {
                Console.WriteLine("[ERROR]: "+ex.Message);
            }
        }
    }
}
