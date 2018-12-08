using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Source_Engin_Moder
{
    public class code
    {/*
        public static void Dialog_Setup()
        {
            if (!Program.er)
            {
                Main_Dialog m = new Main_Dialog();
                if (m.ShowDialog() == System.Windows.Forms.DialogResult.OK)
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
                else { Program.error = -1; Environment.Exit(Program.error); }
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Info: " + Program.intedic[0].Substring(1));
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Download: " + Program.intedic[1].Substring(1));
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Version: " + Program.intedic[2].Substring(1));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Name: " + Program.intedic[3].Substring(1));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nInstallations Verzeichnis: " + Program.installdir);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (!Program.er)
            {
                Console.WriteLine("\nWollen Sie Mit der Installation Fortfahren? [y/N]");
                if (Console.ReadLine().ToLower() == "y")
                {


                    for (int i = Program.interduction; i < Program.intedic.Length; i++)
                    {
                        Program.cur[i] = Program.intedic[i].Split('>');
                    }
                    for (int c = Program.interduction; c < Program.intedic.Length; c++)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("[Info] ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(Program.intedic[c].Substring(1));
                    }

                    start_install();
                    if (Program.error == 0)
                    {
                        Console.WriteLine("Installation surccess! #1");
                    }
                    else
                    {
                        Console.WriteLine("Installation With {0} Errors finished!", Program.error);
                        retry();
                    }
                }
            }
            else
            {
                for (int i = Program.interduction; i < Program.intedic.Length; i++)
                {
                    Program.cur[i] = Program.intedic[i].Split('>');
                }
                for (int c = Program.interduction; c < Program.intedic.Length; c++)
                {
                    Console.WriteLine(Program.intedic[c].Substring(1));
                }

                start_install();
                if (Program.error == 0)
                {
                    Console.WriteLine("Installation surccess! #2");
                }
                else
                {
                    Console.WriteLine("Installation With {0} Errors finished!", Program.error);
                    retry();
                }
            }
            Console.ReadKey();
        }*/
        /*
        public static void retry()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nWollen sie erneut versuchen? [y/N]");
            if (Console.ReadLine() == "y")
            {
                Program.er = true;
                Program.error = 0;
                Dialog_Setup();
            }
            else { Environment.Exit(Program.error); }
        }
        */

        public static void start_install()
        {
            for (int c = Program.interduction; c < Program.intedic.Length; c++)
            {
                try
                {
                    if (!Directory.Exists(Path.GetDirectoryName(Program.installdir + "\\" + Program.cur[c][1])))
                    {
                        Console.WriteLine("Creating Dyrectory!");
                        Directory.CreateDirectory(Path.GetDirectoryName(Program.installdir + "\\" + Program.cur[c][1]));
                    }
                    File.Copy(Program.installfiles + "\\" + Program.cur[c][0].Substring(1), Program.installdir + "\\" + Program.cur[c][1],true);
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("[Copy] ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(Program.installfiles + "\\" + Program.cur[c][0].Substring(1) + " -> " + Program.installdir + "\\" + Program.cur[c][1]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (Exception exp)
                {
                    if (exp.Message.ToLower() != "Der Index war außerhalb des Arraybereichs.".ToLower())
                    {
                        Program.error++;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[Error]:" + exp.Message);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }
        }
        public static void debuck()
        {
            Console.WriteLine("installfile =" + Program.installfile + "installfiles =" + Program.installfiles + "   intedic=" + Program.intedic + "    installdir=" + Program.installdir);
        }

        public static void G_retry()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nWollen sie erneut versuchen? [y/N]");
            if (Console.ReadLine() == "y")
            {
                Console.Clear();
                Program.er = true;
                Program.error = 0;
                Dialog_install();
            }
            else { Environment.Exit(Program.error); }
        }
        public static void Dialog_install()
        {
            try
            {
                Program.intedic = File.ReadLines(Program.installfile).Where(x => x.StartsWith("#")).ToArray();
            }
            catch
            {
                Console.WriteLine("Error!");
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Info: " + Program.intedic[0].Substring(1));
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Download: " + Program.intedic[1].Substring(1));
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Version: " + Program.intedic[2].Substring(1));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Name: " + Program.intedic[3].Substring(1));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nInstallations Verzeichnis: " + Program.installdir);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (!Program.er)
            {
                Console.WriteLine("\nWollen Sie Mit der Installation Fortfahren? HIERBEI WERDEN DATEIEN IM ZIELVERZEICHNIS ÜBERSCHIREBEN! [y/N]");
                if (Console.ReadLine().ToLower() == "y")
                {
                    Install_prepar();
                }
            }
            else
            {
                Install_prepar();
            }
            Console.WriteLine("End Of Code! Try recall Method if you have no surccess");
            Console.ReadKey();
        }
        private static void Install_prepar()
        {
            for (int i = Program.interduction; i < Program.intedic.Length; i++)
            {
                Program.cur[i] = Program.intedic[i].Split('>');
            }
            for (int c = Program.interduction; c < Program.intedic.Length; c++)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("[Info] ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Program.intedic[c].Substring(1));
            }

            start_install();
            if (Program.error == 0)
            {
                Console.WriteLine("Installation surccess! #4");
                surccess();
            }
            else
            {
                Console.WriteLine("Installation With {0} Errors finished!", Program.error);
                G_retry();
            }
        }
        public static void surccess()
        {
            StreamWriter WStream1 = new StreamWriter(Program.regfull, true);
            WStream1.WriteLine(Program.intedic[3]);
            WStream1.Close();
            File.Delete(Program.reg + @"\" + Program.intedic[3].Substring(1));
            StreamWriter WStream2 = new StreamWriter(Program.reg+@"\"+Program.intedic[3].Substring(1), true);
            WStream2.WriteLine(Program.intedic[0]);
            WStream2.WriteLine(Program.intedic[1]);
            WStream2.WriteLine(Program.intedic[2]);
            WStream2.WriteLine(Program.intedic[3]);
            WStream2.WriteLine("#"+Program.installdir);
            var fil = ("#" + Program.installdir +"\\" + Path.GetFileName(Program.installfile) + 
                ("[" + DateTime.Now + "].inst").Replace('\\', '-').Replace('/', '-').Replace(':', '-').Replace('*', '-')
                .Replace('?', '-').Replace('<', '-').Replace('>', '-').Replace('|', '-'));
            WStream2.WriteLine(fil);
            WStream2.Close();
            File.Copy(Program.installfile, fil.Substring(1),true);
            Thread.Sleep(3000);
            Environment.Exit(0);
        }
    }
}
