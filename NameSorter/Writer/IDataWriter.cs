using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter.Writer
{
   public interface IDataWriter<T> where T : class
    {/// <summary>
    /// Write data to the targeted destination
    /// </summary>
    /// <param name="destination">the path of the destination</param>
    /// <param name="data">data to be written into the destination</param>
    /// <returns></returns>
         Task Write(string destination, T data);
    }
}
