using Domain.Model.Models.Input;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validation
{
    public class PicketAddValidator:AbstractValidator<UpdatePicketInput>
    {
        public PicketAddValidator()
        {
            RuleFor(x => x.PlatformId)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);
            RuleFor(x => x.PicketId)
                .GreaterThan(0);

        }
    }
}
