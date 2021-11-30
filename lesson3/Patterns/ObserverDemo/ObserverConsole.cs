using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDemo
{
    class ObserverConsole : IObserver
    {
        public void Update(object ob)
        {
            ConsoleKeyInfo k = (ConsoleKeyInfo)ob;
            Console.WriteLine(k.KeyChar);
        }
    }
}
