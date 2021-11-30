using JsonService.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace JsonService
{
    internal class JsonWriter
    {
        public static void Write(BaseData item, string directory)
        {
            string fileExtension = ".json";
            string json = JsonConvert.SerializeObject(item);
            File.WriteAllText(directory + @"\" + item.Id.ToString() + fileExtension, json);
        }
    }
}
