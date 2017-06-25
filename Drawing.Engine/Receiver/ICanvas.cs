using System;

namespace Drawing.Engine.Receiver
{
    /// <summary>
    /// Canvas Interface
    /// Assumption
    /// 1. Width and Height is 32-bit bound
    /// </summary>
    public interface ICanvas
    {
        int Width{ get; }
        int Height{ get; }

        IPixel GetPixel(int x, int y);

        void Draw(int x, int y, int color);
    }

}