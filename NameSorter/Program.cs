using Microsoft.Extensions.DependencyInjection;
using NameSorter.DataLoader;
using NameSorter.DataModel;
using NameSorter.Parser;
using NameSorter.Writer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace NameSorter
{
    class Program
    {
        static async Task Main(string[] args)
        {

            if(args.Length <1)
            {
                Console.WriteLine("Please provide the file path of the unsorted list");
                Environment.Exit(0);
            }
            var filePath = args[0];

           var sortedFilePath =  Path.GetDirectoryName(filePath) + "\\sorted-name-list.txt";
            try
            {
                FullNameParser parser = new FullNameParser();
                TextDataLoader loader = new TextDataLoader(parser);

                var names =  await loader.LoadData(filePath);
                if (names.Count > 0)
                {
                    TextDataWriter txtWriter = new TextDataWriter();
                    ConsoleDataWriter consoleWriter = new ConsoleDataWriter();
                    names.Sort(new NameComparer());

                    Task writeToFileTask = txtWriter.Write(sortedFilePath, names);

                    Task writeToConsoleTask = consoleWriter.Write(string.Empty, names);

                    await writeToFileTask;
                    await writeToConsoleTask;
                }
                else
                {
                    Console.WriteLine("No data has been loaded");
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }

    }
}
