using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Brand Name Cant be Empty...");
            RuleFor(p => p.Name).Must(CantStartWith).WithMessage("Brand Name cant start with X");
        }

        public bool CantStartWith(string arg)
        {
            return arg.StartsWith("X");
        }
    }
}
