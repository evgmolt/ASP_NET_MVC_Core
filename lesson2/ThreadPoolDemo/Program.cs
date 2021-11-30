using System;
using System.Threading;

namespace ThreadPoolDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("For start first pool press Enter");
            Console.ReadLine();
            WorkerPool<int> workerPool = new WorkerPool<int>(new CancellationTokenSource(), 5);

            workerPool.startWorkers(value =>
            {
                Console.WriteLine(value);
            });
            //enqueue all the work
            for (int i = 0; i < 100; i++)
            {
                workerPool.enqueue(i);
            }
            //Signal no more work
            workerPool.CompleteAdding();

            //wait all pending work to finish
            workerPool.await();

            Console.WriteLine("For start second pool press Enter");
            Console.ReadLine();

            using (var pool = new Pool(5))
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
    }
}
