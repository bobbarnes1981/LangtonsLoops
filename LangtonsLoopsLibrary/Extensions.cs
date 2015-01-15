using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangtonsLoopsLibrary
{
    public static class Extensions
    {
        public static string RotateR(this string source)
        {
            string output = "";
            output += source[source.Length-1];
            for (int i = 0; i < source.Length - 1; i++)
            {
                output += source[i];
            }
            return output;
        }
    }
}
