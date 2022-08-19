using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Color Name Cant be Empty...");
            RuleFor(p => p.Name).MinimumLength(2).WithMessage("Type a longer Color name");
        }
    }
}
