using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LangtonsLoopsSDL
{
    class Program
    {
        static void Main(string[] args)
        {
            new Viewer(32, 24, 20, 0.1f).Run();
        }
    }
}
