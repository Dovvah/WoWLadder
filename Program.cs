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
            DirectoryInfo AdtFiles = new DirectoryInfo(FolderPath);
            if (args.Length == 0)
                return;
            else
            {

                foreach (var file in AdtFiles.GetFiles("*.adt"))
                    if (file.Name.Contains("_tex"))
                    {


                        Console.WriteLine("Found _tex " + file.Name + Environment.NewLine);
                    
                       
                    }
                    else
                    if (file.Name.Contains("_obj"))
                    {
                        Console.WriteLine(file.Name + "obj file found" +  Environment.NewLine);


                    }
                else
                    {
                        Console.WriteLine("Normal .adt file found" + file.Name + Environment.NewLine);
                    }
                Thread.Sleep(50000);
            }
           



        }
    }
}
