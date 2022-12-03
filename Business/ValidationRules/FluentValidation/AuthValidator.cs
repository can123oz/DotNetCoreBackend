using Entity.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class AuthValidator : AbstractValidator<UserForRegisterDto>
    {
        public AuthValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.LastName).NotEmpty();
            RuleFor(p => p.Password).NotEmpty();
            RuleFor(p => p.Email).NotEmpty();
            RuleFor(p => p.Email).EmailAddress();

        }
    }
}
