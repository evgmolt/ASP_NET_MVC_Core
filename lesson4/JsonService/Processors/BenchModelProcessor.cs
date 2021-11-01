using JsonService.Data;
using JsonService.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonService.Processors
{
    internal class BenchModelProcessor : AbstractFileProcessor
    {
        protected override CommonData Process(string content)
        {
            BenchModel result = JsonConvert.DeserializeObject<BenchModel>(content);
            return result;
        }
    }
}
