using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name cant be empty"); ;
            RuleFor(p => p.Description).NotEmpty().WithMessage("Description cant be empty"); ;
            RuleFor(p => p.Name).MinimumLength(2).WithMessage("Enter a longer name");

            RuleFor(p => p.BrandId).NotNull();
            RuleFor(p => p.ColorId).NotNull();
        }
    }
}
