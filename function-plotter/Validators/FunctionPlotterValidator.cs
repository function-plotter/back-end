using FluentValidation;
using function_plotter.Models;
using function_plotter.Solvers;
using System;

namespace function_plotter.Validators
{
    public class FunctionPlotterValidator: AbstractValidator<FunctionPlotter>
    {
        public FunctionPlotterValidator()
        {
            RuleFor(x => x).NotNull().WithMessage("Object received must not be null!");
            RuleFor(x => x.Function).NotNull().WithMessage("Function must not be null!");
            RuleFor(x => x.Range).NotNull().WithMessage("Range must not be null!");
            RuleFor(x => x.Range.Step).GreaterThan(0)
                .When(x => x.Range != null).WithMessage("Range Step must be greater than 0!");
        }
    }
}
