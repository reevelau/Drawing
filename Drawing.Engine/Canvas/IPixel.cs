using System;

namespace Drawing.Engine.Canvas
{
    /// <summary>
    /// 
    /// </summary>
    interface IPixel
    {
        /// <summary>
        /// The x-coordination 
        /// </summary>
        int X { get; set; }
        
        /// <summary>
        /// The y-coordination 
        /// </summary>
        int Y { get; set; }
        
        /// <summary>
        /// The 32-bit encoded color 
        /// </summary>
        int Color { get; set; }
    }

}