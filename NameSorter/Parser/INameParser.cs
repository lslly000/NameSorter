using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorter.Parser
{
    public interface INameParser<T>
    {
        T ParseName(string fullName);
    }
}
