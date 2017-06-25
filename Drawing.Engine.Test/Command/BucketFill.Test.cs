using Xunit;
using Drawing.Engine.Command;
using Moq;
using Drawing.Engine.Receiver;

namespace Drawing.Engine.Test.Command
{
    public class BucketFillTest
    {
        [Fact]
        public void FillTheCancas()
        {
            var mock = new Mock<ICanvas>();
            mock.SetupGet( canvas => canvas.Width ).Returns(2);
            mock.SetupGet( canvas => canvas.Height ).Returns(2);
            
            IPixel [,] map = new Pixel[2,2];
            map[0,0] = new Pixel(0,0,0);
            map[0,1] = new Pixel(0,1,0);
            map[1,0] = new Pixel(1,0,0);
            map[1,1] = new Pixel(1,1,0);

            
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
            
        }
    }

}