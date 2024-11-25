using Domain.Model.Models.Input;
using FluentValidation;
using System;
using System.Linq;

namespace Application.Validation
{
    public class PicketAddValidator : AbstractValidator<UpdatePicketInput>
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
