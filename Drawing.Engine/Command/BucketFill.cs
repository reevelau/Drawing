using System;
using Drawing.Engine.Receiver;
using Drawing.Engine.Geometry;

namespace Drawing.Engine.Command
{
    public class BucketFill : CanvasCommandBase
    {
        private int PointX {get; set;}
        private int PointY {get;set;}
        private int Color {get;set;}
        public BucketFill(ICanvas canvas, int x, int y, int color)
            :base(canvas)
        {
            PointX = x;
            PointY = y;
            Color = color;
        }

        public override void Execute()
        {
            IPixel start = Receiver.GetPixel(PointX,PointY);
            Console.WriteLine($"startX: {start.X}, startY: {start.Y}, color: {start.Color}");
            BFSFill(start.X, start.Y, start.Color, Color);
        }

        private void BFSFill(int x, int y, int originalColor, int newcolor)
        {
            if(x < 0 || y < 0 || x >= Receiver.Width || y >= Receiver.Height)
                return; // done
            
            IPixel current = Receiver.GetPixel(x,y);
            if(current.Color != originalColor)
                return; // done
            
            if(current.Color == newcolor)
                return; //done

            Receiver.Draw(x,y,newcolor);

            BFSFill( x, y-1, originalColor, newcolor); // up
            BFSFill( x+1, y, originalColor, newcolor); // right
            BFSFill( x, y+1, originalColor, newcolor); // down
            BFSFill( x-1, y, originalColor, newcolor); // left
        }
    }
}