using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonService.Enums
{
    //При добавлении нового типа нужно написать для него Processor и добавить обработку нового типа в StringParser
    public enum SourceType
    {
        JsonBenchModel,
        JsonGlue,
        JsonPaint,
        XmlEffect,
        Unknown
    }
}
