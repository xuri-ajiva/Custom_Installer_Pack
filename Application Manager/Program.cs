using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIO;

namespace Application_Manager
{
    static class Program
    {

        [STAThread]
        static void Main()
       {
            First();
            Application.Run(new Form1());
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
