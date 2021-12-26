using Emulator;
using System;
using System.IO;

namespace ScannerLib
{
    public class Driver
    {
        public struct Load
        {
            public int CPU;
            public int RAM;
        }

        private const string _logFile = "scanner.log";
        private readonly IDevice _device;
        private ISaver _saver;
        private string _fileName;

        public Driver(IDevice device, ISaver saver, string fileName)
        {
            _device = device;
            _saver = saver;
            _fileName = fileName;
        }

        public void SetupSaveType(ISaver saver)
        {
            _saver = saver;
        }

        public Load GetLoad()
        {
            Load result;
            result.CPU = _device.GetCPULoad();
            result.RAM = _device.GetRAMLoad();
            Log($"CPU : {result.CPU}, RAM : {result.RAM}");
            return result;
        }

        public void Save()
        {
            if (_saver != null)
            {
                if (_saver.Save(_device, _fileName))
                {
                    Log("Saved to file " + _fileName);
                }
                else
                {
                    Log("Error writing to file " + _fileName);
                }
            }
        }
 
        private static bool Log(string content)
        {
            try
            {
                File.AppendAllText(_logFile, DateTime.Now.ToString() + " " + content + "\r");
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
