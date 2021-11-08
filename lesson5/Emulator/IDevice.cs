using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emulator
{
    public interface IDevice
    {
        public int GetRAMLoad();
        public int GetCPULoad();
        public byte[] GetData();
    }
}
