using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Packer
{
    class Program
    {
        public static string part = "";
        static void Main(string[] args)
        {
            ///Build icon hex use '[application].exe >output.hex'
            //var x = File.ReadAllBytes(@"C:\Users\xuri\source\repos\Projekts\Custom_Installer_pack\Installer\installer.ico");
            //string r = BitConverter.ToString(x).Replace("-", string.Empty);
            //Console.WriteLine(r);
            ///*
            Console.WriteLine("//Generrated using Packer from Custom_Installers\n///Begin Code");
            Console.WriteLine("using System;\nusing System.Collections.Generic;\nusing System.Linq;\nusing System.Text;\nusing System.Threading.Tasks;\n");
            Console.WriteLine("namespace Packer {");
            Console.WriteLine("    public class " + "GET_Strings" + " {");
            if (args.Length >= 1)
            {
                for (int arg = 0; arg < args.Length; arg++)
                {
                    var x = File.ReadAllBytes(args[arg]);
                    string r = BitConverter.ToString(x).Replace("-", string.Empty);
                    Console.WriteLine("        public static string " + Path.GetFileName(args[arg]).Replace('.', '_').Replace(' ', '_') + " = \"" + r + "\";");
                }
            }
            else
            {
                string[] ar = { "AIO.dll", "\"Application Manager.exe\"", "Creator.exe", "Installer.exe" };
                Console.WriteLine("/////////////////////\n/// Erstelle Standart\n/////////////////////");
                Thread.Sleep(2000);
                Process.Start("cmd", "/c " + Application.ExecutablePath + " AIO.dll \"Application Manager.exe\" Creator.exe Installer.exe >build.cs");
                Environment.Exit(-1);
            }
            Console.Write("        public static Byte[] build(string data_hex) {\n            return FromHex(data_hex);\n        }\n        public static byte[] FromHex(string hex) {\n            hex = hex.Replace(\"-\", \"\");\n            byte[] raw = new byte[hex.Length / 2];\n            for (int i = 0; i < raw.Length; i++)\n                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);\n            return raw;\n        }\n");
            Console.WriteLine("    }\n}\n///End Code");
        }
    }
}
