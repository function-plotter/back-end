using System;
using function_plotter.Models;
using System.Collections.Generic;
using System.Diagnostics;
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

            if (_functionSolver.Function.Type == FunctionType.Integral)
            {
                var integralRangeLowerBoundX = _functionSolver.Function.Range[0];
                var integralRangeLowerBoundY = SolveForX(integralRangeLowerBoundX, _functionSolver.Function);
                var integralRangeUpperBoundX = _functionSolver.Function.Range[1];
                var integralRangeUpperBoundY = SolveForX(integralRangeUpperBoundX, _functionSolver.Function);

                results.Add(new Pair(integralRangeLowerBoundX, integralRangeLowerBoundY));
                results.Add(new Pair(integralRangeUpperBoundX, integralRangeUpperBoundY));

                results = results.OrderBy(element => element.X).ToList();
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
                var rightExpression = SolveForX(x, function.Args.ElementAt(1));
                var leftExpression = SolveForX(x, function.Args.ElementAt(0));

                Trace.Assert(rightExpression != 0, "Division by 0 not allowed!");

                return leftExpression / rightExpression;
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
                return SolveForX(x, function.Args.ElementAt(0));
            }
        }

        public double ComputeIntegral(Function function, int precision)
        {
            var numberOfRectangles = precision;
            var rectangleWidth = (_functionSolver.Range.UpperBound * 1.0d - _functionSolver.Range.LowerBound) / numberOfRectangles * 1.0d;
            var result = 0.0;

            for (int i = 0; i < numberOfRectangles; i++)
            {
                var x_i = _functionSolver.Range.LowerBound + (i - 1) * rectangleWidth;
                result += rectangleWidth * SolveForX(x_i, function);
            }

            return result;
        }
    }
}
