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
        [HttpGet]
        public IList<Pair> Get(FunctionPlotter functionPlotter)
        {
            return new Solver(functionPlotter).Solve();
        }
    }
}