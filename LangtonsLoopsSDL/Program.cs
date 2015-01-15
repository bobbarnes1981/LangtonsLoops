using LangtonsLoopsLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LangtonsLoopsSDL
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 128;
            int height = 96;

            Viewer v = new Viewer(new Table("langtonsloops.table"), width, height, 5, 0.15f);

            string[] file = File.ReadAllLines("langtonsloops.genome");
            int[,] data = new int[file[0].Length, file.Length];
            for (int y = 0; y < file.Length; y++)
            {
                for (int x = 0; x < file[y].Length; x++)
                {
                    data[x, y] = int.Parse(file[y][x].ToString());
                }
            }

            v.Load(width/2, height/2, data);

            v.Run();
        }
    }
}
