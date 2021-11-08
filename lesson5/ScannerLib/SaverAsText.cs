using Emulator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerLib
{
    public sealed class SaverAsText : ISaver
    {
        public bool Save(IDevice device, string fileName)
        {
            byte[] data = device.GetData();
            string s = "";
            for (int i = 0; i < data.Length; i++)
            {
                s += data[i].ToString() + " ";
            }
            try
            {
                File.WriteAllText(fileName, s);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
