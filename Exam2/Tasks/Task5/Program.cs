using System;
using System.IO;
using System.Text;

namespace Task5
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dir = new DirectoryInfo("ref");
            string extra = "/Hello.txt";
            var parent = dir.Parent.Parent.Parent.Parent.FullName + extra;
            var parent2 = dir.Parent.Parent.Parent.Parent.FullName;

            var fileOneLoc = parent2 + "/Hello.txt";
            var fileTwoLoc = parent2 + "/Welcome.txt";

            if (File.Exists(parent))
            {
                File.Move($"{fileOneLoc}", $"{fileTwoLoc}");
            }

            using (FileStream fs = File.Create(parent))
            {
                byte[] information = Encoding.Unicode.GetBytes("Hello world from C#");
                fs.Write(information, 0, information.Length);
                fs.Flush();
            }
        }
    }
}
