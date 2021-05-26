using NameSorter.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorter.Parser
{
    public class FullNameParser : INameParser<Name>
    {
        public  Name ParseName(string fullName)
        {
            fullName = fullName.Trim();
            if (fullName.Length == 0)
            {
                return null;
            }

            int lastNameStartIndex = fullName.LastIndexOf(' ');
            return new Name()
            {
                LastName = fullName.Substring(lastNameStartIndex+1),
                GivenName = lastNameStartIndex > 0 ? fullName.Substring(0, lastNameStartIndex) : string.Empty,
            };
        } 
    }
}
