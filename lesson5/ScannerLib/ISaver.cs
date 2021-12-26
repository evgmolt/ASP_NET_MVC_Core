using Emulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerLib
{
    public interface ISaver
    {
        bool Save(IDevice device, string fileName);
    }
}
