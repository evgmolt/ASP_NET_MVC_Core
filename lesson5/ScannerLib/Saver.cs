using Emulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerLib
{
    public abstract class Saver : ISaver
    {
        public abstract bool Save(IDevice device, string fileName);
    }
}
