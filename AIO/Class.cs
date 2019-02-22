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
        public static string reg = @"C:\Windows" + @"\Installer_Custom\";
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

        public static string[] regedit = new string[9999];
        public static string[][] regeditcur = new string[9999][];

        public static string[] execute = new string[9999];
        public static string[][] executecur = new string[9999][];

        public static string[] _7_zip = new string[9999];
        public static string[][] _7_zipcur = new string[9999][];

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
            catch (Exception ex)
            {
                Console.WriteLine("[ERROR]: " + ex.Message);
            }
            try
            {
                VAR.execute = File.ReadLines(VAR.installfile).Where(x => x.StartsWith("!")).ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ERROR]: " + ex.Message);
            }
            try
            {
                VAR._7_zip = File.ReadLines(VAR.installfile).Where(x => x.StartsWith("?")).ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ERROR]: " + ex.Message);
            }
            Spit_Lines();
        }

        public static void Spit_Lines()
        {
            for (int i = VAR.interduction; i < VAR.intedic.Length; i++)
            {
                VAR.cur[i] = VAR.intedic[i].Split('>');
                Console.WriteLine("[Info]: " + VAR.intedic[i].Substring(1));
            }
            for (int i = 0; i < VAR.execute.Length; i++)
            {
                VAR.executecur[i] = VAR.execute[i].Split('>');
                Console.WriteLine("[Info]: " + VAR.execute[i].Substring(1));
            }
            for (int i = 0; i < VAR._7_zip.Length; i++)
            {
                VAR._7_zipcur[i] = VAR._7_zip[i].Split('>');
                Console.WriteLine("[Info]: " + VAR._7_zip[i].Substring(1));
            }
        }

        public static void CopyToSystemDir()
        {
            ///copy Applicatiom
            if (!Path.Equals(Path.GetDirectoryName(Application.ExecutablePath) + @"\", VAR.reg))
            {

                //dll
                string current_dll = Path.GetDirectoryName(Application.ExecutablePath) + @"\" + VAR.dll;

                if (File.Exists(VAR.dllfull))
                    if (!FileCompare(VAR.dllfull, current_dll))
                        try
                        {
                            Thread.Sleep(500);
                            Console.WriteLine("[DELET]: " + VAR.dllfull);
                            File.Delete(VAR.dllfull);

                            Thread.Sleep(500);
                            copy_with_log(current_dll, VAR.dllfull);
                        }
                        catch { }
                    else
                    { }
                else
                {
                    copy_with_log(current_dll, VAR.dllfull);
                }

                //programm
                string dest_exec = VAR.reg + Path.GetFileName(Application.ExecutablePath);

                if (File.Exists(dest_exec))
                    if (!FileCompare(dest_exec, Application.ExecutablePath))
                        try
                        {
                            Thread.Sleep(500);
                            Console.WriteLine("[DELET]: " + dest_exec);
                            File.Delete(dest_exec);

                            Thread.Sleep(500);
                            copy_with_log(Application.ExecutablePath, dest_exec);
                        }
                        catch { }
                    else
                    { }
                else
                {
                    copy_with_log(Application.ExecutablePath, dest_exec);
                }

                //exit
                Console.WriteLine("[Finished]");
                Thread.Sleep(2000);
                Console.WriteLine("[START]: " + VAR.reg + Path.GetFileName(Application.ExecutablePath));
                Thread.Sleep(1000);
                Process.Start(VAR.reg + Path.GetFileName(Application.ExecutablePath));
                Thread.Sleep(10);
                Environment.Exit(0);
            }
        }
        public static void copy_with_log(string source, string dest)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[COPY]: " + source + " --> " + dest);
            try
            { File.Copy(source, dest); }
            catch (Exception e) { Console.WriteLine("[ERROR]: " +e.Message); }
        }
        private static bool FileCompare(string file1, string file2)
        {
            FileStream fs1;
            FileStream fs2;

            // Determine if the same file was referenced two times.
            if (file1 == file2)
            {
                // Return true to indicate that the files are the same.
                return true;
            }

            // Open the two files.

            File.Copy(file2, file2 + "_test", true);
            File.Copy(file1, file1 + "_test",true);

            file1 += "_test";
            file2 += "_test";

            fs1 = new FileStream(file1, FileMode.Open);
            fs2 = new FileStream(file2, FileMode.Open);

            // Check the file sizes. If they are not the same, the files 
            // are not the same.
            if (fs1.Length != fs2.Length)
            {
                // Close the file
                fs1.Close();
                fs2.Close();

                File.Delete(file1);
                File.Delete(file2);

                // Return false to indicate files are different
                return false;
            }
            bool s = (fs1.GetHashCode() == fs2.GetHashCode());

            fs1.Close();
            fs2.Close();

            File.Delete(file1);
            File.Delete(file2);

            return !s;
        }

    }
}
