using System;
using Drawing.Engine.Receiver;

namespace Drawing.Engine.Command
{
    public interface ICanvasCommand
    {
        void Execute();
    }

}