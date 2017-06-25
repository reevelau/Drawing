using System;

namespace Drawing.Engine.Receiver
{
    public class IncorrectCoordianteException : Exception
    {
        public int X {get; private set;}
        public int Y {get; private set;}
        public IncorrectCoordianteException(int x, int y)
            :base()
        {
            X = x;
            Y = y;
        }
    }

}