using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsUtils
{
    class Program
    {
        static string ReverseString(string inputString)
        {
            var reverseArray = inputString.Reverse().ToArray();
            return new string(reverseArray);
        }

        static void SearchMail(ref string s)
        {
            int posAmpersand = s.IndexOf('&');
            string ss = s.Substring(posAmpersand + 1, s.Length - posAmpersand - 1);
            s = ss;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(ReverseString("1234567890"));

            var lines = File.ReadAllLines("mailbook.txt");
            string[] mails = new string[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string s = lines[i];
                SearchMail(ref s);
                mails[i] = s;
            }
            File.WriteAllLines("mails.txt", mails);
            Console.ReadKey();
        }
    }
}
