using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadPoolDemo
{
    interface IMyPool<T>
    {
        public T Take();
        public void Release(T item);
        protected abstract T ObjectConstructor();
    }
}
