using System;
using System.Threading;

namespace ThreadPoolDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            Console.ReadLine();
            using (var pool = new Pool(10))
            {
                Console.WriteLine("Num of threads : " + pool.GetNumOfThreads());
                var random = new Random();
                Action<int> randomizer = (index =>
                {
                    Console.WriteLine("{0}: Working on index {1}", Thread.CurrentThread.Name, index);
                    Thread.Sleep(random.Next(20, 400));
                    Console.WriteLine("{0}: Ending {1}", Thread.CurrentThread.Name, index);
                });

                for (var i = 0; i < 40; ++i)
                {
                    var i1 = i;
                    pool.QueueTask(() => randomizer(i1));
                }
            }
        }

        private static void Do(object state)
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }
    }
}
