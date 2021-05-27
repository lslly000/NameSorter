using NameSorter.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace NameSorter.Writer
{
    public class TextDataWriter : IDataWriter<List<Name>>
    {

        public Task Write(string destination, List<Name> names)
        {
               
          return  Task.Run(()=>{ using (StreamWriter writer = new StreamWriter(destination, false))
                {
                    foreach (Name name in names)
                    {
                        writer.WriteLine($"{name.GivenName} {name.LastName}");
                    }
                }
            });
        }
    }
}
