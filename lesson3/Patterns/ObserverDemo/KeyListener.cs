using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDemo
{
    class KeyListener : IObservable
    {
        List<IObserver> _observers;
        ConsoleKeyInfo _key;

        public KeyListener()
        {
            _observers = new List<IObserver>();
        }
        public void NotifyObservers()
        {
            foreach (IObserver o in _observers)
            {
                o.Update(_key);
            }
        }

        public void RegisterObserver(IObserver o)
        {
            _observers.Add(o);
            Console.WriteLine($"Registred observer {o.GetType()}");
        }

        public void RemoveObserver(IObserver o)
        {
            _observers.Remove(o);
            Console.WriteLine($"Removed observer {o.GetType()}");
        }

        public void Run()
        {
            while (_key.Key != ConsoleKey.Escape)
            {
                _key = Console.ReadKey();
                NotifyObservers();
            }
        }
    }
}
