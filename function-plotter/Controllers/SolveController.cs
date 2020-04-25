using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using function_plotter.Models;
using Microsoft.AspNetCore.Mvc;

namespace function_plotter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SolveController : ControllerBase
    {
        [HttpGet]
        public IList<Pair> Get()
        {
            var response = new List<Pair>();
            response.Add(new Pair(0, 1));
            response.Add(new Pair(1, 2));
            response.Add(new Pair(2, 3));
            response.Add(new Pair(3, 4));
            response.Add(new Pair(4, 5));

            return response;
        }
    }
}