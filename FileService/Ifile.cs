using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ourProject.FileService
{
    public interface Ifile
    {
        public string FilePath { get; set; }
       
         public void WriteMessage(string message);
          public void AddItem<T>(T item);
          public List<T> Get<T>();
          public void Update<T>(List<T> list);
    }
}