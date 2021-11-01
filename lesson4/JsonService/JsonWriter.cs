using JsonService.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace JsonService
{
    public static class JsonWriter
    {
        public static void Write(CommonData item, string directory)
        {
            string fileExtension = ".json";
            Type tttt = item.GetType();
            string json = JsonConvert.SerializeObject(item);
            File.WriteAllText(directory + @"\" + item.Id.ToString() + fileExtension, json);
        }
    }
}
