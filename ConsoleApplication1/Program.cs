using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = string.Empty;
            StringBuilder builder = new StringBuilder();
            Stopwatch sp=new Stopwatch();
            sp.Start();
            for (int i = 0; i < 100000; i++)
            {
                builder.Append(i);
            }
            sp.Stop();
            Console.WriteLine(sp.Elapsed);
            File.R
        }
    }
}
