using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Ufo
{
    internal class PointD : IEquatable<PointD>, ICloneable
    {
        public double X { get; set; }
        public double Y { get; set; }

        public PointD(double x, double y)
        {
            X = x;
            Y = y;
        }

        public PointD() : this(0, 0)
        {

        }

        public bool Equals(PointD? other)
        {
            if (other is null) return false;

            return X == other.X && Y == other.Y;
        }

        public object Clone()
        {
            return new PointD(X, Y);
        }
    }
}
