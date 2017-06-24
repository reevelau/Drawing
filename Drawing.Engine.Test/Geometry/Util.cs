using Xunit;
using System;
using Drawing.Engine.Geometry;
using System.Collections.Generic;
using System.Linq;

namespace Drawing.Engine.Test.Geometry
{
    class Util
    {
        public static void AssertCoordinatesEqual(List<Coordinate> expected, List<Coordinate> actual){
            try
            {
                Assert.Equal(expected.Count, actual.Count);
                bool areSame = !expected.Except(actual).Any();
                Assert.True(areSame);
            }
            catch(Exception)
            {
                Console.WriteLine($"Expected: {string.Join(" ", expected)}");
                Console.WriteLine($"Actual: {string.Join(" ", actual)}");
                throw;
            }
        }
    }
}