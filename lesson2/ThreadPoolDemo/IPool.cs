using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadPoolDemo
{
    interface IPool
    {
        public void QueueTask(Action task);
        public void Dispose();
    }
}
