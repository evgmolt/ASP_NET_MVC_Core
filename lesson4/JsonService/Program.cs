using JsonService.Data;
using JsonService.Enums;
using JsonService.Processors;
using System;
using System.IO;

namespace JsonService
{
    class Program
    {
        static string DataDirectory = "Data";
        static void Main(string[] args)
        {
            if (!Directory.Exists(DataDirectory))
            {
                Directory.CreateDirectory(DataDirectory);
            }
            Console.WriteLine("Hello World!");
            FilesCreator jsonCreator = new FilesCreator(DataDirectory);
            ScanDirectory(DataDirectory);
            Console.ReadLine();
        }

        static void ScanDirectory(string directory)
        {
            string[] files = Directory.GetFiles(directory);
            string[] contents = new string[files.Length];
            CommonData data;
            for (int i = 0; i < files.Length; i++)
            {
                string content = File.ReadAllText(files[i]);
                SourceType type = StringParser.GetType(content);
                switch (type)
                {
                    case SourceType.JsonBenchModel:
                        FileProcessor fpb = new(new BenchModelProcessor());
                        data = fpb.Process(content);
                        Console.WriteLine(data.ToString());
                        break;
                    case SourceType.JsonGlue:
                        FileProcessor fpg = new(new GlueProcessor());
                        data = fpg.Process(content);
                        Console.WriteLine(data.ToString());
                        break;
                    case SourceType.JsonPaint:
                        FileProcessor fpp = new(new PaintProcessor());
                        data = fpp.Process(content);
                        Console.WriteLine(data.ToString());
                        break;
                    case SourceType.XmlEffect:
                        FileProcessor fpe = new(new EffectProcessor());
                        data = fpe.Process(files[i]);
                        Console.WriteLine(data.ToString());
                        break;
                    case SourceType.Unknown:
                        Console.WriteLine("Unknown file format");
                        break;
                }
            }
        }
    }
}
