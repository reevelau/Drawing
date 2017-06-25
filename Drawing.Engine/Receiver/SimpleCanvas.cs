using System;

namespace Drawing.Engine.Receiver
{
    public class SimpleCanvas : ICanvas
    {
        public SimpleCanvas(int w, int h)
        {
            width = w;
            height = h;
            PixelMap = new Pixel[w,h];

            for(int i=0; i < width ; i++)
            {
                for(int j=0; j < height; j++)
                {
                    PixelMap[i,j] = new Pixel();
                    PixelMap[i,j].X = i;
                    PixelMap[i,j].Y = j;
                    PixelMap[i,j].Color = DefaultBackgroundColor;
                }
            }
        }
        private int DefaultBackgroundColor = 0;
        
        private int width;
        private int height;

        private IPixel [,] PixelMap {get;set;}

        public int Width
        {
            get
            {
                return width;
            }
        }
        public int Height
        {
            get
            {
                return height;
            }
        }
        
        public void Draw(int x, int y, int color)
        {
            if(x < 0 || y < 0 || x >= width || y >= height)
            {
                throw new IncorrectCoordianteException(x,y);
            }

            PixelMap[x,y].Color = color;
        }

        public IPixel GetPixel(int x, int y)
        {
            if(x < 0 || y < 0 || x >= width || y >= height)
            {
                throw new IncorrectCoordianteException(x,y);
            }
            return new Pixel(PixelMap[x,y]);
        }
    }
}