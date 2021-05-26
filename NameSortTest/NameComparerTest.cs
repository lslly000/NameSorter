using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameSorter;
using NameSorter.DataModel;

namespace NameSortTest
{
    [TestClass]
    public class NameComparerTest
    {
        [TestMethod]
        public void Name2GreaterThanName1()
        {
            NameComparer _nameComparer = new NameComparer();
            Name name1 = new Name() { GivenName = "Abc", LastName = "xyx" };
            Name name2 = new Name() { GivenName = "Abcd", LastName = "xyx" };

            int result = _nameComparer.Compare(name1, name2);

            Assert.AreEqual(-1, result);
        }


        [TestMethod]
        public void Name1GreaterThanName2()
        {
            NameComparer _nameComparer = new NameComparer();
            Name name1 = new Name() { GivenName = "Abcd", LastName = "xyx" };
            Name name2 = new Name() { GivenName = "Abc", LastName = "xyx" };


            int result = _nameComparer.Compare(name1, name2);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void AreEqual()
        {
            NameComparer _nameComparer = new NameComparer();
            Name name1 = new Name() { GivenName = "Abc", LastName = "xyx" };
            Name name2 = new Name() { GivenName = "Abc", LastName = "xyx" };


            int result = _nameComparer.Compare(name1, name2);

            Assert.AreEqual(0, result);
        }
    }
}
