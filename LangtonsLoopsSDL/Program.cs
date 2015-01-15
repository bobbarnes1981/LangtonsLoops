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
            Viewer v = new Viewer(32, 24, 20, 0.1f);

            string[] file = File.ReadAllLines("langtonsloops.genome");
            int[,] data = new int[file[0].Length, file.Length];
            for (int y = 0; y < file.Length; y++)
            {
                for (int x = 0; x < file[y].Length; x++)
                {
                    data[x, y] = int.Parse(file[y][x].ToString());
                }
            }

            v.Load(2, 2, data);
            v.Run();
        }
    }
}
