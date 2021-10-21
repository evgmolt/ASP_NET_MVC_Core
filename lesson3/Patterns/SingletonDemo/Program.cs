using System;
using System.IO;
using System.Threading;

namespace SingletonDemo
{
    class Program
    {
        const string FileName = "data.bin";
        const int FileSize = 255; 
        static void Main(string[] args)
        {
            CreateFile(FileName);
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(GetAndShowBytes));
                Thread.Sleep(500);
            }
        }

        private static void GetAndShowBytes(object state)
        {
            DataHolder data = DataHolder.GetInstance(FileName);
            var receivedData = data.GetData();
            Console.Write("Thread : " + Thread.CurrentThread.ManagedThreadId + "\t");
            for (int i = 0; i < receivedData.Length; i++)
            {
                Console.Write($"{receivedData[i]} ");
            }
            Console.WriteLine();
        }

        static void CreateFile(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            using (FileStream fs = File.OpenWrite(filename))
            {
                byte[] b = new byte[FileSize];
                for (byte i = 0; i < b.Length; i++)
                {
                    b[i] = i;
                }
                fs.Write(b);
            }
        }
    }
}
