using System;

namespace Drawing.Engine.Receiver
{
    public interface ICanvasFactory
    {
        ICanvas CreateCanvas(int width, int height);
    }
}