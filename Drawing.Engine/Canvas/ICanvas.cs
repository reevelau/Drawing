using System;

namespace Drawing.Engine.Canvas
{
    /// <summary>
    /// Canvas Interface
    /// Assumption
    /// 1. Width and Height is 32-bit bound
    /// </summary>
    interface ICanvas
    {
        int Width{ get; set; }
        int Height{ get; set; }

        IPixel GetPixel(int x, int y);

        void Draw(int x, int y);

        void Draw(int x, int y, int color);
    }

}