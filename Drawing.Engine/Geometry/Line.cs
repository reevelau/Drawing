using System;
using System.Collections.Generic;

namespace Drawing.Engine.Geometry
{
    /// <summary>
    /// Line class helps to calculates all coordinates that lies on Start and End (inclusive)
    /// </summary>
    public class Line : IShape
    {
        protected Coordinate Start { get; set; }
        protected Coordinate End { get; set; }
        public Line(Coordinate start, Coordinate end)
        {
            Start = start;
            End = end;
        }
        public List<Coordinate> CalculateCoordinate()
        {
            var ret = new List<Coordinate>();

            var xInit = Start.X < End.X ? Start.X : End.X;
            int xDiff = Math.Abs( Start.X - End.X );

            if(xDiff != 0)
            {
                // General case..
                var slope = GetSlope();
                var offset = GetOffset();

                for(int i = xInit; i <= xInit + xDiff; i++)
                {
                    int y = (int) Math.Round((slope * i + offset), MidpointRounding.AwayFromZero);
                    ret.Add(new Coordinate(i,y));
                }
            }
            else
            {
                // vertical line..
                var yInit = Start.Y < End.Y ? Start.Y : End.Y;
                int yDiff = Math.Abs( Start.Y - End.Y);

                for(int i = yInit; i <= yInit + yDiff; i++)
                {
                    int x = Start.X;
                    int y = i;
                    ret.Add(new Coordinate(x,y));
                }
            }

            return ret;
        }

        private double GetSlope()
        {
            double yDelta = End.Y - Start.Y;
            double xDelta = End.X - Start.X;

            return yDelta / xDelta;
        }

        private double GetOffset()
        {
            double slope = GetSlope();
            return -1 * slope * End.X + End.Y;
        }
    }

}