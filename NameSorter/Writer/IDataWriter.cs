using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter.Writer
{
   public interface IDataWriter<T> where T : class
    {
         Task Write(string destination, T data);
    }
}
