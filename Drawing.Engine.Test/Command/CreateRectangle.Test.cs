using Xunit;
using Drawing.Engine.Command;
using Moq;
using Drawing.Engine.Receiver;

namespace Drawing.Engine.Test.Command
{
    public class CreateRectangleTest
    {
        [Fact]
        public void CreateASquare()
        {
            var mock = new Mock<ICanvas>();

            mock.Setup( canvas => canvas.Draw(0,0,1));
            mock.Setup( canvas => canvas.Draw(0,1,1));
            mock.Setup( canvas => canvas.Draw(1,0,1));
            mock.Setup( canvas => canvas.Draw(1,1,1));

            CreateRectangle rect = new CreateRectangle(mock.Object, 0, 0, 1, 1, 1);

            rect.Execute();

            mock.Verify(canvas => canvas.Draw(0,0,1), Times.Once());
            mock.Verify(canvas => canvas.Draw(0,1,1), Times.Once());
            mock.Verify(canvas => canvas.Draw(1,0,1), Times.Once());
            mock.Verify(canvas => canvas.Draw(1,1,1), Times.Once());
        }
        
    }

}