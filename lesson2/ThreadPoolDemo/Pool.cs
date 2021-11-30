using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace ThreadPoolDemo
{
    public sealed class Pool : IDisposable, IPool
    {
        private readonly ConcurrentQueue<Thread> _workers; // queue of worker threads ready to process actions
        private readonly ConcurrentQueue<Action> _tasks = new ConcurrentQueue<Action>(); // actions to be processed by worker threads
        private bool _disallowAdd; // set to true when disposing queue but there are still tasks pending
        private bool _disposed; // set to true when disposing queue and no more tasks are pending
        private readonly int MaxNumOfThreads = 50;

        public Pool(int size)
        {
            if (size > MaxNumOfThreads)
            {
                string message = $"The number of threads cannot be more than { MaxNumOfThreads }";
                throw new ArgumentException(message);
            }
            this._workers = new ConcurrentQueue<Thread>();
            for (var i = 0; i < size; ++i)
            {
                var worker = new Thread(this.Worker) { Name = string.Concat("Worker ", i) };
                worker.Start();
                this._workers.Enqueue(worker);
            }
        }

        public int GetNumOfThreads()
        {
            return _workers.Count;
        }

        public void Dispose()
        {
            var waitForThreads = false;
            lock (this._tasks)
            {
                if (!this._disposed)
                {
                    GC.SuppressFinalize(this);

                    this._disallowAdd = true; // wait for all tasks to finish processing while not allowing any more new tasks
                    while (this._tasks.Count > 0)
                    {
                        Monitor.Wait(this._tasks);
                    }

                    this._disposed = true;
                    Monitor.PulseAll(this._tasks); // wake all workers (none of them will be active at this point; disposed flag will cause then to finish so that we can join them)
                    waitForThreads = true;
                }
            }
            if (waitForThreads)
            {
                foreach (var worker in this._workers)
                {
                    worker.Join();
                }
            }
        }

        public void QueueTask(Action task)
        {
            lock (this._tasks)
            {
                if (this._disallowAdd) { throw new InvalidOperationException("This Pool instance is in the process of being disposed, can't add anymore"); }
                if (this._disposed) { throw new ObjectDisposedException("This Pool instance has already been disposed"); }
                this._tasks.Enqueue(task);
                Monitor.PulseAll(this._tasks); // pulse because tasks count changed
            }
        }

        private void Worker()
        {
            Action task = null;
            while (true) // loop until threadpool is disposed
            {
                lock (this._tasks) // finding a task needs to be atomic
                {
                    while (true) // wait for our turn in _workers queue and an available task
                    {
                        if (this._disposed)
                        {
                            return;
                        }
                        Thread FirstThread;
                        if (!this._workers.TryPeek(out FirstThread))
                        {
                            FirstThread = null;
                        }
                        if (null != FirstThread && object.ReferenceEquals(Thread.CurrentThread, FirstThread) && this._tasks.Count > 0) // we can only claim a task if its our turn (this worker thread is the first entry in _worker queue) and there is a task available
                        {

//                            this._tasks.TryPeek(out task);
                            this._tasks.TryDequeue(out task);
                            Thread t;
                            this._workers.TryDequeue(out t);
                            Monitor.PulseAll(this._tasks); // pulse because current (First) worker changed (so that next available sleeping worker will pick up its task)
                            break; // we found a task to process, break out from the above 'while (true)' loop
                        }
                        Monitor.Wait(this._tasks); // go to sleep, either not our turn or no task to process
                    }
                }

                task(); // process the found task
                lock (this._tasks)
                {
                    this._workers.Enqueue(Thread.CurrentThread);
                }
                task = null;
            }
        }
    }
}