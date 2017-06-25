using System;
using Drawing.Engine.Receiver;
using Drawing.Engine.Geometry;

namespace Drawing.Engine.Command
{
    public class CreateLine : CanvasCommandBase
    {
        private int Point1X {get;set;}
        private int Point1Y {get;set;}
        private int Point2X {get;set;}
        private int Point2Y {get;set;}
        private int Color {get;set;}
        public CreateLine(ICanvas canvas, int x1, int y1, int x2, int y2, int color)
            :base (canvas)
        {
            Point1X = x1;
            Point1Y = y1;
            Point2X = x2;
            Point2Y = y2;
            Color = color;
        }
        public override void Execute()
        {
            var line = new Line(new Coordinate(Point1X, Point1Y), new Coordinate(Point2X, Point2Y));
            var points = line.CalculateCoordinate();

            foreach(var point in points)
            {
                Receiver.Draw(point.X, point.Y, Color);
            }
        }
    }
}