using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameSorter;
using NameSorter.DataModel;
using NameSorter.Parser;

namespace NameSortTest
{
    [TestClass]
    public class FullNameParserTest
    {
  
        [DataTestMethod]
        [DataRow("Alice Wong", "Wong" , "Alice")]
        [DataRow("Frankie Conner Ritter", "Ritter", "Frankie Conner")]
        [DataRow(" Frankie Conner Ritter ", "Ritter", "Frankie Conner")]
        [DataRow("Hunter Uriah Mathew Clarke", "Clarke", "Hunter Uriah Mathew")]
        [DataRow("123", "123", "")]
        public void ParseName(string before, string expectedLastName, string expectedGivenName)
        {
            FullNameParser parser = new FullNameParser();
            Name actual = parser.ParseName(before);
            Assert.AreEqual(expectedLastName, actual.LastName);
            Assert.AreEqual(expectedGivenName, actual.GivenName);
        }


        [TestMethod]
        public void ReturnNull()
        {
            FullNameParser parser = new FullNameParser();
            Name actual = parser.ParseName(" ");
            Assert.IsNull(actual);
        }


    }
}
