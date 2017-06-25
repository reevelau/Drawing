using System;
using Drawing.Engine.Receiver;
using Drawing.Engine.Geometry;

namespace Drawing.Engine.Command
{
    public interface ICommandFactory
    {
        ICanvasCommand CreateLine(ICanvas canvas, int x1, int y1, int x2, int y2, int color);

        ICanvasCommand CreateRectangle(ICanvas canvas, int x1, int y1, int x2, int y2, int color);

        ICanvasCommand CreateBucketFill(ICanvas canvas, int x, int y, int color);
    }
}