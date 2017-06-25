using Xunit;
using Drawing.Engine.Command;
using Moq;
using Drawing.Engine.Receiver;

namespace Drawing.Engine.Test.Command
{
    public class BucketFillTest
    {
        IPixel [,] Prepare2x2Map(){
            IPixel [,] map = new Pixel[2,2];
            map[0,0] = new Pixel(0,0,0);
            map[0,1] = new Pixel(0,1,0);
            map[1,0] = new Pixel(1,0,0);
            map[1,1] = new Pixel(1,1,0);
            return map;
        }

        [Fact]
        public void FillTheCancas()
        {
            var mock = new Mock<ICanvas>();
            mock.SetupGet( canvas => canvas.Width ).Returns(2);
            mock.SetupGet( canvas => canvas.Height ).Returns(2);
            
            IPixel [,] map = Prepare2x2Map();

            
            mock.Setup( canvas => canvas.GetPixel(0,0) ).Returns(map[0,0]);
            mock.Setup( canvas => canvas.GetPixel(0,1) ).Returns(map[0,1]);
            mock.Setup( canvas => canvas.GetPixel(1,0) ).Returns(map[1,0]);
            mock.Setup( canvas => canvas.GetPixel(1,1) ).Returns(map[1,1]);

            mock.Setup( canvas => canvas.Draw(0,0,1)).Callback(()=> map[0,0].Color = 1);
            mock.Setup( canvas => canvas.Draw(0,1,1)).Callback(()=> map[0,1].Color = 1);
            mock.Setup( canvas => canvas.Draw(1,0,1)).Callback(()=> map[1,0].Color = 1);
            mock.Setup( canvas => canvas.Draw(1,1,1)).Callback(()=> map[1,1].Color = 1);
            


            BucketFill fill = new  BucketFill(mock.Object, 0, 0, 1);

            fill.Execute();

            mock.Verify(canvas => canvas.Draw(0,0,1), Times.Once());
            mock.Verify(canvas => canvas.Draw(0,1,1), Times.Once());
            mock.Verify(canvas => canvas.Draw(1,0,1), Times.Once());
            mock.Verify(canvas => canvas.Draw(1,1,1), Times.Once());

            Assert.Equal(1, map[0,0].Color);
            Assert.Equal(1, map[0,1].Color);
            Assert.Equal(1, map[1,0].Color);
            Assert.Equal(1, map[1,1].Color);
            
        }

        [Fact]
        public void ShouldSkipTheAlien()
        {
            var mock = new Mock<ICanvas>();
            mock.SetupGet( canvas => canvas.Width ).Returns(2);
            mock.SetupGet( canvas => canvas.Height ).Returns(2);
            
            IPixel [,] map = Prepare2x2Map();

            map[1,1].Color = 3; // cell [1,1] is in different color
            
            mock.Setup( canvas => canvas.GetPixel(0,0) ).Returns(map[0,0]);
            mock.Setup( canvas => canvas.GetPixel(0,1) ).Returns(map[0,1]);
            mock.Setup( canvas => canvas.GetPixel(1,0) ).Returns(map[1,0]);
            mock.Setup( canvas => canvas.GetPixel(1,1) ).Returns(map[1,1]);

            mock.Setup( canvas => canvas.Draw(0,0,1)).Callback(()=> map[0,0].Color = 1);
            mock.Setup( canvas => canvas.Draw(0,1,1)).Callback(()=> map[0,1].Color = 1);
            mock.Setup( canvas => canvas.Draw(1,0,1)).Callback(()=> map[1,0].Color = 1);
            mock.Setup( canvas => canvas.Draw(1,1,1)).Callback(()=> map[1,1].Color = 1);
            
            BucketFill fill = new  BucketFill(mock.Object, 0, 0, 1);

            fill.Execute();

            mock.Verify(canvas => canvas.Draw(0,0,1), Times.Once());
            mock.Verify(canvas => canvas.Draw(0,1,1), Times.Once());
            mock.Verify(canvas => canvas.Draw(1,0,1), Times.Once());
            mock.Verify(canvas => canvas.Draw(1,1,1), Times.Never()); // cell [1,1] is in different color

            Assert.Equal(1, map[0,0].Color);
            Assert.Equal(1, map[0,1].Color);
            Assert.Equal(1, map[1,0].Color);
            Assert.Equal(3, map[1,1].Color); // cell [1,1] is in different color
            
        }

        [Fact]
        public void ShouldDyeNeighborInSameColor()
        {
            var mock = new Mock<ICanvas>();
            mock.SetupGet( canvas => canvas.Width ).Returns(2);
            mock.SetupGet( canvas => canvas.Height ).Returns(2);
            
            IPixel [,] map = Prepare2x2Map();

            map[0,0].Color = 10;
            map[0,1].Color = 10; 
            
            mock.Setup( canvas => canvas.GetPixel(0,0) ).Returns(map[0,0]);
            mock.Setup( canvas => canvas.GetPixel(0,1) ).Returns(map[0,1]);
            mock.Setup( canvas => canvas.GetPixel(1,0) ).Returns(map[1,0]);
            mock.Setup( canvas => canvas.GetPixel(1,1) ).Returns(map[1,1]);

            mock.Setup( canvas => canvas.Draw(0,0,1)).Callback(()=> map[0,0].Color = 1);
            mock.Setup( canvas => canvas.Draw(0,1,1)).Callback(()=> map[0,1].Color = 1);
            mock.Setup( canvas => canvas.Draw(1,0,1)).Callback(()=> map[1,0].Color = 1);
            mock.Setup( canvas => canvas.Draw(1,1,1)).Callback(()=> map[1,1].Color = 1);
            
            BucketFill fill = new  BucketFill(mock.Object, 0, 0, 1);

            fill.Execute();

            mock.Verify(canvas => canvas.Draw(0,0,1), Times.Once());
            mock.Verify(canvas => canvas.Draw(0,1,1), Times.Once());
            mock.Verify(canvas => canvas.Draw(1,0,1), Times.Never()); // cell [1,0] is in different color
            mock.Verify(canvas => canvas.Draw(1,1,1), Times.Never()); // cell [1,1] is in different color

            Assert.Equal(1, map[0,0].Color);
            Assert.Equal(1, map[0,1].Color);
            Assert.Equal(0, map[1,0].Color); // cell [1,0] is in different color
            Assert.Equal(0, map[1,1].Color); // cell [1,1] is in different color
            
        }
    }

}