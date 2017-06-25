using System;
using Drawing.Engine.Receiver;
using Drawing.Engine.Geometry;

namespace Drawing.Engine.Command
{
    public class DefaultCommandFactory : ICommandFactory
    {
        public static DefaultCommandFactory Instance {get;set;} = new DefaultCommandFactory();
        
        public ICanvasCommand CreateBucketFill(ICanvas canvas, int x, int y, int color)
        {
            return new BucketFill(canvas,x,y,color);
        }

        public ICanvasCommand CreateLine(ICanvas canvas, int x1, int y1, int x2, int y2, int color)
        {
            return new CreateLine(canvas,x1,y1,x2,y2,color);
        }

        public ICanvasCommand CreateRectangle(ICanvas canvas, int x1, int y1, int x2, int y2, int color)
        {
            return new CreateRectangle(canvas,x1,y1,x2,y2,color);
        }
    }
}