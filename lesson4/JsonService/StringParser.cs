using JsonService.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonService
{
    public static class StringParser
    {
        private static readonly string[] keySubstrings = 
        { 
            "TypeOfModel", 
            "Color", 
            "TypeOfGlue",
            "TypeOfEffect"
        };
        
        private static readonly SourceType[] types = 
        { 
            SourceType.JsonBenchModel, 
            SourceType.JsonPaint, 
            SourceType.JsonGlue,
            SourceType.XmlEffect
        };

        public static SourceType GetType(string content)
        {
            for (int i = 0; i < keySubstrings.Length; i++)
            {
                if (content.IndexOf(keySubstrings[i]) > 0)
                {
                    return types[i];
                }
            }
            return SourceType.Unknown;
        }
    }
}
