using System;
using System.Threading;

namespace SafeListDemo
{
    class Program
    {
        static int MaxListCount = 30;
        static Object _lockObject = new object();
        static void Main(string[] args)
        {
            SafeList<int> safeList = new SafeList<int>();
            for (int i = 0; i < 3; i++)
            {
                Thread thread = new Thread(new ThreadStart(() => AddItems(safeList)));
                thread.Start();
            }
            Thread removeTread = new Thread(new ThreadStart(() => RemoveItem(safeList)));
            removeTread.Start();
            Thread.Sleep(1000);
            Console.ReadKey();
        }
        private static void RemoveItem(SafeList<int> list)
        {
            for (int i = 0; i < 100; i++)
            {
                if (list.Count > 0)
                {
                    list.RemoveAt(0);
                    Console.WriteLine("Remove");
                }
                Thread.Sleep(1000);
            }
        }
        private static void AddItems(SafeList<int> list)
        {
            int id = Thread.CurrentThread.ManagedThreadId;
            for (int i = 0; i < 100; i++)
            {
                if (list.Count < MaxListCount)
                {
                    list.Add(id * 10 + i);
                }
                Show(list);
                Thread.Sleep(1000);
            }
        }
        public static void Show(SafeList<int> list)
        {
            var array = list.GetArray();
            string s = "";
            foreach (int element in array)
            {
                s += element.ToString() + " ";
            }
            Console.WriteLine(s);
        }
    }
}
