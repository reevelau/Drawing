using System;

namespace Drawing.Engine.Receiver
{
    public class Pixel : IPixel
    {
        public Pixel()
        {
            x = 0;
            y = 0;
            color = 0;
        }

        public Pixel(IPixel other)
        {
            x = other.X;
            y = other.Y;
            color = other.Color;
        }
        
        public Pixel(int in_x, int in_y, int in_color)
        {
            x = in_x;
            y = in_y;
            color = in_color;
        }

        private int x;
        private int y;
        private int color;

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        public int Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }
    }

}