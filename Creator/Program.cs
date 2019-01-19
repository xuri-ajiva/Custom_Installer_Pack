using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIO;

namespace Creator
{
    static class Program
    {
        
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            First();
            Application.Run(new Main());
        }

        private static void First()
        {
            //building programm dir
            Directory.CreateDirectory(VAR.reg);
            File.Open(VAR.regfull, FileMode.OpenOrCreate).Close();
            
            VAR.CopyToSystemDir();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //# hide console
            var handle = VAR.GetConsoleWindow();
            VAR.ShowWindow(handle, VAR.SW_HIDE);
        }

    }
}
