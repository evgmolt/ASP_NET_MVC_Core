using System;

namespace BuilderDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = new Text("Builder result");
            text.Font(Fonts.Arial)
                .Size(18)
                .Color(ConsoleColor.Red)
                .BackgroundColor(ConsoleColor.Black)
                .Bold(true)
                .Underline(true);
            var html = text.GetText();
            Console.WriteLine(html);
            Console.ReadLine();
        }
    }
}
