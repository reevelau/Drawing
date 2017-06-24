using Xunit;
using System;
using Drawing.Engine.Geometry;
using System.Collections.Generic;
using System.Linq;
using static Drawing.Engine.Test.Geometry.Util;

namespace Drawing.Engine.Test.Geometry
{
    public class LineTest
    {
        

        [Theory]
        [InlineData(1, 1, 1, 1)]
        public void DrawSingleLengthLine(int x1, int y1, int x2, int y2)
        {
            var start = new Coordinate(x1,y1);
            var end = new Coordinate(x2,y2);
            var line = new Line(start,end);
            var coordindates = line.CalculateCoordinate();

            var expected = new List<Coordinate>{
                new Coordinate(1,1)
            };

            AssertCoordinatesEqual(expected,coordindates);
        }

        [Theory]
        [InlineData(0, 1, 5, 1)]
        [InlineData(5, 1, 0, 1)]
        public void DrawHorizontalLine(int x1, int y1, int x2, int y2)
        {
            var start = new Coordinate(x1,y1);
            var end = new Coordinate(x2,y2);

            var line = new Line(start, end);
            var coordindates = line.CalculateCoordinate();

            var expected = new List<Coordinate>{
                new Coordinate(0,1),
                new Coordinate(1,1),
                new Coordinate(2,1),
                new Coordinate(3,1),
                new Coordinate(4,1),
                new Coordinate(5,1),
            };

            AssertCoordinatesEqual(expected, coordindates);
        }

        [Theory]
        [InlineData(5, 2, 5, 3)]
        [InlineData(5, 3, 5, 2)]
        public void DrawVerticalLine(int x1, int y1, int x2, int y2)
        {
            var start = new Coordinate(x1,y1);
            var end = new Coordinate(x2,y2);

            var line = new Line(start, end);
            var coordindates = line.CalculateCoordinate();

            var expected = new List<Coordinate>{
                new Coordinate(5,2),
                new Coordinate(5,3)
            };

            AssertCoordinatesEqual(expected,coordindates);
        }

        [Theory]
        [InlineData(1, 1, 3, 3)]
        [InlineData(3, 3, 1, 1)]
        public void DrawDiagonalLineOfSquare(int x1, int y1, int x2, int y2){
            var start = new Coordinate(x1,y1);
            var end = new Coordinate(x2,y2);

            var line = new Line(start, end);
            var coordindates = line.CalculateCoordinate();

            var expected = new List<Coordinate>{
                new Coordinate(1,1),
                new Coordinate(2,2),
                new Coordinate(3,3)
            };

            AssertCoordinatesEqual(expected,coordindates);
        }

        [Theory]
        [InlineData(1, 1, 4, 2)]
        [InlineData(4, 2, 1, 1)]
        public void DrawDiagonalLineOfRectangle(int x1, int y1, int x2, int y2){
            var start = new Coordinate(x1,y1);
            var end = new Coordinate(x2,y2);

            var line = new Line(start, end);
            var coordindates = line.CalculateCoordinate();

            var expected = new List<Coordinate>{
                new Coordinate(1,1),
                new Coordinate(2,1),
                new Coordinate(3,2),
                new Coordinate(4,2)
            };

            AssertCoordinatesEqual(expected,coordindates);
        }
    }    
}