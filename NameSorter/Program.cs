using System;
using System.IO;
using System.Collections.Generic;
using NameSorter.Data;
using NameSorter.IO;

namespace NameSorter.Data
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No filepath provided. This program will exit.");
                Environment.Exit(160);
            }

            Executor.Execute(args);
        }
    }
}
