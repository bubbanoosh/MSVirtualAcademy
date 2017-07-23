using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Course.NUnit.UnitTests
{
    public class Solve
    {
        public static Tuple<double, double> Quadratic(double a, double b, double c)
        {
            var disc = b * b - 4 * a * c;

            if (disc < 0)
                throw new Exception("Cannot solve with complex roots");
            
            var root = Math.Sqrt(disc);
            return Tuple.Create(
                (-b + root) / 2 / a,
                (-b - root) / 2 / a
            );

        }
    }
}
