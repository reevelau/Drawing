using Xunit;
using System;
using Drawing.Engine.Geometry;
using System.Collections.Generic;
using static Drawing.Engine.Test.Geometry.Util;

namespace Drawing.Engine.Test.Geometry
{
    public class RectangleTest
    {
        [Theory]
        [InlineData(13, 0, 17, 2)]
        [InlineData(17, 2, 13, 0)]
        [InlineData(13, 2, 17, 0)]
        [InlineData(17, 0, 13, 2)]
        public void DrawRectangle(int x1, int y1, int x2, int y2){
             var start = new Coordinate(x1,y1);
            var end = new Coordinate(x2,y2);
            var line = new Rectangle(start,end);
            var coordindates = line.CalculateCoordinate();


            var expected = new List<Coordinate>{
                new Coordinate(13,0),
                new Coordinate(14,0),
                new Coordinate(15,0),
                new Coordinate(16,0),
                new Coordinate(17,0),
                new Coordinate(13,2),
                new Coordinate(14,2),
                new Coordinate(15,2),
                new Coordinate(16,2),
                new Coordinate(17,2),
                new Coordinate(13,1),
                new Coordinate(17,1)
            };

            AssertCoordinatesEqual(expected, coordindates);
        }
    }

}