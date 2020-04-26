using System;

namespace function_plotter.Models
{
    public class Pair
    {
        public Pair(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }

        public override bool Equals(object obj)
        { 
            return obj != null && double.Equals(X, ((Pair) obj).X) && double.Equals(Y, ((Pair) obj).Y);
        }
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
    }
}
