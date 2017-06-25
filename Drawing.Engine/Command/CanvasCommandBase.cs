using System;
using Drawing.Engine.Receiver;
using Drawing.Engine.Geometry;

namespace Drawing.Engine.Command
{
    public abstract class CanvasCommandBase : ICanvasCommand
    {
        protected ICanvas Receiver{ get; set; }
        public CanvasCommandBase(ICanvas canvas)
        {
            Receiver = canvas;
        }
        public abstract void Execute();
    }
}