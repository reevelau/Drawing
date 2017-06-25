using System;
using Drawing.Engine.Receiver;
using System.IO;

namespace Drawing.Engine.Receiver
{
    public interface ICanvasPrinter
    {
        void Print(ICanvas Canvas);
    }

}