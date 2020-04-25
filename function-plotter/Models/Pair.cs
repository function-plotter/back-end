using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
