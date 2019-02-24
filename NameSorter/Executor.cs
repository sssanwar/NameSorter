using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using NameSorter.Data;
using NameSorter.IO;

namespace NameSorter
{
    public static class Executor
    {
        public static void Execute(String[] args)
        {
            try
            {
                // This is only for demonstrating Dependency Injection.
                var services = new ServiceCollection();
                services.AddSingleton<IReader<Person>>(new FilePlainReader<Person>(args[0]));
                services.AddSingleton<IComparer<Person>>(new PersonLastNameFirstComparer());
                services.AddTransient<IWriter<Person>>(s => new FilePlainWriter<Person>(GetOutputPath(args[0])));
                services.AddTransient<IWriter<Person>>(s => new ConsolePlainWriter<Person>());
                var provider = services.BuildServiceProvider();

                // Get reader, comparer and writers.
                var reader = provider.GetService<IReader<Person>>();
                var comparer = provider.GetService<IComparer<Person>>();
                var writers = provider.GetServices<IWriter<Person>>();

                var stopWatch = new Stopwatch();
                stopWatch.Start();

                // Start processing...
                var persons = reader.Read();
                Array.Sort(persons, comparer);
                foreach (var w in writers)
                {
                    w.Write(persons);
                }

                stopWatch.Stop();
                Console.WriteLine($"{Environment.NewLine}--{Environment.NewLine}Reading, sorting and writing took {stopWatch.ElapsedMilliseconds}ms to complete.");
                Environment.Exit(0);
            }
            catch (Exception x)
            {
                Console.WriteLine("An error occured: " + x.Message);
                Environment.Exit(2);
            }
        }

        private static String GetOutputPath(String inputPath)
        {
            var filename = Path.GetFileName(inputPath);
            var dirname = Path.GetDirectoryName(Path.GetFullPath(inputPath));
            return Path.Combine(dirname, filename.Replace("unsorted", "sorted", StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
