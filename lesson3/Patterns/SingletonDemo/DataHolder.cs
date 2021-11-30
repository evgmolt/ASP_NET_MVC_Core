using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDemo
{
    class DataHolder : IDisposable
    {
        private static DataHolder instance;
        private readonly FileStream _dataFile;
        private static object _lockObject = new();
        private long _fileSize;
        private const int _outArraySize = 4;

        private DataHolder(string filename)
        {
            var fileInfo = new FileInfo(filename);
            _fileSize = fileInfo.Length;
            _dataFile = File.OpenRead(filename);
        }

        public static DataHolder GetInstance(string fname)
        {
            if (instance == null)
            {
                lock (_lockObject)
                if (instance == null)
                {
                    instance = new DataHolder(fname);
                }
            }
            return instance;
        }

        public byte[] GetData()
        {
            Random rand = new();
            int position = rand.Next(0, (int)_fileSize - _outArraySize);
            _dataFile.Seek(position, SeekOrigin.Begin);
            byte[] result = new byte[_outArraySize];
            _dataFile.Read(result, 0, _outArraySize);
            return result;
        }

        public void Dispose()
        {
            if (_dataFile != null)
            {
                _dataFile.Dispose();
            }
        }
    }
}
