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

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var filePath = args[0];
           

            try
            {
                List<Name> names =  serviceProvider.GetService<IDataLoader<Name>>().LoadData(filePath).Result;

                if (names.Count > 0)
                {
                    names.Sort(new NameComparer());

                    Task writeToFileTask = serviceProvider.GetService<TextDataWriter>().Write(filePath, names);

                    Task writeToConsoleTask = serviceProvider.GetService<ConsoleDataWriter>().Write(string.Empty, names);

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


        private static void ConfigureServices(IServiceCollection services)
        {

            services.AddTransient<INameParser<Name>, FullNameParser>();
            services.AddTransient<IDataLoader<Name>, TextDataLoader>();
            services.AddTransient<ConsoleDataWriter>();
            services.AddTransient<TextDataWriter >();
        }

    }
}
