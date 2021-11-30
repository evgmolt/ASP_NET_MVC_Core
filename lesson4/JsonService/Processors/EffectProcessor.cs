using JsonService.Data;
using System.IO;
using System.Xml.Serialization;

namespace JsonService
{
    internal class EffectProcessor : AbstractFileProcessor
    {
        protected override BaseData Process(string fileName)
        {
            XmlSerializer formatter = new(typeof(Effect));
            using FileStream fs = new(fileName, FileMode.OpenOrCreate);
            Effect result = (Effect)formatter.Deserialize(fs);
            return result;
        }
    }
}