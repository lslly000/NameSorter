using NameSorter.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace NameSorter.Writer
{
    public class ConsoleDataWriter : IDataWriter<List<Name>>
    {

        public ConsoleDataWriter( )
        {
        }

        public Task Write(string destination, List<Name> names)
        {
            foreach (Name name in names)
            {
                Console.WriteLine($"{name.GivenName} {name.LastName}");
            }

            return Task.CompletedTask;
        }
    }
}
