using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter.DataLoader
{
   public interface IDataLoader<T> where T : class
    {
        /// <summary>
        /// Load the data from a targeted source and into targeted data model
        /// </summary>
        /// <param name="source">the path of the source</param>
        /// <returns></returns>
        Task <List<T>> LoadData(string source);
    }
}
