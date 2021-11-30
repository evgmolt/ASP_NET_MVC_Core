using JsonService.Data;
using System;
using System.IO;
using System.Xml.Serialization;

namespace JsonService
{
    internal class XmlWriter
    {
        public static void Write(Effect item, string directory)
        {
            string fileExtension = ".xml";
            XmlSerializer xmlFormatter = new XmlSerializer(typeof(Effect));
            using FileStream fs = new(directory + @"\" + item.Id.ToString() + fileExtension, FileMode.OpenOrCreate);
            xmlFormatter.Serialize(fs, item);
        }
    }
}