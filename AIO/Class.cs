using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

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

        public static void readfile()
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
        public static void CopyToSystemDir()
        {
            ///copy Applicatiom
            if (!Path.Equals(Path.GetDirectoryName(Application.ExecutablePath) + @"\", VAR.reg))
            {
                //dll
                if (File.Exists(VAR.dllfull))
                    try
                    {
                        Thread.Sleep(500);
                        Console.WriteLine("[DELET]: " + VAR.dllfull);
                        File.Delete(VAR.dllfull);
                    }
                    catch { }
                Thread.Sleep(500);
                Console.WriteLine("[COPY]: " + Path.GetDirectoryName(Application.ExecutablePath) + @"\" + VAR.dll + " --> " + VAR.dllfull);
                try { File.Copy(Path.GetDirectoryName(Application.ExecutablePath) + @"\" + VAR.dll, VAR.dllfull); }catch { }
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
                try { File.Copy(Application.ExecutablePath, VAR.reg + Path.GetFileName(Application.ExecutablePath)); } catch { }
                //exit
                Console.WriteLine("[Finished]");
                Thread.Sleep(2000);
                Console.WriteLine("[START]: " + VAR.reg + Path.GetFileName(Application.ExecutablePath));
                Thread.Sleep(1000);
                Process.Start(VAR.reg + Path.GetFileName(Application.ExecutablePath));
                Environment.Exit(+1);
            }
        }
    }
}
