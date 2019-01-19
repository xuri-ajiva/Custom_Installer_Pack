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
                Console.WriteLine("[START]: " + VAR.reg + Path.GetFileName(Application.ExecutablePath));
                Thread.Sleep(1000);
                Process.Start(VAR.reg + Path.GetFileName(Application.ExecutablePath));
                Environment.Exit(+1);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //# hide console
            var handle = VAR.GetConsoleWindow();
            VAR.ShowWindow(handle, VAR.SW_HIDE);
        }
    }
}
