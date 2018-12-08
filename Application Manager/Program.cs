using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application_Manager
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        /// 

        public static string reg = Environment.SystemDirectory + @"\Installer_Custom\";
        public static string regname = "install.inst";
        public static string regfull = reg + regname;
        public static string[][] cur = new string[9999][];
        public static string[] intedic = new string[9999];
        public static string[] fiel = new string[9999];
        public static int error = 0;
        public static bool er = false;

        public static int interduction = 5;
        [STAThread]
        static void Main()
       {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
