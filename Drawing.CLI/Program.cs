using System;
using Drawing.Engine.Text;

namespace Drawing.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            DrawingService service = new DrawingService(Console.In, Console.Out, Console.Error);
            service.Start();
        }
    }
}
