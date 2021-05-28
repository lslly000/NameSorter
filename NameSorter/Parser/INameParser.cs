using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorter.Parser
{
    public interface INameParser<T>
    {
        /// <summary>
        /// Parse the input name into the target model
        /// </summary>
        /// <param name="fullName">the name to be parsed</param>
        /// <returns></returns>
        T ParseName(string fullName);
    }
}
