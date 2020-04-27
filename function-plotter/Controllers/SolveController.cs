using function_plotter.Models;
using function_plotter.Solvers;
using function_plotter.Validators;
using Microsoft.AspNetCore.Mvc;

namespace function_plotter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SolveController : ControllerBase
    {
        private readonly FunctionPlotterValidator _validator;

        public SolveController()
        {
            _validator = new FunctionPlotterValidator();
        }

        [HttpPost]
        public IActionResult Post(FunctionPlotter functionPlotter)
        {
            var validationResult = _validator.Validate(functionPlotter);

            if(!validationResult.IsValid)
            {
                string message = string.Empty;

                foreach(var error in validationResult.Errors)
                {
                    message += $"{error}/n";
                }

                return BadRequest(message);
            }

            var result = new Solver(functionPlotter).Solve();
            
            return Ok(result);
        }
    }
}