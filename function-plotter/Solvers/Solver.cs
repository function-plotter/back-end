using function_plotter.Models;
using System.Collections.Generic;

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
            return new List<Pair>();
        }
    }
}
