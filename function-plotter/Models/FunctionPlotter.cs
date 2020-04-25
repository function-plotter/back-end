using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace function_plotter.Models
{
    public class FunctionPlotter
    {
        public Function Function { get; set; }
        public Pair Interval { get; set; }
        public double Step { get; set; }
    }
}
