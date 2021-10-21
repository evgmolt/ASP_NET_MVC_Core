using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDemo
{
    class ObserverFile : IObserver
    {
        private const string _fileName = "keys.txt";
        public void Update(object ob)
        {
            ConsoleKeyInfo k = (ConsoleKeyInfo)ob;
            File.AppendAllText(_fileName, k.KeyChar.ToString() + " ");
        }
    }
}
