using System;
using Xunit;
using Moq;
using Drawing.Engine;
using Drawing.Engine.Command;
using Drawing.Engine.Invoker;
using Drawing.Engine.Receiver;

namespace Drawing.Engine.Invoker.Test
{
    public class DrawingServiceBaseTest 
    {
        [Fact]
        public void ShouldCreateCanvas()
        {
            var mock = new Mock<ICanvasFactory>();
            mock.Setup( factory => factory.CreateCanvas(10,10) );

            var service = new DrawingServiceBase((ICanvasFactory)mock.Object);
            service.CreateCanvas(10,10);

            mock.Verify( factory => factory.CreateCanvas(10,10), Times.Once() );
        }


        [Fact]
        public void ShouldCreateLine()
        {
            ICanvas canvas = new SimpleCanvas(10,10);
            var canvasFactory = new Mock<ICanvasFactory>();
            var cmdFactory = new Mock<ICommandFactory>();

            canvasFactory.Setup( canvasF => canvasF.CreateCanvas(10,10) ).Returns(canvas);
            cmdFactory.Setup( cmdF => cmdF.CreateLine(canvas,0,0,1,1,100));

            var service = new DrawingServiceBase(canvasFactory.Object, cmdFactory.Object);
            service.CreateCanvas(10,10);
            service.CreateLine(0,0,1,1,100);

            cmdFactory.Verify( cmdF => cmdF.CreateLine(canvas,0,0,1,1,100), Times.Once() );
        }

        [Fact]
        public void ShouldCreateRectangle()
        {
            ICanvas canvas = new SimpleCanvas(10,10);
            var canvasFactory = new Mock<ICanvasFactory>();
            var cmdFactory = new Mock<ICommandFactory>();

            canvasFactory.Setup( canvasF => canvasF.CreateCanvas(10,10) ).Returns(canvas);
            cmdFactory.Setup( cmdF => cmdF.CreateRectangle(canvas,0,0,1,1,100));

            var service = new DrawingServiceBase(canvasFactory.Object, cmdFactory.Object);
            service.CreateCanvas(10,10);
            service.CreateRectangle(0,0,1,1,100);

            cmdFactory.Verify( cmdF => cmdF.CreateRectangle(canvas,0,0,1,1,100), Times.Once() );
        }

        [Fact]
        public void ShouldCreateBucketFill()
        {
            ICanvas canvas = new SimpleCanvas(10,10);
            var canvasFactory = new Mock<ICanvasFactory>();
            var cmdFactory = new Mock<ICommandFactory>();

            canvasFactory.Setup( canvasF => canvasF.CreateCanvas(10,10) ).Returns(canvas);
            cmdFactory.Setup( cmdF => cmdF.CreateBucketFill(canvas,0,0,100));

            var service = new DrawingServiceBase(canvasFactory.Object, cmdFactory.Object);
            service.CreateCanvas(10,10);
            service.BucketFill(0,0,100);

            cmdFactory.Verify( cmdF => cmdF.CreateBucketFill(canvas,0,0,100), Times.Once() );
        }
    }
}
