using System;
using Drawing.Engine.Receiver;
using System.IO;
using Drawing.Engine.Utility;

namespace Drawing.Engine.Text
{
    public class CanvasPrinter : ICanvasPrinter
    {
        TextWriter Output;
        public CanvasPrinter(TextWriter output)
        {
            Output = output;
        }

        public void Print(ICanvas Canvas)
        {
            for(int i = 0; i < Canvas.Width + 2; i++ )
            {
                Output.Write("-");
            }
            Output.WriteLine();

            for(int i = 0; i < Canvas.Height; i++)
            {
                Output.Write("|");
                for(int j=0; j< Canvas.Width; j++)
                {
                    IPixel pixel = Canvas.GetPixel(j,i);
                    char color = ' ';
                    if(pixel.Color != 0)
                    {
                        color = Convert.ToChar(pixel.Color);
                    }
                    Output.Write(  $"{color}" );
                }
                Output.Write("|");
                Output.WriteLine();
            }

            for(int i = 0; i < Canvas.Width + 2; i++ )
            {
                Output.Write("-");
            }
            Output.WriteLine();
            Output.WriteLine();
        }
    }

}