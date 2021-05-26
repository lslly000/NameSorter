using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter.DataLoader
{
   public interface IDataLoader<T> where T : class
    {
        Task <List<T>> LoadData(string source);
    }
}
