using System;
using Drawing.Engine.Canvas;

namespace Drawing.Engine.Command
{
    interface ICanvasCommand
    {
        void Execute(ICanvas canvas);
    }

}