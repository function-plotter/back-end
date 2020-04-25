using System;
using System.Collections.Generic;

namespace function_plotter.Models
{
    public class Function
    {
        public string Type { get; set; }
        public IEnumerable<Function> Args { get; set; }
        public double? Value { get; set; }
        public FunctionType TypeEnum => (FunctionType)Enum.Parse(typeof(FunctionType), Type, true);
    }
}
