using function_plotter.Controllers;
using function_plotter.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using Range = function_plotter.Models.Range;

namespace function_plotter.Tests
{
    [TestFixture]
    class SolveControllerTests
    {
        private FunctionPlotter _goodFunctionPlotter;

        private FunctionPlotter _badFunctionPlotter;

        #region INIT

        [SetUp]
        public void Init()
        {
            _goodFunctionPlotter = new FunctionPlotter
            {
                Range = new Range { LowerBound = 1, UpperBound = 6, Step = 1 },
                Function = new Function
                {
                    Type = FunctionType.Division,
                    Args = new List<Function>
                    {
                        new Function
                        {
                            Type = FunctionType.Constant,
                            Value = 2
                        },
                        new Function
                        {
                            Type = FunctionType.Variable
                        }
                    }
                }
            };

            _badFunctionPlotter = new FunctionPlotter
            {
                Range = new Range { LowerBound = 1, UpperBound = 6, Step = -1 },
                Function = new Function
                {
                    Type = FunctionType.Integral,
                    Args = new List<Function>
                    {
                        new Function
                        {
                            Type = FunctionType.Constant,
                            Value = 2
                        },
                        new Function
                        {
                            Type = FunctionType.Variable
                        }
                    }
                }
            };
        }

        #endregion

        [Test]
        public void Post_Returns_Ok()
        {
            var controller = new SolveController();

            var result = (ObjectResult)controller.Post(_goodFunctionPlotter);

            Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode);
        }

        [Test]
        public void Post_Return_Type_Is_Proper()
        {
            var controller = new SolveController();

            var result = (ObjectResult)controller.Post(_goodFunctionPlotter);

            Assert.IsInstanceOf(typeof(List<Pair>), result.Value);
        }

        [Test]
        public void Post_Return_BadRequest()
        {
            var controller = new SolveController();

            var result = (ObjectResult)controller.Post(_badFunctionPlotter);

            Assert.AreEqual((int)HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Test]
        public void Post_Return_BadRequest_DivisionBy0()
        {
            var controller = new SolveController();

            _goodFunctionPlotter.Range.LowerBound = -1;
            var result = (ObjectResult)controller.Post(_goodFunctionPlotter);

            Assert.AreEqual((int)HttpStatusCode.BadRequest, result.StatusCode);
        }
    }
}
