using System;
using Xunit;
using Moq;
using Drawing.Engine;
using Drawing.Engine.Command;
using Drawing.Engine.Receiver;
using System.IO;
using Drawing.Engine.Text;

namespace Drawing.Engine.Text.Test
{
    public class DrawingServiceTest
    {
        [Fact]
        public void OverallCanvasTest()
        {
            // This is for fun, It is possible to execute all the code with System.Console
            // when using Moq!!
            var textReaderMock = new Mock<TextReader>();
            var textOutputMock = new Mock<TextWriter>();
            var textErrorMock = new Mock<TextWriter>();

            string outbuffer = "";
            ICanvas canvas = null;

            textReaderMock.SetupSequence( console=> console.ReadLine() )
                .Returns("C 20 4")
                .Returns("L 1 2 6 2")
                .Returns("L 6 3 6 4")
                .Returns("R 14 1 18 3")
                .Returns("B 10 3 o")
                .Returns("Q");
            
            textOutputMock.Setup( console => console.Write(It.IsAny<string>()) )
                .Callback((string s)=> outbuffer += s);
            textOutputMock.Setup( console => console.WriteLine(It.IsAny<string>()) )
                .Callback( (string s)=> outbuffer += s + Environment.NewLine  );
            textOutputMock.Setup( console => console.WriteLine() )
                .Callback( ()=> outbuffer +=  Environment.NewLine );
            
            var canvasPrinterMock = new Mock<ICanvasPrinter>();
            canvasPrinterMock.Setup( printer => printer.Print(It.IsAny<ICanvas>()  ) )
                .Callback( (ICanvas c) => canvas = c );

            var service = new DrawingService(
                textReaderMock.Object, 
                textOutputMock.Object, 
                textErrorMock.Object, 
                canvasPrinterMock.Object);

            service.Start();
            
            canvasPrinterMock.Verify( printer => printer.Print(It.IsAny<ICanvas>()) , Times.Exactly(5) );

            // verify the final canvas state
            string verifyBuffer = "";
            var verifyOutputMock = new Mock<TextWriter>();
            verifyOutputMock.Setup( console => console.Write(It.IsAny<string>()) )
                .Callback((string s)=> verifyBuffer += s);
            verifyOutputMock.Setup( console => console.WriteLine() )
                .Callback( ()=> verifyBuffer +=  Environment.NewLine );
            
            var verifyPrinter = new CanvasPrinter(verifyOutputMock.Object);
            verifyPrinter.Print(canvas);

            string expected =   "----------------------" + Environment.NewLine +
                                "|oooooooooooooxxxxxoo|" + Environment.NewLine +
                                "|xxxxxxooooooox   xoo|" + Environment.NewLine +
                                "|     xoooooooxxxxxoo|" + Environment.NewLine +
                                "|     xoooooooooooooo|" + Environment.NewLine +
                                "----------------------" + Environment.NewLine +
                                Environment.NewLine;
                                
            Assert.Equal(expected, verifyBuffer);
        }

        [Fact]
        public void DrawOnCanvasBeforeCreation()
        {
            var textReaderMock = new Mock<TextReader>();
            var textOutputMock = new Mock<TextWriter>();
            var textErrorMock = new Mock<TextWriter>();
            var canvasPrinterMock = new Mock<ICanvasPrinter>();

            textReaderMock.SetupSequence( console=> console.ReadLine() )
                .Returns("L 1 2 3 4")
                .Returns("Q");
            
            string error_message = "";
            textErrorMock.Setup( error=> error.WriteLine(It.IsAny<string>()) )
                .Callback((string s) => error_message = s);
                

            var service = new DrawingService(
                textReaderMock.Object, 
                textOutputMock.Object, 
                textErrorMock.Object, 
                canvasPrinterMock.Object);

            service.Start();

            Assert.True( error_message.Contains("Canvas is null") );
        }

        [Fact]
        public void DrawALineOutOfCanvas()
        {
            var textReaderMock = new Mock<TextReader>();
            var textOutputMock = new Mock<TextWriter>();
            var textErrorMock = new Mock<TextWriter>();
            var canvasPrinterMock = new Mock<ICanvasPrinter>();

            textReaderMock.SetupSequence( console=> console.ReadLine() )
                .Returns("C 2 2")
                .Returns("L 1 2 3 4")
                .Returns("Q");
            
            string error_message = "";
            textErrorMock.Setup( error=> error.WriteLine(It.IsAny<string>()) )
                .Callback((string s) => error_message = s);
                

            var service = new DrawingService(
                textReaderMock.Object, 
                textOutputMock.Object, 
                textErrorMock.Object, 
                canvasPrinterMock.Object);

            service.Start();

            Assert.True( error_message.Contains("Coordinate (2,3) is incorrect in current Canvas.") );
        }

        [Fact]
        public void UnknownCommand()
        {
            var textReaderMock = new Mock<TextReader>();
            var textOutputMock = new Mock<TextWriter>();
            var textErrorMock = new Mock<TextWriter>();
            var canvasPrinterMock = new Mock<ICanvasPrinter>();

            textReaderMock.SetupSequence( console=> console.ReadLine() )
                .Returns("Hello World")
                .Returns("Q");
            
            string error_message = "";
            textErrorMock.Setup( error=> error.WriteLine(It.IsAny<string>()) )
                .Callback((string s) => error_message = s);
                

            var service = new DrawingService(
                textReaderMock.Object, 
                textOutputMock.Object, 
                textErrorMock.Object, 
                canvasPrinterMock.Object);

            service.Start();
            
            Assert.True( error_message.Contains("Unknown Command Hello World") );
        }
    }
}