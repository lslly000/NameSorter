using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameSorter;
using NameSorter.DataLoader;
using NameSorter.DataModel;
using NameSorter.Parser;
using System.IO;

namespace NameSortTest
{
    [TestClass]
    public class TextDataLoaderTest
    {
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void FileNotFound()
        {
            FullNameParser nameParser = new FullNameParser();
            TextDataLoader loader = new TextDataLoader(nameParser);

            loader.LoadData("abc.txt");

        }
    }
}
