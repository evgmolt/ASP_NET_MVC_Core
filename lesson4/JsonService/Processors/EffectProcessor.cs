using JsonService.Data;
using System.IO;
using System.Xml.Serialization;

namespace JsonService
{
    internal class EffectProcessor : AbstractFileProcessor
    {
        protected override CommonData Process(string fileName)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Effect));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                Effect result = (Effect)formatter.Deserialize(fs);
                return result;
            }

        }
    }
}