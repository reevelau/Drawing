using System;
using System.Collections.Generic;

namespace Drawing.Engine.Geometry
{
    public class Rectangle : IShape
    {
        Coordinate UpperLeft { get; set; }
        Coordinate LowerRight { get; set; }
        public Rectangle(Coordinate upperLeft, Coordinate lowerRight)
        {
            UpperLeft = upperLeft;
            LowerRight = lowerRight;
        }

        public List<Coordinate> CalculateCoordinate()
        {
            // rectangle is just 4 lines
            var ret = new List<Coordinate>();

            var line1 = new Line(UpperLeft, GetUpperRight());

            ret.AddRange(line1.CalculateCoordinate());

            var line2 = new Line(GetUpperRight(), LowerRight);

            ret.AddRange(line2.CalculateCoordinate());

            var line3 = new Line(LowerRight, GetLowerLeft());

            ret.AddRange(line3.CalculateCoordinate());

            var line4 = new Line(GetLowerLeft(), UpperLeft);

            ret.AddRange(line4.CalculateCoordinate());


            return Deduplicate(ret);
        }

        private Coordinate GetUpperRight()
        {
            return new Coordinate(LowerRight.X, UpperLeft.Y);
        }

        private Coordinate GetLowerLeft()
        {
            return new Coordinate(UpperLeft.X, LowerRight.Y);
        }

        private List<Coordinate> Deduplicate(List<Coordinate> list)
        {
            List<Coordinate> ret = new List<Coordinate>();
            HashSet<Coordinate> hash = new HashSet<Coordinate>();
            foreach( var i in list )
            {
                if(!hash.Contains(i))
                {
                    ret.Add(i);
                    hash.Add(i);
                }
            }

            return ret;
        }
    }
}