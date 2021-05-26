using NameSorter.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorter
{
  public class NameComparer : IComparer<Name>
    {
        public int Compare(Name x, Name y)
        {
            if (object.ReferenceEquals(x, y))
            {
                return 0;
            }

            if (x == null)
            {
                return -1;
            }

            if (y == null)
            {
                return 1;
            }

            int ret = String.Compare(x.LastName, y.LastName);
            return ret != 0 ? ret : x.GivenName.CompareTo(y.GivenName);
        }
    }
}
