using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypto
{
    public class DES
    {
        int[] key = new int[64];
        byte[] binaryText;
        
        byte[] ReadFile(string path)
        {
            byte[] bytes = File.ReadAllBytes(path);
            return bytes;
        }
        
        byte[] StrToBin(string text)
        {
            Encoding encoding = Encoding.UTF8;
            byte[] bytes = encoding.GetBytes(text);
            return bytes;
        }
        
    }

}
