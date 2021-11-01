using JsonService.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsonService.Data
{
    public class Glue : CommonData
    {
        public GlueType TypeOfGlue { get; set; }
        public decimal Volume { get; set; }
    }
}
