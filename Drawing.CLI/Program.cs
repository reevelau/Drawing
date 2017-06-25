using System;
using Drawing.Engine;

namespace Drawing.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            TextDrawingService service = new TextDrawingService(Console.In, Console.Out, Console.Error);
            service.Start();
        }
    }
}
