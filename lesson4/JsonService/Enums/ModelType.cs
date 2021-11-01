using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace JsonService.Data
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ModelType 
    {
        Aircraft = 0,
        Car = 1,
        Armor = 2,
        Helicopter = 3
    }
}
