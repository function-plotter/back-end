using FluentValidation;
using function_plotter.Models;

namespace function_plotter.Validators
{
    public class FunctionPlotterValidator: AbstractValidator<FunctionPlotter>
    {
        public FunctionPlotterValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x).NotNull().WithMessage("Object received must not be null!");

            RuleFor(x => x.Function)
                .NotNull()
                .DependentRules(() =>
                {
                    RuleFor(x => x.Function.Type)
                        .NotNull()
                        .WithMessage("Function must not be null!");

                    When(x => x.Function.Type == FunctionType.Integral, () =>
                    {
                        RuleFor(x => x.Function.Range)
                            .NotNull()
                            .WithMessage("Function Range cannot be null when Function Type is Integral!");
                    });
                })
                .WithMessage("Function must not be null!");

            //RuleFor(x => x.Function).NotNull().WithMessage("Function must not be null!");
            //RuleFor(x => x.Function.Type).NotNull().WithMessage("Function type cannot be null!");

            RuleFor(x => x.Range)
                .NotNull()
                .DependentRules(() =>
                {
                    RuleFor(x => x.Range.Step).GreaterThan(0).WithMessage("Range must not be null!");
                })
                .WithMessage("Range must not be null!");

            //When(x => x.Function.Type == FunctionType.Integral, () => 
            //{
              //  RuleFor(x => x.Function.Range)
                  //  .NotNull()
                 //   .WithMessage("Function Range cannot be null when Function Type is Integral!");
            //); 

            //RuleFor(x => x.Function.Range)
                //.NotNull
            //RuleFor(x => x.Range).NotNull().WithMessage("Range must not be null!");
            //RuleFor(x => x.Range.Step).GreaterThan(0)
            //.When(x => x.Range != null).WithMessage("Range Step must be greater than 0!");

        }
    }
}
