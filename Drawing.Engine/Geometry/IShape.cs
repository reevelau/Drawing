using System;
using System.Collections.Generic;

namespace Drawing.Engine.Geometry
{
    interface IShape
    {
        List<Coordinate> CalculateCoordinate();
    }

}