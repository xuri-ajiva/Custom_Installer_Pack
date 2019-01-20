using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packer {
    public class Installer.exe {
        public static Byte[] build(string data_hex)
            return FromHex(data_hex);
        public static byte[] FromHex(string hex){
            hex = hex.Replace("-", "");
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            return raw;
        }
    }
}