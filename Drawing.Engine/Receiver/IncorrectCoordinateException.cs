using System;

namespace Drawing.Engine.Receiver
{
    public class IncorrectCoordiante : Exception
    {
        public int X {get; private set;}
        public int Y {get; private set;}
        public IncorrectCoordiante(int x, int y)
            :base()
        {
            X = x;
            Y = y;
        }
    }

}