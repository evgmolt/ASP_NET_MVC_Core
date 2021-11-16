using Autofac;
using Autofac.Features.Metadata;
using Emulator;
using ScannerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Scanner
{
    class Program
    {
        static void Main()
        {
            var deviceBuilder = new ContainerBuilder();
            deviceBuilder.RegisterType<Device>().As<IDevice>().SingleInstance();
            IContainer deviceContainer = deviceBuilder.Build();
            var scanner = deviceContainer.Resolve<IDevice>();

            var saverBuilder = new ContainerBuilder();
            saverBuilder.RegisterType<SaverAsBin>().As<ISaver>().WithMetadata("fileName", "storage.bin");
            saverBuilder.RegisterType<SaverAsText>().As<ISaver>().WithMetadata("fileName", "storage.txt");
            saverBuilder.RegisterAdapter<Meta<ISaver>, Driver>(
                cmd => new Driver(scanner, cmd.Value, (string)cmd.Metadata["fileName"]));
            IContainer container = saverBuilder.Build();

            IReadOnlyList<Driver> drivers = container.Resolve<IEnumerable<Driver>>().ToList();

            for (int i = 0; i < drivers.Count; i++)
            {
                drivers[i].Save();
                var load = drivers[i].GetLoad();
                Console.WriteLine($"RAM : {load.RAM}");
                Console.WriteLine($"CPU : {load.CPU}");            
            }
        }
    }
}
