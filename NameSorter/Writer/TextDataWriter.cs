using NameSorter.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace NameSorter.Writer
{
    public class TextDataWriter : IDataWriter<List<Name>>
    {

        public async Task Write(string destination, List<Name> names)
        {
                using (StreamWriter writer = new StreamWriter(destination, false))
                {

                    foreach (Name name in names)
                    {
                        await writer.WriteLineAsync($"{name.GivenName} {name.LastName}");
                    }
                }
            return;
        }
    }
}
