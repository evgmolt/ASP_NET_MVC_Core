using System;

namespace ObserverDemo
{
    class Program
    {
        static void Main()
        {
            KeyListener keyListener = new();
            ObserverConsole observerConsole = new();
            ObserverFile observerFile = new();
            keyListener.RegisterObserver(observerConsole);
            keyListener.RegisterObserver(observerFile);
            Console.WriteLine("Press any key, Esc for exit");
            keyListener.Run();
        }
    }
}
