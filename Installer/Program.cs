﻿using System;
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
using AIO;

namespace Installer
{
    class Program
    {

        public static Log Log { get; private set; }
        //*

        // # Start
        [STAThread]
        static void Main(string[] args)
        {
            //building programm dir
            Directory.CreateDirectory(VAR.reg);
            File.Open(VAR.regfull, FileMode.OpenOrCreate).Close();

            Console.Title = "OSVersion:\"" + Environment.OSVersion.ToString().ToLower() + "\" User:\"" + Environment.UserName.ToString().ToUpper() + "\" Programm:\"" + VAR.Name + "\"";
            Thread.Sleep(100);
         
            First();
            Reg();

            if (args.Length >= 1)
            {
                VAR.installfile = args[0];
                VAR.page = 2;
                VAR.min_page = 2;
                Dialog2.back = false;
            }

            run();

        }

        private static void Reg()
        {
            fas.FileAssociation.CreateAssociation("_Installer_custom_", "Installer", "C:\\Windows\\Installer_Custom\\Installer.exe", "inst", VAR.regiconfull);

            ///Build icon hex use '[application].exe >output.hex'
            //var x = File.ReadAllBytes(@"C:\Users\xuri\source\repos\Projekts\Custom_Installer_pack\Installer\installer.ico");
            //string r = BitConverter.ToString(x).Replace("-", string.Empty);
            //Console.WriteLine(r);
            ///*
            
            //build icon bytes
            Installer.iconcode.build();
            //create icon
            if (!File.Exists(VAR.regiconfull))
                File.Create(VAR.regiconfull);
            else
                File.WriteAllBytes(VAR.regiconfull, Installer.iconcode.icon_byte);
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
