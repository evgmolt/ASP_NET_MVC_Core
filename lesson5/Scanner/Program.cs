using Emulator;
using ScannerLib;
using System;
using System.Threading;

namespace Scanner
{
    class Program
    {
        static void Main()
        {
            Device scanner = new();
            Driver driver = new(scanner);
            driver.SetupSaveType(new SaverAsText());
            driver.Save("textfile.txt");
            driver.SetupSaveType(new SaverAsBin());
            driver.Save("binfile.bin");
            var load = driver.GetLoad();
            Console.WriteLine($"RAM : {load.RAM}");
            Console.WriteLine($"CPU : {load.CPU}");
            Console.WriteLine();
        }
    }
}
