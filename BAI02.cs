using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI02
{
    class Program
    {
        public static void Main()
        {
            Console.Write("Nhap vao duong dan thu muc: ");
            string linkfolder = Console.ReadLine();
            if (Directory.Exists(linkfolder))
            {
                string[] folderlist = Directory.GetDirectories(linkfolder);
                string[] filelist = Directory.GetFiles(linkfolder);
                if (folderlist.Length > 0 || filelist.Length > 0)
                {
                    DirectoryInfo folder;
                    for (int i = 0; i < folderlist.Length; i++)
                    {
                        folder = new DirectoryInfo(folderlist[i]);
                        Console.WriteLine($"{folder.LastWriteTime:MM/dd/yyyy hh:mm tt}   {"<DIR>",-15}{folder.Name}");
                    }
                    FileInfo file;
                    for (int i = 0; i < filelist.Length; i++)
                    {
                        file = new FileInfo(filelist[i]);
                        Console.WriteLine($"{file.CreationTime:MM/dd/yyyy hh:mm tt}   {file.Length,-15}{file.Name}");
                    }
                }
                else Console.WriteLine("Thu muc rong!");
            }
            else Console.WriteLine("Khong tim thay thu muc!");
        }
    }
}
