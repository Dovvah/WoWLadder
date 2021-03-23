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
                foreach (var file in AdtFiles.GetFiles( "*.adt"))
                {
                    Console.WriteLine(file.Name + Environment.NewLine);
                    

                }
                Thread.Sleep(50000);
            }
           



        }
    }
}
