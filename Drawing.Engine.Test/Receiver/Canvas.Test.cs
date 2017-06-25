using Xunit;
using Drawing.Engine.Receiver;

namespace Drawing.Engine.Test.Receiver
{
    public class CanvasTest
    {
        [Fact]
        public void ConstructorTest(){
            ICanvas canvas = new SimpleCanvas(3,4);

            Assert.Equal(3, canvas.Width);
            Assert.Equal(4, canvas.Height);
        }

        private ICanvas TestingCanvas;
        public CanvasTest()
        {
            TestingCanvas = new SimpleCanvas(20,4);
        }

        public void Dispose()
        {

        }

        [Theory]
        [InlineData(0,0)]
        [InlineData(5,2)]
        [InlineData(19,3)]
        public void SimpleDraw(int x, int y)
        {
            int color = (int)('x' - '0');
            TestingCanvas.Draw(x,y, color);
            IPixel ipixel = TestingCanvas.GetPixel(x,y);

            Assert.Equal(x, ipixel.X);
            Assert.Equal(y, ipixel.Y);
            Assert.Equal(color, ipixel.Color);
        }

        [Theory]
        [InlineData(-1,-1)]
        [InlineData(0,-1)]
        [InlineData(-1,0)]
        [InlineData(100, 100)]
        [InlineData(0,100)]
        [InlineData(100,0)]
        public void IncorrectDrawCoordinates(int x, int y)
        {
            int color = (int)('x' - '0');
            var exception = Record.Exception(() => TestingCanvas.Draw(x, y, color));
            Assert.IsType(typeof(IncorrectCoordiante), exception);
        }
    }
}