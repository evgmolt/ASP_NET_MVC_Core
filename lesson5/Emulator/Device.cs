using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emulator
{
    public class Device : IDisposable, IDevice
    {
        private readonly Random _rand = new();
        private const int _minRAMLoad = 30;
        private const int _maxRAMLoad = 80;
        private const int _minCPULoad = 20;
        private const int _maxCPULoad = 70;
        private const int _size = 10;

        private readonly FileStream _fileStream = new("DSCF0710.JPG", FileMode.Open);
        private readonly byte[] _data = new byte[_size];
        public int GetRAMLoad()
        {
            return _rand.Next(_minRAMLoad, _maxRAMLoad);
        }
        public int GetCPULoad()
        {
            return _rand.Next(_minCPULoad, _maxCPULoad);
        }

        public byte[] GetData()
        {
            _fileStream.Seek(_rand.Next(0, (int)(_fileStream.Length - _size)), SeekOrigin.Begin);
            _fileStream.Read(_data, 0, _size);
            return _data;
        }

        public void Dispose()
        {
            if (_fileStream != null)
            {
                _fileStream.Dispose();
            }
        }
    }
}
