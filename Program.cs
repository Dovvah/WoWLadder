using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace WoWLadder
{
    class Program
    {
        static void Main(string[] args)
        {
            string FolderPath = args[0];
            string[] AdtFiles = Directory.GetFiles(FolderPath);
            if (args.Length == 0)
                return;
            else
            {

                foreach (var file in AdtFiles)
                    if (file.Contains("_tex"))
                    {
                        Console.WriteLine("tex file found, ignoring" + file + Environment.NewLine);
                    }
                    else
                    if (file.Contains("_obj0"))
                    {
                        Console.WriteLine("obj0 file found, ignoring" + file + Environment.NewLine);
                    }
                    else
                    if (file.Contains("_obj1"))
                    {
                        Console.WriteLine("obj0 file found, processing." + file + Environment.NewLine);
                        using (Stream obj1stream = File.Open(file, FileMode.Open, FileAccess.ReadWrite)) 
                            using (BinaryReader obj1reader = new BinaryReader(obj1stream))
                            using (BinaryWriter obj1writer = new BinaryWriter(obj1stream))
                        {

                        }
                    }
                    else
                    {
                        Console.WriteLine("Normal .adt file found" + file + Environment.NewLine);
                    }
                Thread.Sleep(50000);
            }
           



        }
    }
}
