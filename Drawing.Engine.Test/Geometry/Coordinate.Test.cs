using Xunit;
using Drawing.Engine.Geometry;

namespace Drawing.Engine.Test.Geometry
{
    public class CoordinateTest
    {
        [Theory]
        [InlineData(int.MinValue,int.MinValue)]
        [InlineData(0,0)]
        [InlineData(int.MaxValue,int.MaxValue)]
        public void Constructor(int x, int y){
            var coordinate = new Coordinate(x , y);
            Assert.Equal( x, coordinate.X);
            Assert.Equal( y, coordinate.Y);
        }

        [Theory]
        [InlineData(int.MinValue,int.MinValue)]
        [InlineData(0,0)]
        [InlineData(int.MaxValue,int.MaxValue)]
        public void EqualTest(int x, int y)
        {
            Assert.Equal(new Coordinate(x,y), new Coordinate(x,y));
        }

        [Theory]
        [InlineData(int.MinValue,int.MinValue)]
        [InlineData(0,0)]
        [InlineData(int.MaxValue,int.MaxValue)]
        public void HashCodeTest(int x, int y)
        {
            var a = new Coordinate(x,y);
            var b = new Coordinate(x,y);
            Assert.Equal(a.GetHashCode(), b.GetHashCode());
        }
    }

}