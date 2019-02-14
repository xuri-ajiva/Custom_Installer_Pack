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
        static string strg(string name,string strg)
        {
            return "" +
                "        public static string " +
                name +
                " = \"" +
                strg +
                "\";";
        }
        static string dec(string name)
        {
            return "" +
                "                File.Create(part + \"" + name.Replace("_",".") + "\").Close();\n" +
                "                File.WriteAllBytes(part + \"" + name.Replace("_", ".") + "\", Packer.GET_Strings.build(Packer.GET_Strings." + name + "));";
        }


        /*
         * 
         * 
         * 
            File.Create(pat + "AIO.dll").Close();
            File.WriteAllBytes(pat + "AIO.dll", Packer.GET_Strings.build(Packer.GET_Strings.AIO_dll));
         * 
         * 
         * 
         * 
         */
        public static List<string> items = new List<string>();

        static void Main(string[] args)
        {
            string Block_1 = "" +
                "//Generrated using Packer from Custom_Installers.\n//We are hoping the filenames do not contailn \"_\".\n//If this is the case this code shod not work\n" +
                "///Begin Code\n" +
                "using System;\n" +
                "using System.IO;\n" +
                "using System.Collections.Generic;\n" +
                "using System.Linq;\n" +
                "using System.Text;\n" +
                "using System.Threading.Tasks;\n" +
                "\n" +
                "namespace Packer {\n" +
                "    public class GET_Strings {\n";

            string Block_2 = "" +
                    "        public static Byte[] build(string data_hex) {\n" +
                    "            return FromHex(data_hex);\n" +
                    "        }\n" +
                    "        public static byte[] FromHex(string hex) {\n" +
                    "            hex = hex.Replace(\"-\", \"\");\n" +
                    "            byte[] raw = new byte[hex.Length / 2];\n" +
                    "            for (int i = 0; i < raw.Length; i++)\n" +
                    "                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);\n" +
                    "            return raw;\n" +
                    "        }\n" +
                    "        public static void DePackTo(string part)\n" +
                    "        {\n";
            string Block_3 = "" +
                "        }\n" +
                "    }\n" +
                "}\n" +
                "///End Code";

            if (args.Length >= 1)
            {
                Console.Write(Block_1);
                for (int arg = 0; arg < args.Length; arg++)
                {
                    var x = File.ReadAllBytes(args[arg]);
                    string r = BitConverter.ToString(x).Replace("-", string.Empty);
                    Console.WriteLine(strg(Path.GetFileName(args[arg]).Replace('.', '_').Replace(' ', '_'), r));
                }

                Console.WriteLine(Block_2);

                for (int arg = 0; arg < args.Length; arg++)
                {
                    Console.WriteLine(dec(Path.GetFileName(args[arg]).Replace('.', '_').Replace(' ', '_')));
                }
                Console.Write(Block_3);
            }
            else
            {
                string[] ar = { "AIO.dll", "\"Application Manager.exe\"", "Creator.exe", "Installer.exe" };
                Console.Write(
                    "/////////////////////////\n" +
                    "/// Erstelle Standart ///\n" +
                    "/////////////////////////\n");
                Thread.Sleep(2000);
                Process.Start("cmd", "/c " + Application.ExecutablePath + " AIO.dll ApplicationManager.exe Creator.exe Installer.exe >..\\Patch\\build.cs");
                Environment.Exit(-1);
            }
        }

        public static void DePackTo(string part)
        {
            for(int c = 0; c < items.Count; c++)
            {
                File.Create(part + c.ToString()).Close();
                File.WriteAllBytes(part + c.ToString(), Packer.GET_Strings.build(c.ToString()));
            }
        }

    }
    public class GET_Strings
    {
        public static Byte[] build(string data_hex)
        {
            return FromHex(data_hex);
        }
        public static byte[] FromHex(string hex)
        {
            hex = hex.Replace("-", "");
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            return raw;
        }
    }
}
