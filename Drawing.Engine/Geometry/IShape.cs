using System;
using System.Collections.Generic;

namespace Drawing.Engine.Geometry
{
    public interface IShape
    {
        List<Coordinate> CalculateCoordinate();
    }

}