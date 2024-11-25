using Domain.Model.Models.Input;
using FluentValidation;
using System;
using System.Linq;

namespace Application.Validation
{
    public class PlatformAddValidator : AbstractValidator<AddPlatformInput>
    {
        public PlatformAddValidator()
        {
            RuleFor(x => x.WarehouseId)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.Cargo)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
