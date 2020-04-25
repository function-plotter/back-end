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
            // facut ceva pentru functii, altceva pentru integrale ??
            return new List<Pair>();
        }
    }
}
