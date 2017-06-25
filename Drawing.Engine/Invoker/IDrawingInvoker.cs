using System;
using Drawing.Engine.Command;

namespace Drawing.Engine.Invoker
{
    public interface IDrawingInvoker
    {
        void StoreAndExecute(ICanvasCommand command);
    }
}