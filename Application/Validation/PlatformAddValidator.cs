using Domain.Model.Models.Input;
using Domain.Model.Models.Output;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validation
{
    public class PlatformAddValidator:AbstractValidator<AddPlatformInput>
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
