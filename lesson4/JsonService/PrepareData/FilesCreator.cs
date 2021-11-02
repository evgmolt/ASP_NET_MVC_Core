using JsonService.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.Json;

namespace JsonService
{
    internal class FilesCreator
    {
        //Три сборных модели, клей, краска и смывка
        BenchModel benchModel1 = new()
        {
            Id = 0,
            Name = "North American P-51B Mustang",
            Manufacturer = "Trumpeter",
            Price = 4199,
            TypeOfModel = ModelType.Aircraft,
            Scale = 32,
        };
        BenchModel benchModel2 = new()
        {
            Id = 1,
            Name = "Leichttractor rheinmetall 1930",
            Manufacturer = "ICM",
            Price = 1940,
            TypeOfModel = ModelType.Armor,
            Scale = 35,
        };
        BenchModel benchModel3 = new()
        {
            Id = 2,
            Name = "Alpha Romeo Gulietta Spider",
            Manufacturer = "Italery",
            Price = 2925,
            TypeOfModel = ModelType.Car,
            Scale = 24,
        };

        Glue glue1 = new()
        {
            Id = 3,
            Name = "Cianoakril",
            Manufacturer = "Tamiya",
            Price = 426,
            TypeOfGlue = Enums.GlueType.Cianoakril,
            Volume = 3
        };

        Paint paint1 = new()
        {
            Id = 4,
            Name = "Chrome Yellow",
            Manufacturer = "Tamiya",
            Price = 190,
            Color = Color.Yellow,
            Volume = 10
        };

        Effect effect1 = new()
        {
            Id = 5,
            Name = "Ammo",
            Manufacturer = "Mig",
            Price = 386,
            Volume = 25,
            TypeOfEffect = Enums.EffectType.Wash
        };

        public FilesCreator(string dataDirectory)
        {
            JsonWriter.Write(benchModel1, dataDirectory);
            JsonWriter.Write(benchModel2, dataDirectory);
            JsonWriter.Write(benchModel3, dataDirectory);
            JsonWriter.Write(glue1, dataDirectory);
            JsonWriter.Write(paint1, dataDirectory);
            XmlWriter.Write(effect1, dataDirectory);
        }
    }
}
