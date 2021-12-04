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

        public Driver(IDevice device)
        {
            _device = device;
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

        public void Save(string fileName)
        {
            if (_saver != null)
            {
                if (_saver.Save(_device, fileName))
                {
                    Log("Saved to file " + fileName);
                }
                else
                {
                    Log("Error writing to file " + fileName);
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
