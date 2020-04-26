using System.Collections.Generic;
using function_plotter.Models;
using function_plotter.Solvers;
using Microsoft.AspNetCore.Mvc;

namespace function_plotter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SolveController : ControllerBase
    {
        [HttpPost]
        public IList<Pair> Post(FunctionPlotter functionPlotter)
        {
            return new Solver(functionPlotter).Solve();
        }
    }
}