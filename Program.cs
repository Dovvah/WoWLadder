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
            //string FolderPath = "C:\\Users\\Tim\\Desktop\\Desktop\\6.0.1.18125 casc explorer\\World\\Maps\\AbyssalMaw - Copy (4)";
            string[] AdtFiles = Directory.GetFiles(FolderPath);
            if (args.Length == 0)
                return;
            else
            {

                foreach (var file in AdtFiles)

                {
                    using (Stream obj1stream = File.Open(file, FileMode.Open, FileAccess.ReadWrite))
                    using (BinaryReader obj1reader = new BinaryReader(obj1stream))
                    using (BinaryWriter obj1writer = new BinaryWriter(obj1stream))
                    {
                        if (file.Contains(".wdl"))
                        {

                        }
                        else
                        if (file.Contains(".wdt"))
                        {

                        }
                        else
                        if (file.Contains("tex"))
                        {
                            //  Console.WriteLine("tex file found, ignoring" + file + Environment.NewLine);
                        }
                        else
                        if (file.Contains("_obj0"))
                        {
                            bool modf_seen = false;
                            bool mddf_seen = false;


                            int counter_read_float = 0;
                            Console.WriteLine("obj0 file found, processing." + file + Environment.NewLine);




                            while (obj1reader.BaseStream.Position != obj1reader.BaseStream.Length)
                            {

                                // 1297040454 modf

                                var magic = obj1reader.ReadUInt32();

                                var size = obj1reader.ReadUInt32();
                                var pos = obj1reader.BaseStream.Position;

                                if (magic == 1296319558)
                                {
                                    while (obj1reader.BaseStream.Position < pos + size)
                                    {
                                        Console.WriteLine("MDDF = TRUE");
                                        mddf_seen = true;
                                        var mddf_nameid = obj1reader.ReadUInt32();
                                        var mddf_uniqueid = obj1reader.ReadUInt32();
                                        float mddf_pos_x = obj1reader.ReadSingle();
                                        var mddf_pos_y = obj1reader.ReadSingle();
                                        var new_m2_height = mddf_pos_y + 4000;
                                        obj1stream.Position -= 4;
                                        obj1writer.Write(new_m2_height);
                                        float mddf_pos_z = obj1reader.ReadSingle();
                                        float mddf_rotationx = obj1reader.ReadSingle();
                                        float mddf_rotationy = obj1reader.ReadSingle();
                                        float mddf_rotationz = obj1reader.ReadSingle();
                                        var scale = obj1reader.ReadUInt16();
                                        var flags = obj1reader.ReadUInt16();

                                    }
                                    if (mddf_seen == false)
                                    {
                                        File.AppendAllText(@"missing_wmo.txt", "no m2s found on " + file + Environment.NewLine);
                                        Console.WriteLine("No m2s on this file.");
                                    }

                                }




                                else
                                if (magic == 1297040454)
                                {
                                    while (obj1reader.BaseStream.Position < pos + size)

                                    {

                                        Console.WriteLine("MODF = true");
                                        modf_seen = true;
                                        counter_read_float++;
                                        var nameID = obj1reader.ReadUInt32();
                                        var uniqueID = obj1reader.ReadUInt32();
                                        float posx = obj1reader.ReadSingle();
                                        var posy = obj1reader.ReadSingle();

                                        var new_wmo_height = posy + 4000;
                                        obj1stream.Position -= 4;
                                        obj1writer.Write(new_wmo_height);
                                        float posz = obj1reader.ReadSingle();
                                        float rotationx = obj1reader.ReadSingle();
                                        float rotationy = obj1reader.ReadSingle();
                                        float rotationz = obj1reader.ReadSingle();
                                        float extentsminx = obj1reader.ReadSingle();
                                        float extentsminy = obj1reader.ReadSingle();
                                        float ententsminz = obj1reader.ReadSingle();
                                        float extentsmaxx = obj1reader.ReadSingle();
                                        float extentsmaxy = obj1reader.ReadSingle();
                                        float extentsmaxz = obj1reader.ReadSingle();
                                        var flags = obj1reader.ReadUInt16();
                                        var doodadset = obj1reader.ReadUInt16();
                                        var nameset = obj1reader.ReadUInt16();
                                        var scale = obj1reader.ReadUInt16();
                                        File.AppendAllText(@"debugpos.txt", file.ToString() + " " + posx.ToString() + " " + posy.ToString() + " " + posz.ToString() + " " + new_wmo_height + Environment.NewLine);

                                    }
                                    if (modf_seen == false)
                                    {
                                        File.AppendAllText(@"missing_wmo.txt", "no wmos found on " + file + Environment.NewLine);
                                        Console.WriteLine("No wmos on this file.");

                                    }
                                }
                                obj1reader.BaseStream.Position = pos + size;
                            }
                        }
                        else
                        if (file.Contains("_obj1"))
                        {
                            bool modf_seen = false;
                            bool mddf_seen = false;


                            int counter_read_float = 0;
                            Console.WriteLine("obj1 file found, processing." + file + Environment.NewLine);




                            while (obj1reader.BaseStream.Position != obj1reader.BaseStream.Length)
                            {

                                // 1297040454 modf

                                var magic = obj1reader.ReadUInt32();

                                var size = obj1reader.ReadUInt32();
                                var pos = obj1reader.BaseStream.Position;

                                if (magic == 1296319558)
                                {
                                    while (obj1reader.BaseStream.Position < pos + size)
                                    {
                                        Console.WriteLine("MDDF = TRUE");
                                        mddf_seen = true;
                                        var mddf_nameid = obj1reader.ReadUInt32();
                                        var mddf_uniqueid = obj1reader.ReadUInt32();
                                        float mddf_pos_x = obj1reader.ReadSingle();
                                        var mddf_pos_y = obj1reader.ReadSingle();
                                        var new_m2_height = mddf_pos_y + 4000;
                                        obj1stream.Position -= 4;
                                        obj1writer.Write(new_m2_height);
                                        float mddf_pos_z = obj1reader.ReadSingle();
                                        float mddf_rotationx = obj1reader.ReadSingle();
                                        float mddf_rotationy = obj1reader.ReadSingle();
                                        float mddf_rotationz = obj1reader.ReadSingle();
                                        var scale = obj1reader.ReadUInt16();
                                        var flags = obj1reader.ReadUInt16();

                                    }
                                    if (mddf_seen == false)
                                    {
                                        File.AppendAllText(@"missing_wmo.txt", "no m2s found on " + file + Environment.NewLine);
                                        Console.WriteLine("No m2s on this file.");
                                    }

                                }




                                else
                                if (magic == 1297040454)
                                {
                                    while (obj1reader.BaseStream.Position < pos + size)

                                    {

                                        Console.WriteLine("MODF = true");
                                        modf_seen = true;
                                        counter_read_float++;
                                        var nameID = obj1reader.ReadUInt32();
                                        var uniqueID = obj1reader.ReadUInt32();
                                        float posx = obj1reader.ReadSingle();
                                        var posy = obj1reader.ReadSingle();

                                        var new_wmo_height = posy + 4000;
                                        obj1stream.Position -= 4;
                                        obj1writer.Write(new_wmo_height);
                                        float posz = obj1reader.ReadSingle();
                                        float rotationx = obj1reader.ReadSingle();
                                        float rotationy = obj1reader.ReadSingle();
                                        float rotationz = obj1reader.ReadSingle();
                                        float extentsminx = obj1reader.ReadSingle();
                                        float extentsminy = obj1reader.ReadSingle();
                                        float ententsminz = obj1reader.ReadSingle();
                                        float extentsmaxx = obj1reader.ReadSingle();
                                        float extentsmaxy = obj1reader.ReadSingle();
                                        float extentsmaxz = obj1reader.ReadSingle();
                                        var flags = obj1reader.ReadUInt16();
                                        var doodadset = obj1reader.ReadUInt16();
                                        var nameset = obj1reader.ReadUInt16();
                                        var scale = obj1reader.ReadUInt16();
                                        File.AppendAllText(@"debugpos.txt", file.ToString() + " " + posx.ToString() + " " + posy.ToString() + " " + posz.ToString() + " " + new_wmo_height + Environment.NewLine);

                                    }
                                    if (modf_seen == false)
                                    {
                                        File.AppendAllText(@"missing_wmo.txt", "no wmos found on " + file + Environment.NewLine);
                                        Console.WriteLine("No wmos on this file.");

                                    }
                                }
                                obj1reader.BaseStream.Position = pos + size;


                            }

                        }


                        else
                        {
                            Console.WriteLine("Normal .adt file found" + file + Environment.NewLine);

                            while (obj1reader.BaseStream.Position != obj1reader.BaseStream.Length)
                            {
                                var magic = obj1reader.ReadUInt32();
                                var size = obj1reader.ReadUInt32();
                                var pos = obj1reader.BaseStream.Position;
                                if (magic == 1296258644)
                                {



                                    for (int i = 0; i < 145; i++)
                                    {
                                        var height = obj1reader.ReadSingle();
                                        File.AppendAllText(@"debug.txt", i + " " + magic + Environment.NewLine);
                                        var newvalue = height + 4000;
                                        obj1stream.Position -= 4;
                                        obj1writer.Write(newvalue);
                                    }



                                }
                                else if (magic == 0x4D434E4B)
                                {
                                    obj1reader.BaseStream.Position = pos + 0x80;
                                }
                                else
                                {
                                    obj1reader.BaseStream.Position = pos + size;
                                }
                            }

                        }
                    }
                    
                }
                Console.WriteLine("Done");
                Console.ReadKey();
            }
        }
    }
}
