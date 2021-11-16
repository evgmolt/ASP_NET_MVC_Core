using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectDemo
{
    public interface IRepository<T>
    {
        public void Create(T item);
        public IEnumerable<T> Read();
        public bool Delete(T item);
    }
}
