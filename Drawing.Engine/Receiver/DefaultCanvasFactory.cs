using System;

namespace Drawing.Engine.Receiver
{
    public class DefaultCanvasFactory : ICanvasFactory
    {
        public static ICanvasFactory Instance {get;set;} = new DefaultCanvasFactory();

        public ICanvas CreateCanvas(int width, int height)
        {
            return new SimpleCanvas(width,height);
        }
    }
}