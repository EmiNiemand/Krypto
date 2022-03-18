using System;
using System.Collections;
using System.Windows.Forms;

namespace Krypto
{
    internal static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            DES des = new DES();

            string txt = "dupa";
            string key = "abcdefgh";

            byte[] crypto = des.Cipher2(txt, key);

            string scrypto = des.BytesToString(crypto);

            string final = des.Decipher2(crypto, key);

            string crypt = des.Cipher(txt, key);
            string decrypt = des.Decipher(crypt, key);

        }
    }
}
