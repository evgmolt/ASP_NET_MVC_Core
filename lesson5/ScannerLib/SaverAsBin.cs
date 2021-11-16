using Emulator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerLib
{
    public sealed class SaverAsBin : Saver
    {
        public override bool Save(IDevice device, string fileName)
        {
            byte[] data = device.GetData();
            try
            {
                File.WriteAllBytes(fileName, data);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
