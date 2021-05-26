using NameSorter.DataModel;
using NameSorter.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace NameSorter.DataLoader
{
    public class TextDataLoader : IDataLoader<Name>
    {
        INameParser<Name> _nameParser;
        public TextDataLoader(INameParser<Name> nameParser)
        {
            _nameParser = nameParser;
        }

        public Task<List<Name>> LoadData(string source)
        {
            List<Name> unsortedNames = new List<Name>();

            if (!File.Exists(source))
            {
                throw new FileNotFoundException($"{source} cannot be found");
            }
            using (var sr = new StreamReader(source))
            {
                string fullname;
                while ((fullname = sr.ReadLine()) != null)
                {
                    var name = _nameParser.ParseName(fullname);
                    if (name != null)
                    {
                        unsortedNames.Add(name);
                    }
                }
            }
            return Task.FromResult(unsortedNames);
        }
    }
}
