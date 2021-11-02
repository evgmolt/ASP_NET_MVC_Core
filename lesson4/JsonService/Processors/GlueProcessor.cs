using JsonService.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonService.Processors
{
    internal class GlueProcessor : AbstractFileProcessor
    {
        protected override BaseData Process(string content)
        {
            Glue result = JsonConvert.DeserializeObject<Glue>(content);
            return result;
        }
    }
}
