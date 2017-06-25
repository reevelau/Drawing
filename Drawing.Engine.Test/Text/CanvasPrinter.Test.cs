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

    public class CanvasPrinterTest
    {
        [Fact]
        public void PrintToOutputStream()
        {
            var OutputMock = new Mock<TextWriter>();

            string outbuffer = "";
            OutputMock.Setup( console => console.Write(It.IsAny<string>()) )
                .Callback((string s)=> outbuffer += s);
            OutputMock.Setup( console => console.WriteLine(It.IsAny<string>()) )
                .Callback( (string s)=> outbuffer += s + Environment.NewLine );
            OutputMock.Setup( console => console.WriteLine() )
                .Callback( ()=> outbuffer +=  Environment.NewLine );

            var printer = new CanvasPrinter(OutputMock.Object);
            ICanvas canvas = new SimpleCanvas(2,2);

            printer.Print(canvas);

            string expected =   "----" + Environment.NewLine +
                                "|  |" + Environment.NewLine +
                                "|  |" + Environment.NewLine +
                                "----" + Environment.NewLine + Environment.NewLine ;
            
            Assert.Equal(expected, outbuffer);
        }
    }
}