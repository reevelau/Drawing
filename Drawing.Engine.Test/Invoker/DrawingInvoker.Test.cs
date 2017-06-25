using Xunit;
using Drawing.Engine.Command;
using Drawing.Engine.Invoker;
using Moq;

namespace Drawing.Engine.Test.Invoker
{
    public class InvokerTest
    {

        [Fact]
        public void StoreAndExecute()
        {
            var mock = new Mock<ICanvasCommand>();

            mock.Setup( cmd => cmd.Execute() );

            var invoker = new DrawingInvoker();

            invoker.StoreAndExecute(mock.Object);

            mock.Verify( cmd => cmd.Execute(), Times.Once() );
        }

    }
}