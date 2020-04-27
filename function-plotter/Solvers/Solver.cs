using function_plotter.Models;
using System.Collections.Generic;
using System.Linq;
using static System.Math;

namespace function_plotter.Solvers
{
    public class Solver
    {
        private readonly FunctionPlotter _functionSolver;

        public Solver(FunctionPlotter functionPlotter)
        {
            _functionSolver = functionPlotter;
        }

        public List<Pair> Solve()
        {
            var results = new List<Pair>();
            for (double x = _functionSolver.Range.LowerBound; x <= _functionSolver.Range.UpperBound; x += _functionSolver.Range.Step)
            {
                var y = SolveForX(x, _functionSolver.Function);
                results.Add(new Pair(x, y));
            }

            return results;
        }

        public double SolveForX(double x, Function function)
        {
            if (function.Type == FunctionType.Variable)
            {
                return x;
            }
            else if (function.Type == FunctionType.Constant)
            {
                return function.Value.GetValueOrDefault();
            }
            else if (function.Type == FunctionType.Addition)
            {
                return SolveForX(x, function.Args.ElementAt(0)) + SolveForX(x, function.Args.ElementAt(1));
            }
            else if (function.Type == FunctionType.Subtraction)
            {
                return SolveForX(x, function.Args.ElementAt(0)) - SolveForX(x, function.Args.ElementAt(1));
            }
            else if (function.Type == FunctionType.Multiplication)
            {
                return SolveForX(x, function.Args.ElementAt(0)) * SolveForX(x, function.Args.ElementAt(1));
            }
            else if (function.Type == FunctionType.Division)
            {
                return SolveForX(x, function.Args.ElementAt(0)) / SolveForX(x, function.Args.ElementAt(1));
            }
            else if (function.Type == FunctionType.Sine)
            {
                return Sin(SolveForX(x, function.Args.ElementAt(0)));
            }
            else if (function.Type == FunctionType.Cosine)
            {
                return Cos(SolveForX(x, function.Args.ElementAt(0)));
            }
            else if (function.Type == FunctionType.Power)
            {
                return Pow(SolveForX(x, function.Args.ElementAt(0)), SolveForX(x, function.Args.ElementAt(1)));
            }
            else
            {
                return double.NaN; // This will be filled for Integrals
            }
        }
    }
}
