using function_plotter.Models;
using function_plotter.Validators;
using NUnit.Framework;
using System.Collections.Generic;
using Range = function_plotter.Models.Range;

namespace function_plotter.Tests
{
    [TestFixture]
    public class ValidatorTests
    {
        private FunctionPlotterValidator _validator;

        [SetUp]
        public void Init()
        {
            _validator = new FunctionPlotterValidator();
        }

        [Test]
        public void Should_Invalidate_If_Object_Is_Null()
        {
            var functionPlotter = new FunctionPlotter();

            var validationResult = _validator.Validate(functionPlotter);

            Assert.IsFalse(validationResult.IsValid);
        }

        [Test]
        public void Should_Invalidate_If_Function_Is_Null()
        {
            var functionPlotter = new FunctionPlotter
            {
                Range = new Range { LowerBound = 1, UpperBound = 2, Step = 0.2}
            };

            var validationResult = _validator.Validate(functionPlotter);

            Assert.IsFalse(validationResult.IsValid);
        }

        [Test]
        public void Should_Invalidate_If_Range_Is_Null()
        {
            var functionPlotter = new FunctionPlotter
            {
                Function = new Function
                {
                    Type = FunctionType.Constant,
                    Value = 3
                },
            };

            var validationResult = _validator.Validate(functionPlotter);

            Assert.IsFalse(validationResult.IsValid);
        }

        [Test]
        public void Should_Invalidate_If_Step_Is_Negative()
        {
            var functionPlotter = new FunctionPlotter
            {
                Range = new Range { LowerBound = 1, UpperBound = 6, Step = -1 },
                Function = new Function
                {
                    Type = FunctionType.Power,
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

            var validationResult = _validator.Validate(functionPlotter);

            Assert.IsFalse(validationResult.IsValid);
        }

        [Test]
        public void Should_Invalidate_If_Step_Is_0()
        {
            var functionPlotter = new FunctionPlotter
            {
                Range = new Range { LowerBound = 1, UpperBound = 6, Step = 0 },
                Function = new Function
                {
                    Type = FunctionType.Power,
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

            var validationResult = new FunctionPlotterValidator().Validate(functionPlotter);

            Assert.IsFalse(validationResult.IsValid);
        }

        [Test]
        public void Should_Invalidate_If_Integral_Function_Has_No_Range()
        {
            var functionPlotter = new FunctionPlotter
            {
                Range = new Range { LowerBound = 1, UpperBound = 6, Step = 0 },
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

            var validationResult = _validator.Validate(functionPlotter);

            Assert.IsFalse(validationResult.IsValid);
        }

        [Test]
        public void Should_Validate_If_Integral_Is_Correct()
        {
            var functionPlotter = new FunctionPlotter
            {
                Range = new Range { LowerBound = 1, UpperBound = 6, Step = 0.1 },
                Function = new Function
                {
                    Type = FunctionType.Integral,
                    Range = new List<int> { 2, 4 },
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

            var validationResult = _validator.Validate(functionPlotter);

            Assert.IsTrue(validationResult.IsValid);
        }

        [Test]
        public void Should_Validate_If_Function_Plotter_Is_Correct()
        {
            var functionPlotter = new FunctionPlotter
            {
                Range = new Range { LowerBound = 1, UpperBound = 6, Step = 0.1 },
                Function = new Function
                {
                    Type = FunctionType.Addition,
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

            var validationResult = _validator.Validate(functionPlotter);

            Assert.IsTrue(validationResult.IsValid);
        }
    }
}
