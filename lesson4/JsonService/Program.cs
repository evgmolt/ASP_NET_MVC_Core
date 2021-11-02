using JsonService.Data;
using JsonService.Enums;
using JsonService.Processors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace JsonService
{
    class Program
    {
        static readonly string dataDirectory = "Data";
        static readonly ArrayList basketList = new();

        static void Main()
        {
            if (!Directory.Exists(dataDirectory))
            {
                Directory.CreateDirectory(dataDirectory);
            }

            _ = new FilesCreator(dataDirectory);

            ScanDirectory(dataDirectory);
            for (int i = 0; i < basketList.Count; i++)
            {
                Console.WriteLine(basketList[i].ToString());
            }
            Console.ReadLine();
        }

        static void ScanDirectory(string directory)
        {
            string[] files = Directory.GetFiles(directory);
            BaseData data;
            for (int i = 0; i < files.Length; i++)
            {
                string content = File.ReadAllText(files[i]);
                SourceType type = StringParser.GetType(content);
                switch (type)
                {
                    case SourceType.JsonBenchModel:
                        FileProcessor fpb = new(new BenchModelProcessor());
                        data = fpb.Process(content);
                        basketList.Add(data);
                        break;
                    case SourceType.JsonGlue:
                        FileProcessor fpg = new(new GlueProcessor());
                        data = fpg.Process(content);
                        basketList.Add(data);
                        break;
                    case SourceType.JsonPaint:
                        FileProcessor fpp = new(new PaintProcessor());
                        data = fpp.Process(content);
                        basketList.Add(data);
                        break;
                    case SourceType.XmlEffect:
                        FileProcessor fpe = new(new EffectProcessor());
                        data = fpe.Process(files[i]);
                        basketList.Add(data);
                        break;
                    case SourceType.Unknown:
                        Console.WriteLine("Unknown file format");
                        break;
                }
            }
        }
    }
}
