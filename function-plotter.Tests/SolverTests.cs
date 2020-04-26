using System.Collections.Generic;
using System.Linq;
using System.Text;
using function_plotter.Models;
using function_plotter.Solvers;
using NUnit.Framework;
using static System.Math;

namespace function_plotter.Tests
{
    [TestFixture]
    class SolverTests
    {
        [Test]
        public void Should_Return_Array_From_0_4_To_1_5_Addition_By_1()
        {
            // Given
            var functionPlotter = new FunctionPlotter
            {
                Range = new Range {LowerBound = 0, UpperBound = 5, Step = 1},
                Function = new Function
                {
                    Type = FunctionType.Addition, Args = new List<Function> {new Function(), new Function()}
                }
            };
            functionPlotter.Function.Args.ElementAt(0).Type = FunctionType.Variable;
            functionPlotter.Function.Args.ElementAt(1).Type = FunctionType.Constant;
            functionPlotter.Function.Args.ElementAt(1).Value = 1;
            var solver = new Solver(functionPlotter);

            // When
            List<Pair> resultList = solver.Solve();

            // Then
            var expectedList = new List<Pair>
            {
                new Pair(0, 1),
                new Pair(1, 2),
                new Pair(2, 3),
                new Pair(3, 4),
                new Pair(4, 5),
            };

            CollectionAssert.AreEqual(expectedList, resultList);
        }

        [Test]
        public void Should_Return_Array_From_0_4_To_0_4_Variable()
        {
            // Given
            var functionPlotter = new FunctionPlotter
            {
                Range = new Range { LowerBound = 0, UpperBound = 5, Step = 1 },
                Function = new Function
                {
                    Type = FunctionType.Variable,
                }
            };
            var solver = new Solver(functionPlotter);

            // When
            List<Pair> resultList = solver.Solve();

            // Then
            var expectedList = new List<Pair>
            {
                new Pair(0, 0),
                new Pair(1, 1),
                new Pair(2, 2),
                new Pair(3, 3),
                new Pair(4, 4),
            };

            CollectionAssert.AreEqual(expectedList, resultList);
        }

        [Test]
        public void Should_Return_Array_Of_7_Constant()
        {
            // Given
            var functionPlotter = new FunctionPlotter
            {
                Range = new Range { LowerBound = 0, UpperBound = 5, Step = 1 },
                Function = new Function
                {
                    Type = FunctionType.Constant,
                    Value = 7
                }
            };
            var solver = new Solver(functionPlotter);

            // When
            List<Pair> resultList = solver.Solve();

            // Then
            var expectedList = new List<Pair>
            {
                new Pair(0, 7),
                new Pair(1, 7),
                new Pair(2, 7),
                new Pair(3, 7),
                new Pair(4, 7),
            };

            CollectionAssert.AreEqual(expectedList, resultList);
        }

        [Test]
        public void Should_Return_Array_From_1_5_To_0_4_Subtraction_By_1()
        {
            // Given
            var functionPlotter = new FunctionPlotter
            {
                Range = new Range { LowerBound = 1, UpperBound = 6, Step = 1 },
                Function = new Function
                {
                    Type = FunctionType.Subtraction,
                    Args = new List<Function> { new Function(), new Function() }
                }
            };
            functionPlotter.Function.Args.ElementAt(0).Type = FunctionType.Variable;
            functionPlotter.Function.Args.ElementAt(1).Type = FunctionType.Constant;
            functionPlotter.Function.Args.ElementAt(1).Value = 1;
            var solver = new Solver(functionPlotter);

            // When
            List<Pair> resultList = solver.Solve();

            // Then
            var expectedList = new List<Pair>
            {
                new Pair(1, 0),
                new Pair(2, 1),
                new Pair(3, 2),
                new Pair(4, 3),
                new Pair(5, 4),
            };

            CollectionAssert.AreEqual(expectedList, resultList);
        }

        [Test]
        public void Should_Return_Array_From_1_5_To_2_10_Multiply_By_2()
        {
            // Given
            var functionPlotter = new FunctionPlotter
            {
                Range = new Range { LowerBound = 1, UpperBound = 6, Step = 1 },
                Function = new Function
                {
                    Type = FunctionType.Multiplication,
                    Args = new List<Function> { new Function(), new Function() }
                }
            };
            functionPlotter.Function.Args.ElementAt(0).Type = FunctionType.Variable;
            functionPlotter.Function.Args.ElementAt(1).Type = FunctionType.Constant;
            functionPlotter.Function.Args.ElementAt(1).Value = 2;
            var solver = new Solver(functionPlotter);

            // When
            List<Pair> resultList = solver.Solve();

            // Then
            var expectedList = new List<Pair>
            {
                new Pair(1, 2),
                new Pair(2, 4),
                new Pair(3, 6),
                new Pair(4, 8),
                new Pair(5, 10),
            };

            CollectionAssert.AreEqual(expectedList, resultList);
        }

        [Test]
        public void Should_Return_Array_From_1_5_To_0dot5_2dot5_Division_By_2()
        {
            // Given
            var functionPlotter = new FunctionPlotter
            {
                Range = new Range { LowerBound = 2, UpperBound = 11, Step = 2 },
                Function = new Function
                {
                    Type = FunctionType.Division,
                    Args = new List<Function> { new Function(), new Function() }
                }
            };
            functionPlotter.Function.Args.ElementAt(0).Type = FunctionType.Variable;
            functionPlotter.Function.Args.ElementAt(1).Type = FunctionType.Constant;
            functionPlotter.Function.Args.ElementAt(1).Value = 2;
            var solver = new Solver(functionPlotter);

            // When
            List<Pair> resultList = solver.Solve();

            // Then
            var expectedList = new List<Pair>
            {
                new Pair(2, 1),
                new Pair(4, 2),
                new Pair(6, 3),
                new Pair(8, 4),
                new Pair(10, 5),
            };

            CollectionAssert.AreEqual(expectedList, resultList);
        }

        [Test]
        public void Should_Return_Sine_Of_Array_1_To_5()
        {
            // Given
            var functionPlotter = new FunctionPlotter
            {
                Range = new Range { LowerBound = 1, UpperBound = 5, Step = 1 },
                Function = new Function
                {
                    Type = FunctionType.Sine,
                    Args = new List<Function> { new Function(), new Function() }
                }
            };
            functionPlotter.Function.Args.ElementAt(0).Type = FunctionType.Variable;
            var solver = new Solver(functionPlotter);

            // When
            List<Pair> resultList = solver.Solve();

            // Then
            var expectedList = new List<Pair>
            {
                new Pair(1, Sin(1)),
                new Pair(2, Sin(2)),
                new Pair(3, Sin(3)),
                new Pair(4, Sin(4)),
            };

            CollectionAssert.AreEqual(expectedList, resultList);
        }

        [Test]
        public void Should_Return_Cosine_Of_Array_1_To_5()
        {
            // Given
            var functionPlotter = new FunctionPlotter
            {
                Range = new Range { LowerBound = 1, UpperBound = 5, Step = 1 },
                Function = new Function
                {
                    Type = FunctionType.Cosine,
                    Args = new List<Function> { new Function(), new Function() }
                }
            };
            functionPlotter.Function.Args.ElementAt(0).Type = FunctionType.Variable;
            var solver = new Solver(functionPlotter);

            // When
            List<Pair> resultList = solver.Solve();

            // Then
            var expectedList = new List<Pair>
            {
                new Pair(1, Cos(1)),
                new Pair(2, Cos(2)),
                new Pair(3, Cos(3)),
                new Pair(4, Cos(4)),
            };

            CollectionAssert.AreEqual(expectedList, resultList);
        }

        [Test]
        public void Should_Return_Array_From_1_5_Power_By_2()
        {
            // Given
            var functionPlotter = new FunctionPlotter
            {
                Range = new Range { LowerBound = 1, UpperBound = 6, Step = 1 },
                Function = new Function
                {
                    Type = FunctionType.Power,
                    Args = new List<Function> { new Function(), new Function() }
                }
            };
            functionPlotter.Function.Args.ElementAt(0).Type = FunctionType.Variable;
            functionPlotter.Function.Args.ElementAt(1).Type = FunctionType.Constant;
            functionPlotter.Function.Args.ElementAt(1).Value = 2;
            var solver = new Solver(functionPlotter);

            // When
            List<Pair> resultList = solver.Solve();

            // Then
            var expectedList = new List<Pair>
            {
                new Pair(1, 1),
                new Pair(2, 4),
                new Pair(3, 9),
                new Pair(4, 16),
                new Pair(5, 25),
            };

            CollectionAssert.AreEqual(expectedList, resultList);
        }
    }
}
