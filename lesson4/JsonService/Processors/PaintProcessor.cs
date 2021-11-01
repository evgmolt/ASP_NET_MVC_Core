using JsonService.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonService.Processors
{
    internal class PaintProcessor : AbstractFileProcessor
    {
        protected override CommonData Process(string content)
        {
            Paint result = JsonConvert.DeserializeObject<Paint>(content);
            return result;
        }
    }
}
