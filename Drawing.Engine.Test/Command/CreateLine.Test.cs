using Xunit;
using Drawing.Engine.Command;
using Moq;
using Drawing.Engine.Receiver;

namespace Drawing.Engine.Test.Command
{
    public class CreateLineTest
    {
        [Fact]
        public void CreateALine()
        {
            var mock = new Mock<ICanvas>();
            mock.Setup( canvas => canvas.Draw(0,0,1));
            mock.Setup( canvas => canvas.Draw(1,0,1));
            mock.Setup( canvas => canvas.Draw(2,0,1));

            CreateLine line = new CreateLine(mock.Object, 0,0, 2,0, 1);

            line.Execute();

            mock.Verify(canvas => canvas.Draw(0,0,1), Times.Once());
            mock.Verify(canvas => canvas.Draw(1,0,1), Times.Once());
            mock.Verify(canvas => canvas.Draw(2,0,1), Times.Once());

        }
    }

}